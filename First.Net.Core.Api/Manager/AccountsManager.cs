using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppManager.AppInterfaces;
using AppModels.ConfigModels;
using Hotel.Auth.Api.ApiModel;
using Hotel.Auth.Api.Repository;

namespace Hotel.Auth.Api.Manager
{
    public class AccountsManager : IAccountsManager
    {
        IAccountsRepository accountsRepository;
        ITokenProcessor itokenprocessor;
        public AccountsManager(IAccountsRepository accountsRepository, ITokenProcessor itokenprocessor)
        {
            this.accountsRepository = accountsRepository;
            this.itokenprocessor = itokenprocessor;
        }
        public async Task<LoginResponse> Login(LoginRequest request, JWTConfiguration jWTConfiguration)
        {
            LoginResponse loginResponse = new LoginResponse();
            string tokenValue = string.Empty;
            if (await accountsRepository.Login(request))
            {
                //Fetch user detail
                //[TODO] - get user role by username
                //generate token
                tokenValue = itokenprocessor.createNewWebToken(jWTConfiguration, request.UserName, "Admin");
                loginResponse = new LoginResponse
                {
                    UserName = request.UserName,
                    Token = tokenValue
                };
                
            }
            return loginResponse;
        }

        public async Task<CreateUserResponse> CreateUser(CreateUserRequest request)
        {
            bool createdUser = false;
            var req = request.ConvertToObject<CreateUserRequest, LoginRequest>();
            if (!await accountsRepository.Login(req))
            {
                await accountsRepository.CreateUser(request);
                createdUser = true;
            }
            var resp = request.ConvertToObject<CreateUserRequest, CreateUserResponse>();
            resp.IsSuccess = createdUser;
            return resp;
        }
    }
}
