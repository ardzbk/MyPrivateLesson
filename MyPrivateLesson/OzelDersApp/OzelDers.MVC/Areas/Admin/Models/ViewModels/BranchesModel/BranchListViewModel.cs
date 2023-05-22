using System;
namespace OzelDers.MVC.Areas.Admin.Models.ViewModels.Branches
{
	public class BranchListViewModel
	{

        public List<BranchViewModel> Branches { get; set; }

        public bool ApprovedStatus { get; set; } = true;
    }
}

