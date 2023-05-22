using System;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Abstract
{
	public interface ICartItemRepository :IGenericRepository<CartItem>
	{
		void ClearCart(int cartId);

		Task ChangeAmountAsync(CartItem cartItem, int amount);
	}
}

