using Application.DataModels;
using Application.Enums;
using Application.UserRoles;
using Microsoft.AspNetCore.Http;
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
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(
            UserManager<IdentityUser> userManager ,
            RoleManager<IdentityRole> roleManager ,
            SignInManager<IdentityUser> signInManager ,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] AuthModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user , model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role , userRole));
                }

                var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token) ,
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] AuthModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError , ResponseCode.USER_ALREADY_EXISTS);

            //if(await _signInManager.password)
            IdentityUser user = new()
            {
                Email = model.Email ,
                SecurityStamp = Guid.NewGuid().ToString() ,
                UserName = model.Email.Split('@')[0]
            };
            var result = await _userManager.CreateAsync(user , model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError , new Response { Status = 0 , Message = "User Creation Failed! Please Check User Details And Try Again." });

            if (!await _roleManager.RoleExistsAsync(Roles.User))
                return StatusCode(StatusCodes.Status500InternalServerError , new Response { Status = 0 , Message = "\'User\' Role not exists" });


            var roleResult = await _userManager.AddToRoleAsync(user , Roles.User);
            if (!roleResult.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError , new Response { Status = 0 , Message = "Failed to add the user to the role \'User\'" });

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role , Roles.User)
                };
            var token = GetToken(authClaims);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token) ,
                expiration = token.ValidTo
            });
        }

        //[HttpPost]
        //[Route("register-admin")]
        //public async Task<IActionResult> RegisterAdmin([FromBody] AuthModel model)
        //{
        //    var userExists = await _userManager.FindByEmailAsync(model.Email);
        //    if (userExists != null)
        //        return StatusCode(StatusCodes.Status500InternalServerError , new Response { Status = 0 , Message = "User already exists!" });

        //    IdentityUser user = new()
        //    {
        //        Email = model.Email ,
        //        SecurityStamp = Guid.NewGuid().ToString() ,
        //    };
        //    var result = await _userManager.CreateAsync(user , model.Password);
        //    if (!result.Succeeded)
        //        return StatusCode(StatusCodes.Status500InternalServerError , new Response { Status = 0 , Message = "User creation failed! Please check user details and try again." });

        //    if (!await _roleManager.RoleExistsAsync(Roles.Admin))
        //        await _roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        //    if (!await _roleManager.RoleExistsAsync(Roles.User))
        //        await _roleManager.CreateAsync(new IdentityRole(Roles.User));

        //    if (await _roleManager.RoleExistsAsync(Roles.Admin))
        //    {
        //        await _userManager.AddToRoleAsync(user , Roles.Admin);
        //    }
        //    if (await _roleManager.RoleExistsAsync(Roles.Admin))
        //    {
        //        await _userManager.AddToRoleAsync(user , Roles.User);
        //    }
        //    return Ok(new Response { Status = 1 , Message = "User created successfully!" });
        //}

        [HttpGet]
        [Route("getPasswordValidator")]
        public IActionResult GetPasswordValidator()
        {
            //var validatorsList = new List<IPasswordValidator<IdentityUser>>();
            //foreach (var validator in _userManager.PasswordValidators)
            //{
            //    validatorsList.Add(validator.ValidateAsync);
            //}
            return Ok(_userManager.Options.Password);
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"] ,
                audience: _configuration["JWT:ValidAudience"] ,
                expires: DateTime.Now.AddHours(3) ,
                claims: authClaims ,
                signingCredentials: new SigningCredentials(authSigningKey , SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
