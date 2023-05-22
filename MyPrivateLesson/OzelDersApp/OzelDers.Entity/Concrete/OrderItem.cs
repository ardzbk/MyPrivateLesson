using System;
namespace OzelDers.Entity.Concrete
{
	public class OrderItem
	{
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int AdvertId { get; set; }
        public Advert Advert { get; set; }
        public decimal? Price { get; set; }
        public int Amount { get; set; }
    }
}

