using System;
using OzelDers.MVC.Models.ViewModels;

namespace OzelDers.MVC.Models
{
	public class AdvertListViewModel
	{
        public List<AdvertViewModel> Adverts { get; set; }
        public bool ApprovedStatus { get; set; } = true;
    }
}

