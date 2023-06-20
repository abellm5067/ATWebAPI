using EFRepository.Models;
using EFRepository.Services.Interace;

namespace EFRepository.Services
{
    //// <summary>
    //// This is service where we manipulate the order
    //// </summary>
    public class OrderService : IOrderService
    {
        private readonly IStorage<Order> _storage;
        public OrderService(IStorage<Order> storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Insert order details
        /// </summary>
        public async Task Add(Order entity)
        {
            if (entity is null) throw new ArgumentNullException("Invalid order details");
            await _storage.Insert(entity);
        }

        /// <summary>
        /// Delete order details
        /// </summary>
        public async Task Delete(int id)
        {
            if (id ==0 ) throw new ArgumentNullException("Invalid order id");

            var order = await _storage.Get(id);
            if (order is null) throw new Exception("order not found");

            _storage.Delete(order);
            await _storage.SaveChangesAsync();
        }

        /// <summary>
        /// Get all order details
        /// </summary>
        public async Task<IList<Order>> Get()
        {
            var orders= await _storage.Get();
            return orders;
        }

        /// <summary>
        /// Get order by id
        /// </summary>
        public async Task<Order> Get(int id)
        {
            if (id == 0) throw new ArgumentNullException("Invalid order id");

            var order=await _storage.Get(id);
            return order is null? throw new Exception("order not found"): order;
        }

        /// <summary>
        /// update order details
        /// </summary>
        public async Task Update(Order entity)
        {
            if (entity is null) throw new ArgumentNullException("Invalid order id");

            var order= await _storage.Get(entity.Id);
            if(order is null) throw new Exception("order not found");

            _storage.Update(entity);
            await _storage.SaveChangesAsync();
        }
    }
}
