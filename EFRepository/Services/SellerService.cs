using EFRepository.Models;
using EFRepository.Services.Interace;

namespace EFRepository.Services
{
    //// <summary>
    //// This is service where we manipulate the seller
    //// </summary>
    public class SellerService : ISellerService
    {
        private IStorage<SellerInfo> _storage;
        public SellerService(IStorage<SellerInfo> storage)
        {
            _storage = storage;
        }

        //// <summary>
        //// Add the seller info
        //// </summary>
        public async Task Add(SellerInfo entity)
        {
            if(entity is null) throw new ArgumentNullException("Invalid seller info");

            await _storage.Insert(entity);
            await _storage.SaveChangesAsync();
        }

        //// <summary>
        //// Delete the seller
        //// </summary>
        public async Task Delete(int id)
        {
            if (id == 0) throw new ArgumentNullException("Invalid sellerid");

            var seller= await _storage.Get(id);
            if (seller is null) throw new Exception("Invalid seller info");

            _storage.Delete(seller);
            await _storage.SaveChangesAsync();
        }

        //// <summary>
        //// Get all the sellers
        //// </summary>
        public async Task<IList<SellerInfo>> Get()
        {
            return await _storage.Get();
        }

        //// <summary>
        //// Get seller by id
        //// </summary>
        public async Task<SellerInfo> Get(int id)
        {
            if (id == 0) throw new ArgumentNullException("Invalid sellerid");

            return await _storage.Get(id);
        }

        //// <summary>
        //// Get seller by id
        //// </summary>
        public async Task Update(SellerInfo entity)
        {
            if (entity is null) throw new ArgumentNullException("Invalid seller info");

            var seller = await _storage.Get(entity.Id);
            if (seller is null) throw new Exception("Seller not found");

            _storage.Update(entity);
            await _storage.SaveChangesAsync();
        }
    }
}
