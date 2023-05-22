using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OzelDers.Business.Abstract;
using OzelDers.Core;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;
using OzelDers.MVC.Areas.Admin.Models.ViewModels.Students;
using OzelDers.MVC.Areas.Admin.Models.ViewModels.Teachers;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OzelDers.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StudentsController : Controller
    {

        private IStudentService _studentService;
        private IImageService _imageService;
        private UserManager<User> _userManager;

        public StudentsController(IStudentService studentService, IImageService imageService, UserManager<User> userManager)
        {
            _studentService = studentService;
            _imageService = imageService;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index(StudentListViewModel studentListViewModel)
        {
            List<Student> studentList = await _studentService.GetAllStudentsWithTeachersAsync(studentListViewModel.ApprovedStatus);
            List<StudentViewModel> students = new List<StudentViewModel>();
            foreach (var student in studentList)
            {
                students.Add(new StudentViewModel
                {
                    Id = student.Id,
                    FirstName = student.User.FirstName,
                    LastName = student.User.LastName,
                    Gender = student.User.Gender,
                    Phone = student.User.Phone,
                    City = student.User.City,
                    DateOfBirth = student.User.DateOfBirth,
                    CreatedDate = student.CreatedDate,
                    UpdatedDate = student.UpdatedDate,
                    IsApproved = student.IsApproved,
                    Url = student.Url,
                    UserId = student.UserId,
                    User = student.User,
                    Teachers = student.TeacherStudents.Select(ts => new TeacherViewModel
                    {
                        Id = ts.Teacher.Id,
                        User = ts.Teacher.User,
                        FirstName = ts.Teacher.User.FirstName,
                        LastName = ts.Teacher.User.LastName,
                        Url = ts.Teacher.Url
                    }).ToList(),
                    Image = student.User.Image
                });
            }
            studentListViewModel.Students = students;
            return View(studentListViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            StudentAddViewModel studentAddViewModel = new StudentAddViewModel();
            return View(studentAddViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentAddViewModel studentAddViewModel)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student
                {
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Url = Jobs.GetUrl(studentAddViewModel.FirstName + studentAddViewModel.LastName),
                  
                };
                User user = new User
                {
                    FirstName = studentAddViewModel.FirstName,
                    LastName = studentAddViewModel.LastName,
                    Gender = studentAddViewModel.Gender,
                    DateOfBirth = studentAddViewModel.DateOfBirth,
                    City = studentAddViewModel.City,
                    UserName = studentAddViewModel.UserName,
                    Email = studentAddViewModel.Email,
                    Phone = studentAddViewModel.Phone,
                    Image = new Image
                    {
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        IsApproved = true,
                        Url = Jobs.UploadImage(studentAddViewModel.Image)
                    }
                };
                await _userManager.CreateAsync(user, studentAddViewModel.Password);
                student.User = user;
                await _studentService.CreateAsync(student);
                return RedirectToAction("Index");
            }
            return View(studentAddViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Student student = await _studentService.GetStudentFullDataAsync(id);
            StudentUpdateViewModel studentUpdateViewModel = new StudentUpdateViewModel
            {
                Id = student.Id,
                FirstName = student.User.FirstName,
                LastName = student.User.LastName,
                Gender = student.User.Gender,
                DateOfBirth = student.User.DateOfBirth,
                City = student.User.City,
                Phone = student.User.Phone,
                UserName = student.User.UserName,
                Email = student.User.Email,
                CreatedDate = student.CreatedDate,
                UpdatedDate = DateTime.Now,
                IsApproved = student.IsApproved,
                Image = student.User.Image
            };
            return View(studentUpdateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentUpdateViewModel studentUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                Student student = await _studentService.GetStudentFullDataAsync(studentUpdateViewModel.Id);
                student.User.FirstName = studentUpdateViewModel.FirstName;
                student.User.LastName = studentUpdateViewModel.LastName;
                student.User.Gender = studentUpdateViewModel.Gender;
                student.User.DateOfBirth = studentUpdateViewModel.DateOfBirth;
                student.User.City = studentUpdateViewModel.City;
                student.User.Phone = studentUpdateViewModel.Phone;
                student.UpdatedDate = DateTime.Now;
                student.IsApproved = studentUpdateViewModel.IsApproved;
                student.User.UserName = studentUpdateViewModel.UserName;
                student.User.Email = studentUpdateViewModel.Email;

                if (studentUpdateViewModel.ImageFile != null)
                {
                    student.User.Image = new Image
                    {
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        IsApproved = true,
                        Url = Jobs.UploadImage(studentUpdateViewModel.ImageFile)
                    };
                    await _imageService.CreateAsync(student.User.Image);
                }

                _studentService.Update(student);
                return RedirectToAction("Index");
            }
            return View(studentUpdateViewModel);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Student deletedStudent = await _studentService.GetStudentFullDataAsync(id);
            StudentViewModel studentViewModel = new StudentViewModel
            {
                Id = deletedStudent.Id,
                FirstName = deletedStudent.User.FirstName,
                LastName = deletedStudent.User.LastName,
                Gender = deletedStudent.User.Gender,
                DateOfBirth = deletedStudent.User.DateOfBirth,
                City = deletedStudent.User.City,
                Phone = deletedStudent.User.Phone,
                Image = deletedStudent.User.Image,
            };
            return View(studentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(StudentViewModel studentViewModel)
        {
            Student deletedStudent = await _studentService.GetStudentFullDataAsync(studentViewModel.Id);
            if (deletedStudent != null)
            {
                _studentService.Delete(deletedStudent);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateIsApproved(int id, bool ApprovedStatus)
        {
            Student student = await _studentService.GetByIdAsync(id);
            if (student != null)
            {
                student.IsApproved = !student.IsApproved;
                _studentService.Update(student);
            }
            StudentListViewModel studentListViewModel = new StudentListViewModel()
            {
                ApprovedStatus = ApprovedStatus
            };
            return RedirectToAction("Index", studentListViewModel);
        }

        public async Task<IActionResult> GetStudentsByTeacher(int id)
        {
            List<Student> studentList = await _studentService.GetStudentsByTeacher(id);
            List<StudentViewModel> students = new List<StudentViewModel>();
            foreach (var student in studentList)
            {
                students.Add(new StudentViewModel
                {
                    Id = student.Id,
                    FirstName = student.User.FirstName,
                    LastName = student.User.LastName,
                    Gender = student.User.Gender,
                    Phone = student.User.Phone,
                    City = student.User.City,
                    DateOfBirth = student.User.DateOfBirth,
                    CreatedDate = student.CreatedDate,
                    UpdatedDate = student.UpdatedDate,
                    IsApproved = student.IsApproved,
                    Url = student.Url,
                    UserId = student.UserId,
                    User = student.User,
                    Teachers = student.TeacherStudents.Select(ts => new TeacherViewModel
                    {
                        Id = ts.Teacher.Id,
                        User = ts.Teacher.User,
                        FirstName = ts.Teacher.User.FirstName,
                        LastName = ts.Teacher.User.LastName,
                        Url = ts.Teacher.Url
                    }).ToList(),
                    Image = student.User.Image
                });

            }
            StudentListViewModel studentListViewModel = new StudentListViewModel()
            {
                Students = students,
                ApprovedStatus = true
            };
            return View("Index", studentListViewModel);
        }
    }
}

