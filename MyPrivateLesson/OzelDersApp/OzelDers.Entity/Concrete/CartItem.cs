using System;
namespace OzelDers.Entity.Concrete
{
	public class CartItem
	{
        public int  Id { get; set; }

        public int AdvertId { get; set; }

        public Advert Advert { get; set; }

        public int CartId { get; set; }

        public Cart Cart { get; set; }

        public int Amount { get; set; }

    }
}

