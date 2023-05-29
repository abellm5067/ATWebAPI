using EFRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Services.Interace
{
    public interface ICommon<T>
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<IList<T>> Get();
        Task<T> Get(int Id);
    }
}
