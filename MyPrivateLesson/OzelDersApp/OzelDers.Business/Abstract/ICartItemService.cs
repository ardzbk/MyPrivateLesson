using System;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Abstract
{
	public interface ICartItemService
	{
		Task ChangeAmountAsync(int cartItemId, int amount);

		Task<CartItem> GetByIdAsync(int Id);

		void Delete(CartItem cartitem);

		void ClearCart(int cartId);
	}
}

