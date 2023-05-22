using System;
using OzelDers.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelDers.MVC.Models.ViewModels
{
	public class AdvertViewModel
	{
        public int Id { get; set; }

        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad alanı boş bırakılmamalıdır")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Soyad alanı boş bırakılmamalıdır")]
        public string LastName { get; set; }

        [DisplayName("Mezuniyet")]
        [Required(ErrorMessage = "Mezuniyet alanı boş bırakılmamalıdır")]
        public string Graduation { get; set; }
        public Image Image { get; set; }

        [DisplayName("Açıklam")]
        [Required(ErrorMessage = "Açıklama alanı boş bırakılmamalıdır")]
        public string Description { get; set; }

        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "Fiyat alanı boş bırakılmamalıdır")]
        public decimal? Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public Teacher Teacher { get; set; }

        public string BranchName { get; set; }

    }
}

