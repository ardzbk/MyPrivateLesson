using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OzelDers.Entity.Concrete;

namespace OzelDers.MVC.Models.ViewModels.AccountModels
{
	public class TeacherRegisterViewModel
	{

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
        [Required(ErrorMessage = "Doğum tarihi alanı boş bırakılmamalıdır")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Şehir")]
        [Required(ErrorMessage = "Şehir alanı boş bırakılmamalıdır")]
        public string City { get; set; }

        [DisplayName("Telefon")]
        [Required(ErrorMessage = "Telefon alanı boş bırakılmamalıdır")]
        public string Phone { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adı alanı boş bırakılmamalıdır")]
        public string UserName { get; set; }

        [DisplayName("Eposta")]
        [Required(ErrorMessage = "Eposta alanı boş bırakılmamalıdır")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Parola")]
        [Required(ErrorMessage = "Parola alanı boş bırakılmamalıdır")]
        [MinLength(5,ErrorMessage ="Şifre minumum 5 harften oluşmak zorundadır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Parola Tekrar")]
        [Required(ErrorMessage = "Parola tekrar alanı boş bırakılmamalıdır")]
        [MinLength(5, ErrorMessage = "Şifre minumum 5 harften oluşmak zorundadır.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "İki parola aynı olmalıdır.")]
        public string RePassword { get; set; }

        public IFormFile Image { get; set; }

        public string Graduation { get; set; }

        public List<Branch>? Branches { get; set; }

        public int[] SelectedBranches { get; set; }
    }
}

