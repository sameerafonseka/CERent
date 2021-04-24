using CERent.Account.Lib.Domain.Models;
using System.Threading.Tasks;

namespace CERent.Account.Lib.Domain.Services
{
    public interface IUserService
    {
        Task<User> GetUser(string email, string password);

        Task<User> GetUser(string email);
    }
}