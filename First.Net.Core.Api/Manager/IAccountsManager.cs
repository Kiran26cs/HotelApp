using Hotel.Auth.Api.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppModels.ConfigModels;

namespace Hotel.Auth.Api.Manager
{
    public interface IAccountsManager
    {
        Task<LoginResponse> Login(LoginRequest request, JWTConfiguration jWTConfiguration);
        Task<CreateUserResponse> CreateUser(CreateUserRequest request);
    }
}
