using System;
using OzelDers.Business.Abstract;
using OzelDers.Data.Abstract;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CreateAsync(Order order)
        {
            await _orderRepository.CreateAsync(order);
        }

        public async Task<List<Order>> GetAllOrdersAsync(string userId = null, bool dateSort = false)
        {
            return await _orderRepository.GetAllOrdersAsync(userId, dateSort);
        }

        public async Task<List<Order>> SearchOrderByUser(string keyword, bool dateSort = false)
        {
            return await _orderRepository.SearchOrderByUser(keyword, dateSort);
        }
    }
}

