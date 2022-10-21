using Application.DataModels;
using Application.Enums;
using Application.UserRoles;
using Infrastructure.AuthConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJWTConfiguration _jwtConfiguration;

        public AccountController(
            UserManager<IdentityUser> userManager ,
            RoleManager<IdentityRole> roleManager,
            IJWTConfiguration jwtConfiguration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtConfiguration = jwtConfiguration;
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
            var claims = _jwtConfiguration.GetClaims(user , userRoles.ToArray());
            var token = _jwtConfiguration.GetToken(claims);

            return Ok(new AuthResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token) ,
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

            var claims = _jwtConfiguration.GetClaims(user , Roles.User );
            var token = _jwtConfiguration.GetToken(claims);

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
        
    }
}
