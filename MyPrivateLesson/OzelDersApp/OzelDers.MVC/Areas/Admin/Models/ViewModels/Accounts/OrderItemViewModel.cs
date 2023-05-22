using System;
using System.ComponentModel.DataAnnotations;

namespace OzelDers.MVC.Areas.Admin.Models.ViewModels.Accounts
{
	public class OrderItemViewModel
	{

        public int OrderItemId { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherUrl { get; set; }
        public decimal? ItemPrice { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [Range(1, 10)]
        public int Amount { get; set; }
    }
}

