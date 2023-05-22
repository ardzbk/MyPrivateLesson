using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelDers.MVC.Areas.Admin.Models.ViewModels.Branches
{
	public class BranchAddViewModel
	{
        [DisplayName("Branş Adı")]
        [Required(ErrorMessage = "Branş adı boş bırakılmamalıdır")]
        [MinLength(5, ErrorMessage = "Branş adı en az 5 karakter olmalıdır")]
        [MaxLength(100, ErrorMessage = "Branş adı en fazla 100 karakter olmalıdır")]
        public string BranchName { get; set; }

        [DisplayName("Branş Açıklaması")]
        [Required(ErrorMessage = "Branş açıklaması boş bırakılmamalıdır")]
        [MinLength(5, ErrorMessage = "Branş açıklaması en az 5 karakter olmalıdır")]
        [MaxLength(500, ErrorMessage = "Branş açıklaması en fazla 500 karakter olmalıdır")]
        public string Description { get; set; }

        public string Url { get; set; }


        [DisplayName("Onaylı mı?")]
        public bool IsApproved { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

