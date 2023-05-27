using EFRepository.DTO;
using Microsoft.AspNetCore.Identity;

namespace ATWebAPI.Facade.Interface
{
    public interface IUserBusiness
    {
        Task Add(UserDTO user);
        Task Update(UserDTO user);
        Task Delete(int id);
        Task<IList<UserDTO>> Get();
        Task<UserDTO> Get(int id);
        Task<UserDTO> Get(string userName);
        Task<bool> ValidateUser(LoginDTO loginDTO);
    }
}
