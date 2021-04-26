using CERent.Core.Lib.Model;

namespace CERent.Core.Lib.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(string email, UserType userType);

        AuthUser ValidateToken(string token);
    }
}