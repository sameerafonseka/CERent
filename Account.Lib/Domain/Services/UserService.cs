using CERent.Account.Lib.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CERent.Account.Lib.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly AccountDbContext _accountDbContext = null;

        public UserService(AccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }

        public async Task<User> GetUser(string email, string password)
        {
            var user = await _accountDbContext.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
            return user;
        }

        public async Task<User> GetUser(string email)
        {
            var user = await _accountDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }
    }
}
