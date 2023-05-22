using System;
using Microsoft.EntityFrameworkCore;
using OzelDers.Data.Abstract;
using OzelDers.Data.Concrete.EfCore.Context;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Concrete.EfCore
{
	public class EfCoreOrderRepository : EfCoreGenericRepository<Order> ,IOrderRepository
	{

        public EfCoreOrderRepository(PrivateLessonContext _appContext) : base(_appContext)
        {
        }
        PrivateLessonContext AppContext
        {
            get { return _dbContext as PrivateLessonContext; }
        }

        public async Task<List<Order>> GetAllOrdersAsync(string userId = null, bool dateSort = false)
        {
            var orders = AppContext
                 .Orders
                 .Include(o => o.OrderItems)
                 .ThenInclude(oi => oi.Advert)
                 .ThenInclude(oi => oi.Teacher)
                 .ThenInclude(oi => oi.User)
                 .ThenInclude(oi => oi.Image)
                 .AsQueryable();
            if (dateSort)
            {
                orders = orders.OrderByDescending(o => o.OrderDate);
            }
            else
            {
                orders = orders.OrderBy(o => o.OrderDate);
            }
            if (!String.IsNullOrEmpty(userId))
            {
                orders = orders.Where(o => o.UserId == userId);
            }
            return await orders.ToListAsync();
        }

        public async Task<List<Order>> SearchOrderByUser(string keyword, bool dateSort = false)
        {
            var orders = AppContext
                     .Orders
                     .Include(o => o.OrderItems)
                     .ThenInclude(oi => oi.Advert)
                     .ThenInclude(oi => oi.Teacher)
                     .ThenInclude(oi => oi.User)
                     .ThenInclude(oi => oi.Image)
                     .Where(o => o.NormalizedName.Contains(keyword))
                     .AsQueryable();
            if (dateSort)
            {
                orders = orders.OrderByDescending(o => o.OrderDate);
            }
            else
            {
                orders = orders.OrderBy(o => o.OrderDate);
            }
            return await orders.ToListAsync();
        }
    }
}

