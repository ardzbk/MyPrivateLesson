using System;
namespace OzelDers.Entity.Abstract
{
	public interface IBaseEntity
	{
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsApproved { get; set; }

        public string Url { get; set; }
    }
}

