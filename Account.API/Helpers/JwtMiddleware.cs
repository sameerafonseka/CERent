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
        private readonly ILoginService _loginService;
        

        public JwtMiddleware(RequestDelegate next, 
            IOptions<JwtSetting> jwtSetting,
            ILoginService loginService
            )
        {
            _next = next;
            _jwtSetting = jwtSetting?.Value;
            _loginService = loginService;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                AuthenticateAndAttachToContent(context, token);

            await _next(context);
        }

        private void AuthenticateAndAttachToContent(HttpContext context, string token)
        {
            try
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

                var jwtToken = (JwtSecurityToken)validatedToken;
                var email = jwtToken.Claims.First(x => x.Type == ClaimTypes.Name).Value;

                // attach user to context on successful jwt validation
                context.Items["User"] = _loginService.Authenticate(new AuthenticateQuery { Email = email });
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
