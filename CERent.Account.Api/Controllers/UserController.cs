using CERent.Account.API.Helpers;
using CERent.Account.Lib.Application.Models;
using CERent.Account.Lib.Application.Services;
using CERent.Core.Lib.Model;
using CERent.Core.Lib.QueueModels;
using CERent.Core.Lib.Settings;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace CERent.Account.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v{version:apiVersion}/[controller]")]
    [CustomAuthorization]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger = null;
        private readonly ILoginService _loginService = null;
        private readonly RabbitMqSetting _rabbitMqSetting = null;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ISendEndpoint _sendEndpoint;

        public UserController(ILogger<UserController> logger,
            ILoginService loginService,
            IOptions<RabbitMqSetting> rabbitMqSetting,
            IPublishEndpoint publishEndpoint
            )
        {
            _logger = logger;
            _loginService = loginService;
            _rabbitMqSetting = rabbitMqSetting?.Value;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
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

        //[HttpPost]
        //[Route("Buy")]
        //[CustomAuthorization(UserType.Buyer)]
        //public async Task<IActionResult> Buy()
        //{
        //    try
        //    {
        //        //_publishEndpoint.Publish<ILoginNotification>()

        //        await _publishEndpoint.Publish<LoginNotification>(new
        //        {
        //            Email = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss")
        //        }); ;
            

        //        //var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
        //        //{
        //        //    cfg.Host(_rabbitMqSetting.Url, 5672, "my-rabbit", hst =>
        //        //    {
        //        //        hst.Username(_rabbitMqSetting.UserName);
        //        //        hst.Password(_rabbitMqSetting.Password);
        //        //    });

        //        //    //cfg.Host(_rabbitMqSetting.Url, 5672,  hst =>
        //        //    //{
        //        //    //    hst.Username(_rabbitMqSetting.UserName);
        //        //    //    hst.Password(_rabbitMqSetting.Password);
        //        //    //});



        //        //    //registrationAction?.Invoke(cfg, host);
        //        //});

        //        //var sendToUri = new Uri($"{_rabbitMqSetting.Url}{_rabbitMqSetting.LoginQueue}");
        //        //var endPoint = await bus.GetSendEndpoint(sendToUri);

        //        //await endPoint.Send<ILoginNotification>(new
        //        //{
        //        //    Email = "test@test.com"
        //        //});

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}
    }
}
