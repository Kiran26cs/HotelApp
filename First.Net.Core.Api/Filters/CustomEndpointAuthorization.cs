using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hotel.Auth.Api.Filters
{
    public class CustomEndpointAuthorization : Attribute, IAuthorizationFilter
    {
        public string roleToCheck = string.Empty;
        public CustomEndpointAuthorization(string CheckUserRoleName)
        {
            roleToCheck = CheckUserRoleName;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool validated = false;
            if (context != null && context.HttpContext !=null)
            {
                var userDetail = context.HttpContext.User;
                if (userDetail != null && userDetail.Claims !=null && userDetail.Claims.Any())
                {
                    var userClaimRole = userDetail.Claims.FirstOrDefault(x=>x.Type== ClaimTypes.Role);
                    if (userClaimRole != null && userClaimRole.Value == roleToCheck)
                    {
                        validated = true;
                    }
                }
            }
            if (validated)
            {
                context.HttpContext.Response.StatusCode = 200;

            }
            else
            {
                context.HttpContext.Response.StatusCode = 401;
                context.Result = new JsonResult("NotAuthorized")
                {
                    Value = new
                    {
                        Status = "Error",
                        Message = "Invalid Token"
                    }
                };
            }
        }
    }
}
