using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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
        public string GetAccessToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"] ,
                audience: _configuration["JWT:Audience"] ,
                expires: DateTime.Now.AddMinutes(1) ,
                claims: authClaims ,
                signingCredentials: new SigningCredentials(authSigningKey , SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public List<Claim> GetClaims(AppUser user , params string[] userRoles)
        {
            var claims = new List<Claim>(){
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role , userRole));
            }
            return claims;
        }
        public string GetRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false , //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false ,
                ValidateIssuerSigningKey = true ,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"])) ,
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token , tokenValidationParameters , out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || 
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256 , StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }

    }
}
