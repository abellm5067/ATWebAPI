using EFRepository.DTO;

namespace ATWebAPI.Facade.Interface
{
    public interface ILoginBusiness
    {
        Task<bool> UpdatePassword(string token, string userName, string password);
        Task<string> GenerateResetPasswordLink(string email);
        Task<bool> Register(UserDTO userDTO);
    }

}