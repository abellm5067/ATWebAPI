using EFRepository.Models;
using EFRepository.Services.Interace;

namespace EFRepository.Services
{
    //// <summary>
    //// This is service where we manipulate the catagory
    //// </summary>
    public class CategoryService : ICategoryService
    {
        private IStorage<Category> _storage;
        public CategoryService(IStorage<Category> storage)
        {
            _storage = storage;
        }

        //// <summary>
        //// insert catagory
        //// </summary>
        public async Task Add(Category entity)
        {
            if (entity == null) throw new ArgumentNullException("user");

            await _storage.Insert(entity);
            await _storage.SaveChangesAsync();
        }

        //// <summary>
        //// Delete catagory by id
        //// </summary>
        public async Task Delete(int id)
        {
            if (id <= 0) throw new ArgumentException($"invalid category id");

            var seller = await _storage.Get(id);
            if (seller.Id > 0)
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
        //// Get catagory by id
        //// </summary>
        public async Task<Category> Get(int id)
        {
            if (id <= 0) throw new ArgumentNullException("invalid category id");
            var category= await _storage.Get(id);
            return category is null ? throw new Exception("category not found"):category;
        }

        //// <summary>
        //// update the catagory
        //// </summary>
        public async Task Update(Category entity)
        {
            if (entity is null) throw new ArgumentNullException("invalid category id");

            var category = await _storage.Get(entity.Id);
            if (category is null) throw new Exception("category not found");

            _storage.Update(entity);
            await _storage.SaveChangesAsync();
        }
    }
}