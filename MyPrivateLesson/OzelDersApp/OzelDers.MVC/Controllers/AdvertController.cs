using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OzelDers.Business.Abstract;
using OzelDers.Core;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;
using OzelDers.MVC.Models;
using OzelDers.MVC.Models.ViewModels;

namespace OzelDers.MVC.Controllers
{
    public class AdvertController : Controller
    {
        private IAdvertService _advertService;
        private ITeacherService _teacherService;
        private UserManager<User> _userManager;
        private IBranchService _branchService;

        public AdvertController(IAdvertService advertService, ITeacherService teacherService, UserManager<User> userManager, IBranchService branchService)
        {
            _advertService = advertService;
            _teacherService = teacherService;
            _userManager = userManager;
            _branchService = branchService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index(AdvertListViewModel advertListViewModel)
        {
            List<Advert> advertList;
            if (advertListViewModel.Adverts == null)
            {
                var userId = _userManager.GetUserId(User);
                var teacher = _teacherService.GetTeacherFullDataStringAsync(userId);
                advertList = await _advertService.GetAdvertsFullDataAsync(userId, advertListViewModel.ApprovedStatus);
                List<AdvertViewModel> adverts = new List<AdvertViewModel>();
                foreach (var advert in advertList)
                {
                    adverts.Add(new AdvertViewModel
                    {
                        Id = advert.Id,
                        FirstName = advert.Teacher.User.FirstName,
                        LastName = advert.Teacher.User.LastName,
                        CreatedDate = advert.CreatedDate,
                        UpdatedDate = advert.UpdatedDate,
                        IsApproved = advert.IsApproved,
                        Graduation = advert.Teacher.Graduation,
                        Price = advert.Price,
                        Description = advert.Description,
                        Url = advert.Url,
                        Teacher = advert.Teacher,
                        Image = advert.Teacher.User.Image,
                        BranchName = advert.Branch.BranchName,
                    });
                }
                advertListViewModel.Adverts = adverts;
            }
            return View(advertListViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            int activeBranchId = 0;
            var userId = _userManager.GetUserId(User);
            Teacher teacher = await _teacherService.GetTeacherFullDataStringAsync(userId);
            var branches = await _branchService.GetBranchesByTeacherAsync(teacher.Id);

            AdvertAddViewModel advertAddViewModel = new AdvertAddViewModel()
            {
                Teacher = teacher,
                TeacherId = teacher.Id,
            };

            if (advertAddViewModel.BranchId == 0)
            {
                activeBranchId = branches.FirstOrDefault().Id;
            }
            else
            {
                activeBranchId = advertAddViewModel.BranchId;

            }

            List<SelectListItem> selectBranchList = branches.Select(r => new SelectListItem
            {
                Text = r.BranchName,
                Value = r.Id.ToString(),
                Selected = r.Id == activeBranchId ? true : false
            }).ToList();

            advertAddViewModel.SelectBranchList = selectBranchList;

            return View(advertAddViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdvertAddViewModel advertAddViewModel)
        {
            int activeBranchId = 0;
            var userId = _userManager.GetUserId(User);
            Teacher teacher = await _teacherService.GetTeacherFullDataStringAsync(userId);
            var branches = await _branchService.GetBranchesByTeacherAsync(teacher.Id);
            if (advertAddViewModel.BranchId == 0)
            {
                activeBranchId = branches.FirstOrDefault().Id;
            }
            else
            {
                activeBranchId = advertAddViewModel.BranchId;

            }

            List<SelectListItem> selectBranchList = branches.Select(r => new SelectListItem
            {
                Text = r.BranchName,
                Value = r.Id.ToString(),
                Selected = r.Id == activeBranchId ? true : false
            }).ToList();

            advertAddViewModel.SelectBranchList = selectBranchList;
            if (ModelState.IsValid)
            {
                Advert advert = new Advert()
                {
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Price = advertAddViewModel.Price,
                    Description = advertAddViewModel.Description,
                    TeacherId = teacher.Id,
                    Teacher = teacher,
                    Url = Jobs.GetUrl(advertAddViewModel.Description),
                    BranchId = activeBranchId
                };
                await _advertService.CreateAsync(advert);
                return RedirectToAction("Index");
            }
            return View(advertAddViewModel);
        }

        #region Kayıt Silme
        public async Task<IActionResult> Delete(int id)
        {
            Advert deletedAdvert = await _advertService.GetByIdAsync(id);
            if (deletedAdvert != null)
            {
                _advertService.Delete(deletedAdvert);
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region Kayıt Güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Advert advert = await _advertService.GetByIdAsync(id);
            AdvertUpdateViewModel advertUpdateViewModel = new AdvertUpdateViewModel()
            {
                Id=advert.Id,
                Price=advert.Price,
                Description=advert.Description,
                UpdatedDate=advert.UpdatedDate,
                IsApproved = advert.IsApproved
            };

            return View(advertUpdateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdvertUpdateViewModel advertUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                Advert advert = await _advertService.GetByIdAsync(advertUpdateViewModel.Id);
                advert.Id = advertUpdateViewModel.Id;
                advert.Price = advertUpdateViewModel.Price;
                advert.Description = advertUpdateViewModel.Description;
                advert.UpdatedDate = DateTime.Now;
                advert.IsApproved = advertUpdateViewModel.IsApproved;
                _advertService.Update(advert);

                return RedirectToAction("Index");
            }
            return View(advertUpdateViewModel);
        }

        #endregion
    }
}

