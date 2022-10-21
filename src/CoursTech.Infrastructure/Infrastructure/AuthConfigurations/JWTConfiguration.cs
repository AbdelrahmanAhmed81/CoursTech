using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.AuthConfigurations
{
    public class JWTConfiguration : IJWTConfiguration
    {
        private readonly IConfiguration _configuration;

        public JWTConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"] ,
                audience: _configuration["JWT:Audience"] ,
                expires: DateTime.Now.AddMinutes(3) ,
                claims: authClaims ,
                signingCredentials: new SigningCredentials(authSigningKey , SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
        public List<Claim> GetClaims(IdentityUser user , params string[] userRoles)
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
