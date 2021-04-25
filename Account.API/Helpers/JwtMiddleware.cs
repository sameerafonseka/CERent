using CERent.Account.Lib.Application.Models;
using CERent.Account.Lib.Application.Services;
using CERent.Core.Lib.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CERent.Account.API.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtSetting _jwtSetting;

        public JwtMiddleware(RequestDelegate next,
            IOptions<JwtSetting> jwtSetting
            )
        {
            _next = next;
            _jwtSetting = jwtSetting?.Value;
        }

        public async Task Invoke(HttpContext context, ILoginService _loginService)
        {
            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if (token != null)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_jwtSetting.SecretKey);

                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    var jwtToken = (JwtSecurityToken) validatedToken;
                    var email = jwtToken.Claims.FirstOrDefault(x => x.Type == "Email")?.Value;

                    if (!String.IsNullOrWhiteSpace(email))
                    {
                        context.Items["User"] = await _loginService.Authenticate(new AuthenticateQuery { Email = email });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await _next(context);
            }
        }
    }
}
