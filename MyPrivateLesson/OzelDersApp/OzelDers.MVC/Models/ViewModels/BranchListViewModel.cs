using System;
namespace OzelDers.MVC.Models.ViewModels
{
	public class BranchListViewModel
	{
		public List<BranchViewModel> Branches { get; set; }
        public bool ApprovedStatus { get; set; } = true;
    }
}

