using System;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Abstract
{
	public interface IOrderRepository : IGenericRepository<Order>
	{
        Task<List<Order>> GetAllOrdersAsync(string userId = null, bool dateSort = false);
        Task<List<Order>> SearchOrderByUser(string keyword, bool dateSort = false);
    }
}

