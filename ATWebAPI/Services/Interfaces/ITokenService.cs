using ATWebAPI.Models;

namespace ATWebAPI.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user, string[] roles);
    }
}
