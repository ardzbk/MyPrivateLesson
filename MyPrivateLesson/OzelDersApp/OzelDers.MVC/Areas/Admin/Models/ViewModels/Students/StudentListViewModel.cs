using System;
namespace OzelDers.MVC.Areas.Admin.Models.ViewModels.Students
{
	public class StudentListViewModel
	{
        public List<StudentViewModel> Students { get; set; }
        public bool ApprovedStatus { get; set; } = true;
    }
}

