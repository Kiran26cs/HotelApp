using Hotel.Auth.Api.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Auth.Api.Repository
{
    public interface IAccountsRepository
    {
        Task<bool> Login(LoginRequest request);
        Task CreateUser(CreateUserRequest request);
    }
}
