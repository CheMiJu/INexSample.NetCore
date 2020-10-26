using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtToken
{
    public class TokenHelper
    {
        private readonly IConfiguration Configuration;

        public TokenHelper(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public string GenerateJWTToken(string userName)
        {
            var expireMinutes = Configuration.GetValue<int>("JwtSettings:ExpireMinutes");
            var secretKey = Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JwtSettings:SecretKey"));
            var issuer = Configuration.GetValue<string>("JwtSettings:Issuer");
            var claims = new List<Claim>() {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, DateTimeOffset.UtcNow.AddMinutes(expireMinutes).ToUnixTimeSeconds().ToString()),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(expireMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
