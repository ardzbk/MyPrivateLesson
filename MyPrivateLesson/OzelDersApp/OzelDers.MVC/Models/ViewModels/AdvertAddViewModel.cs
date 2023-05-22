using System;
using OzelDers.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OzelDers.MVC.Models.ViewModels
{
	public class AdvertAddViewModel
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Açıklama alanı boş bırakılmamalıdır")]
        public string Description { get; set; }

        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "Fiyat alanı boş bırakılmamalıdır")]
        public decimal? Price { get; set; }

        public List<SelectListItem> SelectBranchList { get; set; }

        public int BranchId { get; set; }
        public string BranchName { get; set; }
    }
}

