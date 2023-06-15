using EFRepository.Models;
using EFRepository.Services.Interace;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Services
{
    internal class CategoryService : ICategoryService
    {
        private IStorage<Category> _storage;
        public CategoryService(IStorage<Category> storage)
        {
            _storage = storage;
        }

        //// <summary>
        //// Add the catagory if it has data other wise throw exception
        //// </summary>
        public async Task Add(Category entity)
        {
            if (entity == null) throw new ArgumentNullException("user");

            await _storage.Insert(entity);
            await _storage.SaveChangesAsync();
        }

        //// <summary>
        //// Delete the catagory if it has data other wise throw exception
        //// </summary>
        public async Task Delete(int id)
        {
            if (id <= 0) throw new ArgumentException($"{nameof(id)} should be greater than xero");
            var seller = await _storage.Get(id);
            if (seller.Id>0)
            {
                _storage.Delete(seller);
                await _storage.SaveChangesAsync();
            }
        }

        //// <summary>
        //// Get all catagories
        //// </summary>
        public async Task<IList<Category>> Get()
        {
            return await _storage.Get();
        }

        //// <summary>
        //// Get catagory by id if it does not match throw the exceptio
        //// </summary>
        public async Task<Category> Get(int id)
        {
            if (id <=0) throw new ArgumentNullException("id should be greter than 0");
            return await _storage.Get(id);
        }

        //// <summary>
        //// update the catagory if it has data other wise throw exception
        //// </summary>
        public async Task Update(Category entity)
        {
            var category = await _storage.Get(entity.Id);
            if (category is null)
            {
                _storage.Update(entity);
                await _storage.SaveChangesAsync();
            }
        }
    }
}
