using EFRepository.DTO;
using EFRepository.Services.Interace;
using Microsoft.AspNetCore.Identity;

namespace ATWebAPI.Facade.Interface;
public interface IUserBusiness:ICommon<UserDTO>
{
    Task<UserDTO> Get(string userName);
    Task<bool> ValidateUser(LoginDTO loginDTO);
}
