using CERent.Account.Lib.Application.Models;
using System.Threading.Tasks;

namespace CERent.Account.Lib.Application.Services
{
    public interface ILoginService
    {
        Task<LoginResult> Login(LoginQuery loginQuery);
        Task<UserAuthenticateResult> Authenticate(AuthenticateQuery authenticateQuery);
    }
}