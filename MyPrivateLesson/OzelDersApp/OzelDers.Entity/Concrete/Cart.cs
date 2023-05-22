using System;
using OzelDers.Entity.Concrete.Identity;

namespace OzelDers.Entity.Concrete
{
	public class Cart
	{
        public int Id { get; set; }

        public string UserId { get; set; }

		public User User { get; set; }

		public List<CartItem> CartItems { get; set; }
	}
}

