using Application.DataModels;
using Application.Enums;
using Application.UserRoles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountController(
            UserManager<IdentityUser> userManager ,
            RoleManager<IdentityRole> roleManager ,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] AuthModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return StatusCode(StatusCodes.Status401Unauthorized , ResponseCode.USER_NOT_FOUND.ToString());

            if (!await _userManager.CheckPasswordAsync(user , model.Password))
                return StatusCode(StatusCodes.Status401Unauthorized , ResponseCode.WRONG_PASSWORD.ToString());

            var userRoles = await _userManager.GetRolesAsync(user);
            var claims = GetClaims(user , userRoles.ToArray());
            var token = GetToken(claims);

            return Ok(new AuthResponse
            {
                //Email = model.Email ,
                Token = new JwtSecurityTokenHandler().WriteToken(token) ,
                //Expiration = token.ValidTo
            });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] AuthModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status400BadRequest , ResponseCode.USER_ALREADY_EXISTS.ToString());

            IdentityUser user = new()
            {
                Email = model.Email ,
                SecurityStamp = Guid.NewGuid().ToString() ,
                UserName = model.Email.Split('@')[0]
            };
            var result = await _userManager.CreateAsync(user , model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status400BadRequest , ResponseCode.INVALID_PASSWORD.ToString());

            if (!await _roleManager.RoleExistsAsync(Roles.User))
                return StatusCode(StatusCodes.Status400BadRequest , ResponseCode.ROLE_NOT_EXISTS.ToString());

            var roleResult = await _userManager.AddToRoleAsync(user , Roles.User);
            if (!roleResult.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError , ResponseCode.UNKNOWN_ERROR);

            var claims = GetClaims(user , Roles.User );
            var token = GetToken(claims);

            return Ok(new AuthResponse
            {
                Email = model.Email ,
                Token = new JwtSecurityTokenHandler().WriteToken(token) ,
                Expiration = token.ValidTo
            });
        }

        [HttpGet]
        [Route("getPasswordValidator")]
        public IActionResult GetPasswordValidator()
        {
            return Ok(_userManager.Options.Password);
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"] ,
                audience: _configuration["JWT:Audience"] ,
                expires: DateTime.Now.AddDays(3),
                claims: authClaims ,
                signingCredentials: new SigningCredentials(authSigningKey , SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
        private List<Claim> GetClaims(IdentityUser user,params string[] userRoles)
        {
            var claims = new List<Claim>(){
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("email", user.Email),
            };
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role" , userRole));
            }
            return claims;
        }
    }
}
