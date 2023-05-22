using System;
using OzelDers.Entity.Abstract;

namespace OzelDers.Entity.Concrete
{
	public class Branch 
	{
		public int Id { get; set; }

		public string BranchName { get; set; }

		public string Description { get; set; }

		public string Url { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsApproved { get; set; }

        public List<TeacherBranch> TeacherBranches { get; set; }
		public List<Advert> Adverts { get; set; }
	}
}

