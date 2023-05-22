using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OzelDers.Business.Abstract;
using OzelDers.Core;
using OzelDers.Entity.Concrete;
using OzelDers.MVC.Areas.Admin.Models.ViewModels.Branches;
using OzelDers.MVC.Areas.Admin.Models.ViewModels.Teachers;


namespace OzelDers.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BranchesController : Controller
    {

        private readonly IBranchService _branchService;
        //private readonly INotyfService _notyfService;

        public BranchesController(IBranchService branchService  /*INotyfService notyfService*/)
        {
            _branchService = branchService;
            //_notyfService = notyfService;
        }

        #region Listeleme

        public async Task<IActionResult> Index(BranchListViewModel branchListViewModel)
        {
            List<Branch> branchList = await _branchService.GetAllBranchesFullDataAsync(branchListViewModel.ApprovedStatus);
            List<BranchViewModel> branches = new List<BranchViewModel>();
            foreach (var branch in branchList)
            {
                branches.Add(new BranchViewModel
                {
                    Id = branch.Id,
                    BranchName = branch.BranchName,
                    Description = branch.Description,
                    CreatedDate = branch.CreatedDate,
                    UpdatedDate = branch.UpdatedDate,
                    IsApproved = branch.IsApproved,
                    Url = branch.Url,
                    Teachers = branch.TeacherBranches.Select(tb => new TeacherViewModel
                    {
                        Id = tb.TeacherId,
                        User = tb.Teacher.User,
                        FirstName = tb.Teacher.User.FirstName,
                        LastName = tb.Teacher.User.LastName,
                        Url = tb.Teacher.Url,


                    }).ToList()


                });


            }
            branchListViewModel.Branches = branches;

            return View(branchListViewModel);
        }
        #endregion

        #region Yeni Kayıt

        [HttpGet]

        public IActionResult Create()
        {
            BranchAddViewModel branchAddViewModel = new BranchAddViewModel();
            return View(branchAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BranchAddViewModel branchAddViewModel)
        {
            if (ModelState.IsValid)
            {
                Branch branch = new Branch
                {

                    BranchName = branchAddViewModel.BranchName,
                    Description = branchAddViewModel.Description,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Url = Jobs.GetUrl(branchAddViewModel.BranchName),
                    IsApproved = true

                };
                await _branchService.CreateAsync(branch);
                //_notyfService.Success($"{branch.BranchName} branşı eklenmiştir.");
                return RedirectToAction("Index");
            }
            return View(branchAddViewModel);

        }

        #endregion

        #region Kayıt Güncelleme

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            Branch branch = await _branchService.GetBranchFullDataAsync(id);
            BranchUpdateViewModel branchUpdateViewModel = new BranchUpdateViewModel
            {
                Id = branch.Id,
                BranchName = branch.BranchName,
                Description = branch.Description,
                UpdateDate = DateTime.Now,
                Url = branch.Url,
                IsApproved = branch.IsApproved
            };

            return View(branchUpdateViewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(BranchUpdateViewModel branchUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                Branch branch = await _branchService.GetBranchFullDataAsync(branchUpdateViewModel.Id);
                branch.BranchName = branchUpdateViewModel.BranchName;
                branch.Description = branchUpdateViewModel.Description;
                branch.Url = Jobs.GetUrl(branchUpdateViewModel.BranchName);
                branch.IsApproved = branchUpdateViewModel.IsApproved;
                branch.UpdatedDate = DateTime.Now;


                _branchService.Update(branch);
                return RedirectToAction("Index");


            }
            return View(branchUpdateViewModel);
        }

        #endregion

        #region Kayıt Silme

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Branch deletedBranch = await _branchService.GetByIdAsync(id);
            BranchViewModel branchViewModel = new BranchViewModel
            {
                Id = deletedBranch.Id,
                BranchName = deletedBranch.BranchName,
                Description = deletedBranch.Description,
            };
            return View(branchViewModel);

        }

        public async Task<IActionResult> Delete(BranchViewModel branchViewModel)
        {
            Branch deletedBranch = await _branchService.GetBranchFullDataAsync(branchViewModel.Id);
            if (deletedBranch != null)
            {
                _branchService.Delete(deletedBranch);
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Onaylı
        public async Task<IActionResult> UpdateIsApproved(int id, bool ApprovedStatus)
        {
            Branch branch = await _branchService.GetByIdAsync(id);
            if (branch != null)
            {
                branch.IsApproved = !branch.IsApproved;
                _branchService.Update(branch);
            }
            BranchListViewModel branchListViewModel = new BranchListViewModel
            {
                ApprovedStatus = ApprovedStatus
            };
            return RedirectToAction("Index", branchListViewModel);
        }
        #endregion

    }
}


