using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TechTestIBI.Models;

namespace TechTestIBI
{
    public class GenerateJSONWebToken
    {
        private JwtToken _token;

        public GenerateJSONWebToken(IOptions<JwtToken> token)
        {
            _token = token.Value;
        }

        public string GenerateToken(User user)
        {
            var securityHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_token.token);

            var securityToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("UserId", user.UserId.ToString()) }),
                Expires = DateTime.Now.AddMinutes(120),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = securityHandler.CreateToken(securityToken);
            return securityHandler.WriteToken(token);
        }
    }
}
