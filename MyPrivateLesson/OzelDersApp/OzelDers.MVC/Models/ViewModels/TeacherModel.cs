using System;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;

namespace OzelDers.MVC.Models.ViewModels
{
	public class TeacherModel
	{
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Graduation { get; set; }

        public string? Url { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsApproved { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public List<Branch> Branches { get; set; }

        public List<Student> Students { get; set; }

        public int ImageId { get; set; }

        public Image Image { get; set; }
    }
}

