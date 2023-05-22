using System;
using System.ComponentModel.DataAnnotations;
using OzelDers.Entity.Concrete;

namespace OzelDers.MVC.Models.ViewModels.CartModels
{
	public class CartViewModel
	{
		public int CartId { get; set; }

		public List<CartItemViewModel> CartItems { get; set; }

		public decimal? TotalPrice()
		{
			return CartItems.Sum(ci => ci.ItemPrice * ci.Amount);
		}

	}

	public class CartItemViewModel
	{
        public int CartItemId { get; set; }
        public int AdvertId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherGraduation { get; set; }
        public string TeacherUrl { get; set; }
        public string BranchName { get; set; }
        public decimal? ItemPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Boş bırakılamaz")]
        [Range(1, 10)]
        public int Amount { get; set; }
    }
}

