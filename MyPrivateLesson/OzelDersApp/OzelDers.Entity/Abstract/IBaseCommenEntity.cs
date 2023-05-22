using System;
namespace OzelDers.Entity.Abstract
{
	public interface IBaseCommenEntity
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

    }
}

