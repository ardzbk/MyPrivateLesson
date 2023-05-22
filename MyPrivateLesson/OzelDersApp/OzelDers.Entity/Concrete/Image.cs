using System;
using OzelDers.Entity.Abstract;

namespace OzelDers.Entity.Concrete
{
	public class Image : IBaseEntity
	{
        public int Id { get; set; }

        public string Url { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsApproved { get; set; }

    }
}

