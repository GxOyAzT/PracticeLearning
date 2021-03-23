using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Api.IdentityJwt.UserData
{
    public class TokenService
    {
        public TokenService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public string GenerateToken(string userId)
        {
            var claims = new[]
            {
                new Claim("Id", userId)
            };

            var secretBytes = Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]);

            var key = new SymmetricSecurityKey(secretBytes);

            var algorithm = SecurityAlgorithms.HmacSha256;

            var signCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                null,
                null,
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(1),
                signCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
