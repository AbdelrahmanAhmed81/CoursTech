using Application.DataModels;
using Domain.Entities;
using Infrastructure.AuthConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJWTConfiguration _jwtConfiguration;

        public TokenController(
            UserManager<AppUser> userManager ,
            IJWTConfiguration jwtConfiguration)
        {
            _userManager = userManager;
            _jwtConfiguration = jwtConfiguration;
        }
        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> Refresh(AuthTokens tokens)
        {
            var refreshToken = tokens.RefreshToken;
            var user = _userManager.Users.SingleOrDefault(u=>u.RefreshToken==refreshToken);

            if (user is null || user.RefreshTokenExpirationDate <= DateTime.Now)
                return BadRequest("Invalid client request");
            
            var userRoles = await _userManager.GetRolesAsync(user);
            var userClaims = _jwtConfiguration.GetClaims(user , userRoles.ToArray());
            
            var newRefreshToken = _jwtConfiguration.GetRefreshToken();
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpirationDate = DateTime.Now.AddDays(7);
            await _userManager.UpdateAsync(user);

            return Ok(new AuthTokens()
            {
                AccessToken = _jwtConfiguration.GetAccessToken(userClaims) ,
                RefreshToken = newRefreshToken
            });
        }
        //[HttpPost, Authorize]
        //[Route("revoke")]
        //public async Task<IActionResult> Revoke()
        //{
        //    var username = User.Identity.Name;
        //    var user = _userContext.LoginModels.SingleOrDefault(u => u.UserName == username);
        //    if (user == null)
        //        return BadRequest();
        //    user.RefreshToken = null;
        //    _userContext.SaveChanges();
        //    return NoContent();
        //}
    }
}
