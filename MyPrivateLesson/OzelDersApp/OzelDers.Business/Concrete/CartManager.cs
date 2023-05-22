using System;
using OzelDers.Business.Abstract;
using OzelDers.Data.Abstract;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartRepository _cartRepository;

        public CartManager(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task AddToCart(string userId, int advertId, int amount)
        {
            await _cartRepository.AddToCard(userId, advertId, amount);
        }


        public async Task<Cart> GetByIdAsync(int id)
        {
           return  await _cartRepository.GetByIdAsync(id);
        }

        public async Task<Cart> GetCartByUserId(string userId)
        {
            return await _cartRepository.GetCartByUserId(userId);
        }

        public async Task InitializeCart(string userId)
        {
            await _cartRepository.CreateAsync(new Cart { UserId = userId });
        }
    }
}

