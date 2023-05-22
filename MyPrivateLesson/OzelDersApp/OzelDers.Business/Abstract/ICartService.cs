using System;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Abstract
{
	public interface ICartService
	{
		Task InitializeCart(string userId);

		Task AddToCart(string userId, int advertId, int amount);

		Task<Cart> GetByIdAsync(int id);

		Task<Cart> GetCartByUserId(string userId);


	}
}

