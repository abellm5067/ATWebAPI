using EFRepository.DTO;

namespace ATWebAPI.Facade.Interface
{
    public interface IUserBusiness
    {
        Task Add(UserDTO user);
        Task Update(UserDTO user);
        Task Delete(int id);
        Task<IList<UserDTO>> GetAll();
        Task<UserDTO> GetUser(int id);
        Task<UserDTO> GetUser(string userName);
    }
}
