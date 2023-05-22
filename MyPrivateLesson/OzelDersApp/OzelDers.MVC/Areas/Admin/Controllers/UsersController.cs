using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OzelDers.Entity.Concrete.Identity;
using OzelDers.MVC.Areas.Admin.Models.ViewModels.Accounts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OzelDers.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UsersController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            List<UserViewModel> users = await _userManager.Users.Select(u => new UserViewModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                Email = u.Email,
                Phone = u.Phone,
                City = u.City,
            }).ToListAsync();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) { return NotFound(); }

            UserUpdateViewModel userUpdateViewModel = new UserUpdateViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                SelectedRoles = await _userManager.GetRolesAsync(user),
                Roles = _roleManager.Roles.Select(r => new RoleViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description
                }).ToList()
            };
            return View(userUpdateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateViewModel userUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(userUpdateViewModel.Id);
                if (user == null) { return NotFound(); }
                user.FirstName = userUpdateViewModel.FirstName;
                user.LastName = userUpdateViewModel.LastName;
                user.UserName = userUpdateViewModel.UserName;
                user.Email = userUpdateViewModel.Email;
                user.EmailConfirmed = userUpdateViewModel.EmailConfirmed;

                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded) { return NotFound(); }

                var userRoles = await _userManager.GetRolesAsync(user);

                await _userManager.AddToRolesAsync(
                    user,
                    userUpdateViewModel.SelectedRoles.Except(userRoles).ToList<string>());

                await _userManager.RemoveFromRolesAsync(
                    user,
                    userRoles.Except(userUpdateViewModel.SelectedRoles).ToList<string>());

                return RedirectToAction("Index", "Users");
            }
            userUpdateViewModel.Roles = _roleManager.Roles.Select(r => new RoleViewModel
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).ToList();
            return View(userUpdateViewModel);
        }

        public async Task<IActionResult> ConfirmEmail(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            user.EmailConfirmed = !user.EmailConfirmed;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Users");
        }
    }
}

