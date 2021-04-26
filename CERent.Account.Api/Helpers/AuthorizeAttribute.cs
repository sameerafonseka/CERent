using CERent.Account.Lib.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace CERent.Account.API.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeAttribute2 : Attribute, IAuthorizationFilter
    {
        private readonly UserType[] _allowedUserTypes;

        public CustomAuthorizeAttribute2()
        {
        }

        public CustomAuthorizeAttribute2(params UserType[] allowedUserTypes)
        {
            _allowedUserTypes = allowedUserTypes;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (AuthenticateResult)context.HttpContext.Items["User"];

            if (user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            else
            {
                if(_allowedUserTypes != null && _allowedUserTypes.Length > 0)
                {
                    if(_allowedUserTypes.Any(x => x == user.UserType) == false)
                        context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized }; 
                }
            }
        }
    }
}
