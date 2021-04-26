using CERent.Core.Lib.Model;
using CERent.Core.Lib.Services;
using CERent.Core.Lib.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CERent.Core.Lib.Api.Middleware
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

        public async Task Invoke(HttpContext context, IJwtTokenService jwtTokenService)
        {
            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if (token != null)
                {
                    var authUser= jwtTokenService.ValidateToken(token);

                    if (authUser != null)
                    {
                        context.Items["User"] = authUser;
                        
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
