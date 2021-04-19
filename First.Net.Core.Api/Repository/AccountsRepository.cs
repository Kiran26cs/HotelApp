using Hotel.Auth.Api.ApiModel;
using Hotel.Auth.Api.AppDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Auth.Api.Repository
{
    public class AccountsRepository : IAccountsRepository
    {
        AccountsDBContext accountsDBContext;
        public AccountsRepository(AccountsDBContext accountsDBContext)
        {
            this.accountsDBContext = accountsDBContext;
        }
        public async Task<bool> Login(LoginRequest request)
        {
            var isValidUser = await accountsDBContext.Users.AnyAsync(x=>x.UserName == request.UserName && x.Password == request.Password);
            return isValidUser;
        }

        public async Task CreateUser(CreateUserRequest request)
        {
            await accountsDBContext.Users.AddAsync(
                new AppModels.ContextModel.Users
                {
                    UserName =request.UserName,
                    Password = request.Password,
                    Email = request.Email
                });
            await accountsDBContext.SaveChangesAsync();
        }
    }
}
