using System;
using OzelDers.Entity.Concrete.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OzelDers.MVC.Areas.Admin.Models.ViewModels.Branches;
using OzelDers.MVC.Areas.Admin.Models.ViewModels.Students;
using OzelDers.Entity.Concrete;

namespace OzelDers.MVC.Areas.Admin.Models.ViewModels.Teachers
{
	public class TeacherViewModel
	{
            public int Id { get; set; }

            [DisplayName("Ad")]
            [Required(ErrorMessage = "Ad alanı boş bırakılmamalıdır")]
            public string FirstName { get; set; }

            [DisplayName("Soyad")]
            [Required(ErrorMessage = "Soyad alanı boş bırakılmamalıdır")]
            public string LastName { get; set; }

            [DisplayName("Cinsiyet")]
            [Required(ErrorMessage = "Cinsiyet alanı boş bırakılmamalıdır")]
            public string Gender { get; set; }

        [DisplayName("Doğum Tarihi")]
        [Required(ErrorMessage = "Doğum Tarihi alanı boş bırakılmamalıdır")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Şehir")]
        [Required(ErrorMessage = "Şehir alanı boş bırakılmamalıdır")]
        public string City { get; set; }

        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "Telefon Numarası alanı boş bırakılmamalıdır")]
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        [DisplayName("Onaylı")]
        public bool IsApproved { get; set; }

        public string Url { get; set; }

        [DisplayName("Mezuniyet")]
        [Required(ErrorMessage = "Mezuniyet alanı boş bırakılmamalıdır")]
        public string Graduation { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<StudentViewModel> Students { get; set; }
        public List<BranchViewModel> Branches { get; set; }

        [DisplayName("Resim")]
        [Required(ErrorMessage = "Resim alanı boş bırakılmamalıdır")]
        public Image Image { get; set; }

    }
}

