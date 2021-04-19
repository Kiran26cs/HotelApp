using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Auth.Api.ApiModel
{
    public class UserDetail
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
    public class LoginRequest : UserDetail
    {

    }
    public class LoginResponse : UserDetail
    {
        public string Token { get; set; }
    }
    public class CreateUserRequest : UserDetail
    {
    }
    public class CreateUserResponse : UserDetail
    {
        public bool IsSuccess { get; set; }
    }
}
