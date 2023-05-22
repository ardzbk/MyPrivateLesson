using System;
using OzelDers.Entity.Abstract;
using OzelDers.Entity.Concrete.Identity;

namespace OzelDers.Entity.Concrete
{
	public class Student  :  IBaseEntity 
	{
        public int Id { get; set; }

        public string Url { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsApproved { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public List<TeacherStudent> TeacherStudents { get; set; }

    }
}

