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
        public async Task<IActionResult> Refresh(AuthTokens authTokens)
        {
            if (authTokens is null)
                return BadRequest("Invalid client request");
            string accessToken = authTokens.AccessToken;
            string refreshToken = authTokens.RefreshToken;

            var principal = _jwtConfiguration.GetPrincipalFromExpiredToken(accessToken);
            var email = principal.Claims.SingleOrDefault(c=>c.Type==ClaimTypes.Email)?.Value; //this is mapped to the Name claim by default
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpirationDate <= DateTime.Now)
                return BadRequest("Invalid client request");

            var newRefreshToken = _jwtConfiguration.GetRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpirationDate = DateTime.Now.AddDays(7);
            await _userManager.UpdateAsync(user);

            return Ok(new AuthTokens()
            {
                AccessToken = _jwtConfiguration.GetAccessToken(principal.Claims.ToList()) ,
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
