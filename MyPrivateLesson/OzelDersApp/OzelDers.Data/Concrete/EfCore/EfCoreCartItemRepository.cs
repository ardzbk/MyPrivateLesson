using System;
using Microsoft.EntityFrameworkCore;
using OzelDers.Data.Abstract;
using OzelDers.Data.Concrete.EfCore.Context;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Concrete.EfCore
{
	public class EfCoreCartItemRepository : EfCoreGenericRepository<CartItem> ,ICartItemRepository
	{
        public EfCoreCartItemRepository(PrivateLessonContext _appContext) : base(_appContext)
        {
        }
        
        PrivateLessonContext AppContext
        {
            get { return _dbContext as PrivateLessonContext; }
        }


        public async Task ChangeAmountAsync(CartItem cartItem, int amount)
        {
            cartItem.Amount = amount;
            AppContext.CartItems.Update(cartItem);
            await AppContext.SaveChangesAsync();
        }

        public void ClearCart(int cartId)
        {
            AppContext
                .CartItems
                .Where(ci => ci.CartId == cartId)
                .ExecuteDelete();
        }
    }
}

