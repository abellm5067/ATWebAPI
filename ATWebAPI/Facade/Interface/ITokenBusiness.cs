using EFRepository.DTO;

namespace ATWebAPI.Facade.Interface
{
    public interface ITokenBusiness
    {
        string GenerateToken(UserDTO user, string[] roles);
    }
}
