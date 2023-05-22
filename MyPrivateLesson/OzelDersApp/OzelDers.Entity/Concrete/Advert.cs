using System;
using OzelDers.Entity.Abstract;

namespace OzelDers.Entity.Concrete
{
	public class Advert : IBaseEntity
    {
		public int Id { get; set; }

		public int TeacherId { get; set; }

		public Teacher Teacher { get; set; }

        public int BranchId { get; set; }

        public Branch Branch { get; set; }

        public string Description { get; set; }

		public decimal? Price { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsApproved { get; set; }

        public string Url { get; set; }
    }
}

