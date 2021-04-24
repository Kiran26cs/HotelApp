using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Auth.Api.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace First.Net.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [Authorize(Roles = "SchemeOperator")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return  Ok("JWT token based simple project");
        }

        [HttpGet]
        [Route("CommonEndpoint")]
        [CustomEndpointAuthorization(CheckUserRoleName:"PageAdmin")]
        public ActionResult<IEnumerable<string>> CommonEndpoint()
        {
            return Ok("This could be accessed by any roles");
        }
        [HttpGet]
        [Route("AdminEndpoint")]
        [CustomEndpointAuthorization(CheckUserRoleName: "Admin")]
        public ActionResult<IEnumerable<string>> AdminEndpoint()
        {
            return Ok("This could be accessed by any roles");
        }
    }
}
