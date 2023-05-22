using System;
using Microsoft.AspNetCore.Identity;

namespace OzelDers.Entity.Concrete.Identity
{
	public class Role : IdentityRole
	{
        public string Description { get; set; }
    }
}

