using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CERent.Account.API.Helpers
{
    public class CustomAuthorizeHandler : CustomAttributeAuthorizationHandler<CustomAuthorizationRequirement, CustomAuthorizationAttribute>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            CustomAuthorizationRequirement requirement,
            IEnumerable<CustomAuthorizationAttribute> attributes)
        {

            //Authorize
            ////var loginTokenInfo = await Authorize(context?.User);
            ////if (loginTokenInfo == null)
            ////{
            ////    context?.Fail();
            ////}
            ////else
            ////{
            ////    if (context?.Resource != null)
            ////    {
            ////        //var authHeaderString= ((AuthorizationFilterContext)context.Resource).
            ////        //    HttpContext.Request.Headers["Authorization"].ToString();
            ////        //loginTokenInfo.AccessToken = authHeaderString.Split(' ')[1];

            ////        var authHeaderString = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
            ////        loginTokenInfo.AccessToken = authHeaderString.Split(' ')[1];

            ////    }
            ////    AddLoginInfoToClaim(context, loginTokenInfo);
            ////    context?.Succeed(requirement);
            ////}

            return await Task.CompletedTask;
        }
    }
}
