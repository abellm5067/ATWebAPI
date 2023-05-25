using EFRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Services.Interace
{
    public interface IUserService
    {
        Task Add(User user);
        Task Update(User user);
        Task Delete(int id);
        Task<IList<User>> GetAll();
        Task<User> GetUser(int Id);
        Task<User> GetUser(string UserName);
    }
}
