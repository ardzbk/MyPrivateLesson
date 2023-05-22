using System;
namespace OzelDers.Entity.Concrete
{
	public class TeacherBranch
	{
		public int TeacherId { get; set; }

		public Teacher Teacher { get; set; }

		public int BranchId { get; set; }

		public Branch Branch { get; set; }
	}
}

