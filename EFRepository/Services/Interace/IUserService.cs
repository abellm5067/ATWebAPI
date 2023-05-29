using EFRepository.DTO;
using EFRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Services.Interace;
public interface IUserService : ICommon<User>
{
    Task<User> Get(string UserName);
    Task<string> GetUserByEmail(string email);
}
