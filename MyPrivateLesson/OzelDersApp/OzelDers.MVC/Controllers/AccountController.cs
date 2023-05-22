using System;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OzelDers.Business.Abstract;
using OzelDers.Core;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;
using OzelDers.MVC.EmailServices;
using OzelDers.MVC.Models.ViewModels;
using OzelDers.MVC.Models.ViewModels.AccountModels;
using OzelDers.MVC.Models.ViewModels.CartModels;

namespace OzelDers.MVC.Controllers
{
	public class AccountController :Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly ICartService _cartService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly IBranchService _branchService;
        private readonly IOrderService _orderService;
        private readonly IEmailSender _emailSender;
        private readonly INotyfService _notyfService;



        public AccountController(UserManager<User> userManager,IOrderService orderService, IEmailSender emailSender, SignInManager<User> signInManager, ICartService cartService , IStudentService studentService,ITeacherService teacherService, IBranchService branchService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cartService = cartService;
            _studentService = studentService;
            _teacherService = teacherService;
            _branchService = branchService;
            _orderService = orderService;
            _emailSender = emailSender;
        }


        #region Öğrenci kayıt Ol
        [HttpGet]
        public IActionResult StudentRegister()
        {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> StudentRegister(StudentRegisterViewModel studentregisterViewModel )
        {
            if (ModelState.IsValid)
            {
                if (true)
                {
                    User user = new User
                    {
                        UserName = studentregisterViewModel.UserName,
                        Email = studentregisterViewModel.Email,
                        FirstName = studentregisterViewModel.FirstName,
                        LastName=studentregisterViewModel.LastName,
                        Gender = studentregisterViewModel.Gender,
                        DateOfBirth = studentregisterViewModel.DateOfBirth,
                        City = studentregisterViewModel.City,
                        Phone = studentregisterViewModel.Phone,
                        Image = new Image
                        {
                            CreatedDate = DateTime.Now,
                            UpdatedDate = DateTime.Now,
                            IsApproved = true,
                            Url = Jobs.UploadImage(studentregisterViewModel.Image)
                        }
                    };

                    var result = await _userManager.CreateAsync(user, studentregisterViewModel.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "OGRENCI");
                        await _cartService.InitializeCart(user.Id);

                        Student student = new Student
                        {
                            CreatedDate = DateTime.Now,
                            UpdatedDate = DateTime.Now,
                            User = user,
                            IsApproved=true,
                            UserId=user.Id,
                            Url = Jobs.GetUrl(studentregisterViewModel.FirstName + studentregisterViewModel.LastName),
                            
                        };
                        await _studentService.CreateStudent(student );

                        TempData["Message"] = Jobs.CreateMessage("Kayıt İşlemi", "Öğrenci Kaydınız Başarıyla gerçekleşmiştir.", "success");

                        return RedirectToAction("Login", "Account");

                    }
                } 
            }
            TempData["Message"] = Jobs.CreateMessage("Hata", "Öğrenci Kayıt sırasında bir hata oluştu,lütfen tekrar deneyiniz.", "danger");
            return View(studentregisterViewModel) ;
        }
        #endregion

        #region Öğretmen Kayıt ol
        [HttpGet]
        public async Task<IActionResult> TeacherRegister()
        {
            TeacherRegisterViewModel teacherRegisterViewModel = new TeacherRegisterViewModel
            {
                Branches = await _branchService.GetBranchesAsync(true)

            };
            return View(teacherRegisterViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> TeacherRegister(TeacherRegisterViewModel teacherRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                
                    User user = new User
                    {
                        UserName = teacherRegisterViewModel.UserName,
                        Email = teacherRegisterViewModel.Email,
                        FirstName = teacherRegisterViewModel.FirstName,
                        LastName= teacherRegisterViewModel.LastName,
                        Gender = teacherRegisterViewModel.Gender,
                        DateOfBirth = teacherRegisterViewModel.DateOfBirth,
                        City = teacherRegisterViewModel.City,
                        Phone = teacherRegisterViewModel.Phone,
                        Image = new Image
                        {

                            CreatedDate = DateTime.Now,
                            UpdatedDate = DateTime.Now,
                            IsApproved = true,
                            Url = Jobs.UploadImage(teacherRegisterViewModel.Image)
                        }
                    };


                var result = await _userManager.CreateAsync(user, teacherRegisterViewModel.Password);

                if (result.Succeeded)
                    {
                        
                        await _userManager.AddToRoleAsync(user, "OGRETMEN");
                        await _cartService.InitializeCart(user.Id);

                        Teacher teacher = new Teacher
                        {
                            CreatedDate = DateTime.Now,
                            UpdatedDate = DateTime.Now,
                            Graduation = teacherRegisterViewModel.Graduation,
                            User = user,
                            IsApproved = true,
                            UserId = user.Id,
                            Url = Jobs.GetUrl(teacherRegisterViewModel.FirstName + teacherRegisterViewModel.LastName),
               

                        };

                        await _teacherService.CreateTeacher(teacher, teacherRegisterViewModel.SelectedBranches);
                    TempData["Message"] = Jobs.CreateMessage("Kayıt İşlemi", "Öğretmen Kaydınız Başarıyla gerçekleşmiştir.", "success");

                    return RedirectToAction("Login", "Account");
                    }
                

            }
            teacherRegisterViewModel.Branches = await _branchService.GetBranchesAsync(true);
            TempData["Message"] = Jobs.CreateMessage("Kayıt İşlemi", "Öğretmen Kayıt sırasında bir hata oluştu,lütfen tekrar deneyiniz.", "danger");
            return View(teacherRegisterViewModel);
        }
        #endregion


        #region Giriş Yap

        [HttpGet]
        public IActionResult Login(string returnUrl=null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(loginViewModel.UserName);

                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı Bilgileri Hatalı!");
                    return View(loginViewModel);
                }
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, isPersistent: true, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    return Redirect(loginViewModel.ReturnUrl ?? "/");
                }
                ModelState.AddModelError("", "Kullanıcı adı ya da Parola hatalı");
            }
            return View(loginViewModel);
        }

        #endregion


        #region Çıkış Yap

        public async  Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Profil Düzenleme
        [HttpGet]
        public async Task<IActionResult> Manage(string id)
        {
            string name = id;

            if (String.IsNullOrEmpty(name))
            {
                return NotFound();
            }

            User user = await _userManager.FindByNameAsync(name);

            if (User == null)
            {
                return NotFound();
            }

            List<SelectListItem> genderList = new List<SelectListItem>();

            genderList.Add(new SelectListItem
            {
                Text = "Kadın",
                Value = "Kadın",
                Selected = user.Gender == "Kadın" ? true : false
            });

            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
                Selected = user.Gender == "Erkek" ? true : false
            });
            UserManageViewModel userManageViewModel = new UserManageViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                UserName = user.UserName,
                City = user.City,
                Email = user.Email,
                GenderSelectList = genderList,
            };

            var orderList = await _orderService.GetAllOrdersAsync(user.Id);
            List<OrderViewModel> orders = orderList.Select(o => new OrderViewModel
            {
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                City = o.City,
                Email = o.Email,
                Phone = o.Phone,
                //OrderDate = o.OrderDate,
                //OrderItems = o.OrderItems.Select(oi => new CartItemViewModel
                //{
                //    CartItemId = oi.Id,
                //    AdvertId=oi.AdvertId,
                //    TeacherName = oi.Order.FirstName + oi.Order.LastName,
                //    TeacherGraduation=oi.Advert.Teacher.Graduation,
                //    TeacherUrl=oi.Advert.Teacher.Url,
                //    BranchName=oi.Advert.Branch.BranchName,
                //    ItemPrice = oi.Price,
                //    Amount = oi.Amount,
                //    Description=oi.Advert.Description,
                //    ImageUrl = oi.Order.User.Image.Url,
                //}).ToList()
            }).ToList();

            userManageViewModel.Orders = orders;
            return View(userManageViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(UserManageViewModel userManageViewModel)
        {
            if (userManageViewModel == null) { return NotFound(); }
            User user = await _userManager.FindByIdAsync(userManageViewModel.Id);
            bool logOut = !(user.UserName == userManageViewModel.UserName);
            user.FirstName = userManageViewModel.FirstName;
            user.LastName = userManageViewModel.LastName;
            user.Gender = userManageViewModel.Gender;
            user.UserName = userManageViewModel.UserName;
            user.City = userManageViewModel.City;
            user.Email = userManageViewModel.Email;
            user.DateOfBirth = userManageViewModel.DateOfBirth;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                if (logOut)
                {

                    TempData["Message"] = Jobs.CreateMessage("Başarılı", "Profiliniz başarıyla güncellenmiştir. Kullanıcı adınız değiştiği için yeniden giriş yapmalısınız!", "warning");
                    return RedirectToAction("Logout");
                }
                TempData["Message"] = Jobs.CreateMessage("Başarılı", "Profiliniz başarıyla güncellenmiştir.", "success");
                return Redirect("/Account/Manage/" + user.UserName);
            }

            List<SelectListItem> genderList = new List<SelectListItem>();
            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
                Selected = user.Gender == "Erkek" ? true : false
            });

            userManageViewModel.GenderSelectList = genderList;

            return View(userManageViewModel);
        }

        #endregion


        #region
        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            if (userId==null || token == null)
            {
                return View();
            }
            User user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    //Eğer email onayını kullanıyorsak role atama ve cart oluşturma burada yapılır.
                    TempData["Message"] = Jobs.CreateMessage("Başarılı", "Profiliniz başarıyla onaylanmıştır. Güvenli alışverişler!", "success");
                    return View();
                }
            }
            TempData["Message"] = Jobs.CreateMessage("HATA", "Profiliniz onaylanırken bir hata oluştu, detaylı bilgi için 0212 645 25 25'i arayınız.", "danger");
            return View();
        }
        #endregion

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                TempData["Message"] = Jobs.CreateMessage("HATA!", "Lütfen mail adresinizi yazınızı!", "warning");
                return View();
            }
            User user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                TempData["Message"] = Jobs.CreateMessage("HATA!", "Böyle bir kullanıcı bulunamadı! Lütfen kontrol ederek yeniden deneyiniz!", "warning");
                return View();
            }
            string code = await _userManager.GeneratePasswordResetTokenAsync(user);
            string url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = code
            });
            await _emailSender.SendEmailAsync(
                email,
                "OzelDersApp Şifre Sıfırlama!",
                $"Parolanızı yeniden belirlemek için <a href='http://localhost:5265{url}'>tıklayınız</a>"
                );
            TempData["Message"] = Jobs.CreateMessage(
                "BİLGİLENDİRME!",
                "Lütfen mail adresinize gelen maili kontrol edip, yönergeleri takip ederek parolanızı yeniden belirlemeyi deneyiniz!",
                "warning");
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData["Message"] = Jobs.CreateMessage(
                    "Geçersiz İşlem!",
                    "Beklenmedik bir hata oluştu, lütfen defolun!",
                    "warning");
                return Redirect("/");
            }
            ResetPasswordViewModel resetPasswordViewModel = new ResetPasswordViewModel
            {
                Token = token
            };
            return View(resetPasswordViewModel);
        }

        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (!ModelState.IsValid) { return View(resetPasswordViewModel); }
            User user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);
            if (user == null)
            {
                TempData["Message"] = Jobs.CreateMessage(
                    "Hata!",
                    "Kullanıcı bilgisi bulunamadı, lütfen tekrar deneyiniz!",
                    "warning");
                return Redirect("/");
            }
            var result = await _userManager.ResetPasswordAsync(user, resetPasswordViewModel.Token, resetPasswordViewModel.Password);
            if (result.Succeeded)
            {
                TempData["Message"] = Jobs.CreateMessage(
                    "Başarılı!",
                    "Parolanız, başarıyla değiştirilmiştir! Giriş yapmayı deneyebilirsiniz.",
                    "success");
                return RedirectToAction("Login");
            }
            TempData["Message"] = Jobs.CreateMessage(
                "Bir sorun oluştu!",
                "Beklenmedik bir sorun oluştu, kesin Canan'dan kaynaklıdır!",
                "danger");
            return View(resetPasswordViewModel);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}

