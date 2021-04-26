using CERent.Account.Lib.Application.Models;
using CERent.Core.Lib.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CERent.Account.API.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class CustomAuthorizationAttribute :  Attribute, IAuthorizationFilter
    {
        private readonly UserType[] _allowedUserTypes;

        public CustomAuthorizationAttribute()
        {
        }

        public CustomAuthorizationAttribute(params UserType[] allowedUserTypes)
        {
            _allowedUserTypes = allowedUserTypes;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
                return;

            var user = (UserAuthenticateResult)context.HttpContext.Items["User"];

            if (user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            else
            {
                if (_allowedUserTypes != null && _allowedUserTypes.Length > 0)
                {
                    if (_allowedUserTypes.Any(x => x == user.UserType) == false)
                        context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                }
            }
        }
    }
}
