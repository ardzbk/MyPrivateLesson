using System;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Abstract
{
	public interface ICartRepository : IGenericRepository<Cart>
	{
		Task AddToCard(string userId, int advertId, int amount);

		Task<Cart> GetCartByUserId(string userId);

    }
}

