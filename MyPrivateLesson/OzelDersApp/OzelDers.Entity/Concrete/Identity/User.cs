using System;
using Microsoft.AspNetCore.Identity;
using OzelDers.Entity.Abstract;

namespace OzelDers.Entity.Concrete.Identity
{
	public class User :IdentityUser ,IBaseCommenEntity
	{
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }

        public DateTime? DateOfBirth { get; set ; }

        public string Phone { get; set; }

        public Teacher? Teacher { get; set; }

        public Student? Student { get; set; }

        public Cart Cart { get; set; }

        public int ImageId { get; set; }

        public Image Image { get; set; }

        public List<Order> Orders { get; set; }
    }
}

