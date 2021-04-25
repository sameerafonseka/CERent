using CERent.Account.Lib.Application.Models;
using CERent.Account.Lib.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CERent.Account.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //[Authorize]

    //[Route("api/[controller]/[action]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = false, GroupName = nameof(EmailController))]
    [ApiVersion("1")]
    [Route("/api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger = null;
        private readonly ILoginService _loginService = null;

        public UserController(ILogger<UserController> logger,
            ILoginService loginService)
        {
            _logger = logger;
            _loginService = loginService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery loginQuery)
        {
            try
            {
                var result = await _loginService.Login(loginQuery);
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
