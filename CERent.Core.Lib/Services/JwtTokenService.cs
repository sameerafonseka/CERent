using CERent.Core.Lib.Model;
using CERent.Core.Lib.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CERent.Core.Lib.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtSetting _jwtSetting;

        public JwtTokenService(IOptions<JwtSetting> jwtSetting
            )
        {
            _jwtSetting = jwtSetting?.Value;
        }

        public string GenerateToken(string email, UserType userType)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSetting.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                        new Claim("Email", email),
                        new Claim("UserType", userType.ToString("f"))
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        public AuthUser ValidateToken(string token)
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

            var email = jwtToken.Claims.FirstOrDefault(x => x.Type == "Email")?.Value;
            var userType = jwtToken.Claims.FirstOrDefault(x => x.Type == "UserType")?.Value;

            if (!String.IsNullOrWhiteSpace(email))
            {
                //context.Items["User"] = await _loginService.Authenticate(new AuthenticateQuery { Email = email });

                Enum.TryParse<UserType>(userType, out UserType userTupe);

                return new AuthUser
                {
                    Email = email,
                    UserType = userTupe
                };
            }

            return null;
        }
    }
}
