using System;
using OzelDers.Business.Abstract;
using OzelDers.Data.Abstract;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Concrete
{
    public class CartItemManager : ICartItemService
    {
        ICartItemRepository _cartItemRepository;

        public CartItemManager(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task ChangeAmountAsync(int cartItemId, int amount)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            await _cartItemRepository.ChangeAmountAsync(cartItem, amount);
        }

        public void ClearCart(int cartId)
        {
            _cartItemRepository.ClearCart(cartId);
        }

        public void Delete(CartItem cartitem)
        {
            _cartItemRepository.Delete(cartitem);
        }

        public async Task<CartItem> GetByIdAsync(int Id)
        {
            return await _cartItemRepository.GetByIdAsync(Id);
        }
    }
}

