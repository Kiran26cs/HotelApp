using AppModels.ContextModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Auth.Api.AppDBContext
{
    public class AccountsDBContext:DbContext
    {
        public AccountsDBContext()
        {

        }
        public AccountsDBContext(DbContextOptions<AccountsDBContext> opt):base(opt)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<LoginTransaction> LoginTransactions { get; set; }
    }
}
