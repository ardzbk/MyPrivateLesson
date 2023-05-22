using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelDers.MVC.Models.ViewModels
{
	public class AdvertUpdateViewModel
	{
        public int Id { get; set; }
        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Açıklama alanı boş bırakılmamalıdır")]
        public string Description { get; set; }

        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "Fiyat alanı boş bırakılmamalıdır")]
        public decimal? Price { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsApproved { get; set; }
    }
}

