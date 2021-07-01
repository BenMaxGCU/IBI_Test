using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestIBI
{
    public class JwtMiddle
    {
        private readonly RequestDelegate _request;
        private readonly JwtToken _token;

        public JwtMiddle(RequestDelegate request, IOptions<JwtToken> token)
        {
            _request = request;
            _token = token.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var secret = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if(secret != null)
            {
                AttachUserToContext(context, secret);
            }

            await _request(context);
        }

        private void AttachUserToContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_token.token);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validToken);

                var jwtToken = (JwtSecurityToken)validToken;
                var UserId = jwtToken.Claims.First(x => x.Type == "id").Value;

                context.Items["User"] = UserId;
            }
            catch
            {
                
            }
        }
    }
}
