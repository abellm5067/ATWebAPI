using EFRepository.Models;
using EFRepository.Services.Interace;

namespace EFRepository.Services
{
    //// <summary>
    //// This is service where we manipulate the product
    //// </summary>
    public class ProductService : IProductService
    {
        private readonly IStorage<ProductInfo> _storage;
        public ProductService(IStorage<ProductInfo> storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Insert product details
        /// </summary>
        public async Task Add(ProductInfo entity)
        {
            if (entity is null) throw new ArgumentNullException("Invalid product details");

            await _storage.Insert(entity);
        }

        /// <summary>
        /// Delete product by id 
        /// </summary>
        public async Task Delete(int id)
        {
            if (id == 0) throw new ArgumentNullException("Invalid product id");

            var product = await _storage.Get(id);
            if (product is null) throw new Exception("product not found");

            _storage.Delete(product);
            await _storage.SaveChangesAsync();
        }

        /// <summary>
        /// Get all products
        /// </summary>
        public async Task<IList<ProductInfo>> Get()
        {
            var products = await _storage.Get();
            return products;
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        public async Task<ProductInfo> Get(int id)
        {
            if (id == 0) throw new ArgumentNullException("Invalid product id");

            var order = await _storage.Get(id);
            return order is null ? throw new Exception("product not found"):order;
        }

        /// <summary>
        /// update product details
        /// </summary>
        public async Task Update(ProductInfo entity)
        {
            if (entity is null) throw new ArgumentNullException("Invalid product info");

            var product = await _storage.Get(entity.Id);
            if (product is null) throw new Exception("product not found");

            _storage.Update(entity);
            await _storage.SaveChangesAsync();
        }
    }
}

