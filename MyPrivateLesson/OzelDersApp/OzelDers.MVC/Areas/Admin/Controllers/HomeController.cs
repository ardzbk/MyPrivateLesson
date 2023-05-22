using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OzelDers.Business.Abstract;
using OzelDers.Entity.Concrete.Identity;
using OzelDers.MVC.Areas.Admin.Models.ViewModels;
using OzelDers.MVC.Areas.Admin.Models.ViewModels.Accounts;
using OzelDers.MVC.Models.ViewModels;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OzelDers.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize()]
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;

        private readonly RoleManager<Role> _roleManager;

        public HomeController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserViewModel userViewModel = new UserViewModel
            {
                City = user.City,
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email

            };
            return View(userViewModel);
        }

    }
}

