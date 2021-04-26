using CERent.Account.Lib.Application.Models;
using CERent.Account.Lib.Domain.Models;
using CERent.Account.Lib.Domain.Services;
using CERent.Core.Lib.Services;
using CERent.Core.Lib.Settings;
using CERent.Core.Lib.Utils;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
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
        private readonly ICacheProvider _cacheProvider = null;
        private readonly IJwtTokenService _jwtTokenService = null;
         
        public LoginService(ILogger<LoginService> logger,
            IUserService userService,
            IOptions<JwtSetting> jwtSetting,
            ICacheProvider cacheProvider,
            IJwtTokenService jwtTokenService
            )
        {
            _logger = logger;
            _userService = userService;
            _jwtSetting = jwtSetting?.Value;
            _cacheProvider = cacheProvider;
            _jwtTokenService = jwtTokenService;
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
                loginResult.Token = _jwtTokenService.GenerateToken(user.Email, user.UserType);

                //move this to a queue
                await _cacheProvider.SetCache($"User_{user.Email}", user);
            }

            return loginResult;
        }

        public async Task<UserAuthenticateResult> Authenticate(AuthenticateQuery authenticateQuery)
        {
            User user = await _cacheProvider.GetFromCache<User>($"User_{authenticateQuery.Email}");

            if(user == null)
                user = await _userService.GetUser(authenticateQuery.Email);

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
