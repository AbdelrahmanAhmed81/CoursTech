using Domain.Entities;
using System.Security.Claims;

namespace Infrastructure.AuthConfigurations
{
    public interface IJWTConfiguration
    {
        string GetAccessToken(List<Claim> authClaims);
        string GetRefreshToken();
        List<Claim> GetClaims(AppUser user , params string[] userRoles);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
