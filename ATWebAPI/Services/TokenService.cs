using ATWebAPI.Models;
using ATWebAPI.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ATWebAPI.Services
{
    public class TokenService: ITokenService
    {

        public string GenerateToken(User user, string[] roles)
        {

            var issuer = AppConfig.Issuer;
            var audience = AppConfig.Audience;
            var key = Encoding.ASCII.GetBytes
            (AppConfig.Key);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Id", Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.UserName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.UserName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()));
            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
