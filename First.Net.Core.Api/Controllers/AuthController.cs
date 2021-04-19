using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using AppManager.Processors;
using AppManager.AppInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using AppModels.ConfigModels;
using Hotel.Auth.Api.ApiModel;
using Hotel.Auth.Api.Manager;

namespace First.Net.Core.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ITokenProcessor itokenprocessor;
        private JWTConfiguration jwtConfiguration;
        readonly IAccountsManager accountsManager;
        public AuthController(ITokenProcessor itokenprocessor, IOptions<JWTConfiguration> jwtConfiguration, IAccountsManager accountsManager)
        {
            this.itokenprocessor = itokenprocessor;
            this.jwtConfiguration = jwtConfiguration.Value;
            this.accountsManager = accountsManager;
        }

        [HttpPost("Post")]
        public IActionResult Post()
        {
            return Ok(itokenprocessor.createNewWebToken(jwtConfiguration));
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<LoginResponse> Login(LoginRequest users)
        {
            return await accountsManager.Login(users, jwtConfiguration);
        }

        [HttpPost]
        [ActionName("CreateUser")]
        public async Task<CreateUserResponse> CreateUser(CreateUserRequest users)
        {
            return await accountsManager.CreateUser(users);
        }
    }
}