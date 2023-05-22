using System;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Abstract
{
	public interface IOrderService
	{
        Task CreateAsync(Order order);
        Task<List<Order>> GetAllOrdersAsync(string userId = null, bool dateSort = false);
        Task<List<Order>> SearchOrderByUser(string keyword, bool dateSort = false);
    }
}

