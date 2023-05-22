using System;
namespace OzelDers.MVC.Areas.Admin.Models.ViewModels.Teachers
{
	public class TeacherListViewModel
	{

        public List<TeacherViewModel> Teachers { get; set; }

        public bool IsApproved { get; set; } = true;
    }
}

