using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AuthConfigurations
{
    public interface IJWTConfiguration
    {
        JwtSecurityToken GetToken(List<Claim> authClaims);
        List<Claim> GetClaims(IdentityUser user , params string[] userRoles);
    }
}
