using System;
namespace OzelDers.MVC.Areas.Admin.Models.ViewModels.Accounts
{
	public class UserViewModel
	{
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }

        public string City { get; set; }
        public string Phone { get; set; }
    }
}

