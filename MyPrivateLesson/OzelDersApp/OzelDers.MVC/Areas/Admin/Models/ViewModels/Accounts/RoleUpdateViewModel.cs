using System;
using OzelDers.Entity.Concrete.Identity;

namespace OzelDers.MVC.Areas.Admin.Models.ViewModels.Accounts
{
	public class RoleUpdateViewModel
	{
        public Role Role { get; set; }
        public List<User> Members { get; set; }
        public List<User> NonMembers { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToRemove { get; set; }
    }
}

