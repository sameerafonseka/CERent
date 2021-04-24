using CERent.Account.Lib.Application.Models;
using CERent.Account.Lib.Domain.Services;
using CERent.Core.Lib.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CERent.Account.Lib.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILogger _logger = null;
        private readonly IUserService _userService = null;
        private readonly JwtSetting _jwtSetting = null;

        public LoginService(ILogger<LoginService> logger,
            IUserService userService,
            IOptions<JwtSetting> jwtSetting)
        {
            _logger = logger;
            _userService = userService;
            _jwtSetting = jwtSetting?.Value;
        }

        public async Task<LoginResult> Login(LoginQuery loginQuery)
        {
            var loginResult = new LoginResult();

            var user = await _userService.GetUser(loginQuery.Email, loginQuery.Password);

            if (user != null)
            {
                loginResult.IsValidUser = true;
                loginResult.UserId = user.Id;
                loginResult.FullName = $"{user.FirstName} {user.LastName}";

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSetting.SecretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Email)
                    }),
                    Expires = DateTime.UtcNow.AddHours(4),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                loginResult.Token = tokenHandler.WriteToken(token);
            }

            return loginResult;
        }

        public async Task<UserAuthenticateResult> Authenticate(AuthenticateQuery authenticateQuery)
        {
            var user = await _userService.GetUser(authenticateQuery.Email);

            var authenticateResult = new UserAuthenticateResult
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserId = user.Id,
                UserType = user.UserType
            };

            return authenticateResult;
        }
    }
}
