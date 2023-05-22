using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Data.Concrete.EfCore.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region Rol Bilgileri

            List<Role> roles = new List<Role>()
            {
                new Role{Name="Admin", Description="Yöneticiler",NormalizedName="ADMIN" },
                new Role{Name="Ogretmen", Description="Öğretmenler", NormalizedName="OGRETMEN"},
                new Role {Name="Ogrenci", Description="Öğrenciler", NormalizedName="OGRENCI"}
            };
            modelBuilder.Entity<Role>().HasData(roles);

            #endregion

            #region Kullanıcı Bilgileri

            List<User> users = new List<User>()
            {
                //Admin
                new User {FirstName="Arda", LastName="Ozbek", UserName="ardaozbek", NormalizedUserName="ARDAOZBEK", Email="ardaozbek@hotmail.com", NormalizedEmail="ARDAOZBEK@HOTMAIL.COM", Gender="Erkek", DateOfBirth= new DateTime(2000,8,11), City="Kocaeli",Phone = "5555555555",EmailConfirmed=true,ImageId = 5},
                //Students
                new User {FirstName="Canan", LastName="Umac", UserName="cananumac", NormalizedUserName="CANANUMAC", Email="cananumac@hotmail.com", NormalizedEmail="CANANUMAC@HOTMAIL.COM", Gender="Kadın", DateOfBirth= new DateTime(2007,5,18), City="İstanbul",Phone = "5396542513",EmailConfirmed=true,ImageId = 5 },

                new User {FirstName="Erdi", LastName="Utku", UserName="erdiutku", NormalizedUserName="ERDIUTKU", Email="erdiutku@gmail.com", NormalizedEmail="ERDIUTKU@GMAİL.COM", Gender="Erkek", DateOfBirth= new DateTime(2002,5,8), City="Ankara",Phone = "5551234567",EmailConfirmed=true, ImageId = 5},

                new User {FirstName="Ayşe", LastName="Demir", UserName="aysedemir", NormalizedUserName="AYSEDEMIR", Email="ayse.demir@yahoo.com", NormalizedEmail="AYSE.DEMIR@YAHOO.COM", Gender="Kadın", DateOfBirth= new DateTime(2001,9,13), City="İzmir",Phone = "5329876543",EmailConfirmed=true, ImageId = 5},

                new User {FirstName="Mehmet", LastName="Kaya", UserName="mehmetkaya", NormalizedUserName="MEHMETKAYA", Email="mehmetkaya@hotmail.com", NormalizedEmail="MEHMETKAYA@HOTMAIL.COM", Gender="Erkek", DateOfBirth= new DateTime(2009,12,18), City="Bursa",Phone = "5396542513",EmailConfirmed=true, ImageId = 5},

                new User {FirstName="Fatma", LastName="Şahin", UserName="fatmasahin", NormalizedUserName="FATMASAHIN", Email="fatmasahin@gmail.com", NormalizedEmail="FATMASAHIN@GMAIL.COM", Gender="Kadın", DateOfBirth= new DateTime(2003,3,13), City="Adana",Phone = "5334567890",EmailConfirmed=true, ImageId = 5},

                new User {FirstName="Emre", LastName="Akın", UserName="emreakin", NormalizedUserName="EMREAKIN", Email="emreakin@hotmail.com", NormalizedEmail="EMREAKIN@HOTMAIL.COM", Gender="Erkek", DateOfBirth= new DateTime(2008,5,18), City="İstanbul",Phone = "5379876543",EmailConfirmed=true, ImageId = 5},

                new User {FirstName="Zeynep", LastName="Türk", UserName="zeynepturk", NormalizedUserName="ZEYNEPTURK", Email="zeynepturk@gmail.com", NormalizedEmail="ZEYNEPTURK@GMAIL.COM", Gender="Kadın", DateOfBirth= new DateTime(2005,7,16), City="Ankara",Phone = "5336549872",EmailConfirmed=true, ImageId = 5},

                new User {FirstName="Ali", LastName="Yıldız", UserName="aliyildiz", NormalizedUserName="ALIYILDIZ", Email="ali.yildiz@gmail.com", NormalizedEmail="ALI.YILDIZ@GMAIL.COM", Gender="Erkek", DateOfBirth= new DateTime(2007,11,1), City="İzmir",Phone = "5559876543",EmailConfirmed=true, ImageId = 5},

                new User {FirstName="Mustafa", LastName="Özkan", UserName="mustafaozkan", NormalizedUserName="MUSTAFAOZKAN", Email="mustafaozkan@gmail.com", NormalizedEmail="MUSTAFAOZKAN@GMAIL.COM", Gender="Erkek", DateOfBirth= new DateTime(2009,4,11), City="Antalya",Phone = "5423456789",EmailConfirmed=true, ImageId = 5},

                new User {FirstName="Esra", LastName="Aydın", UserName="esraaydin", NormalizedUserName="ESRAAYDIN", Email="esraaydin@hotmail.com", NormalizedEmail="ESRAAYDIN@HOTMAIL.COM", Gender="Kadın", DateOfBirth= new DateTime(2008,1,6), City="İstanbul",Phone = "5397891234",EmailConfirmed=true, ImageId = 5},


                //Teachers

                new User {FirstName="Selin", LastName="Kar", UserName="selinkar", NormalizedUserName="SELINKAR", Email="selinkar@hotmail.com", NormalizedEmail="SELINKAR@HOTMAIL.COM", Gender="Kadın", DateOfBirth= new DateTime(1980,9,6), City="Bursa",Phone = "5399782513",EmailConfirmed=true, ImageId=1},

                new User {FirstName="Cem", LastName="Yılmaz", UserName="cemyilmaz", NormalizedUserName="CEMYILMAZ", Email="cem.yilmaz@gmail.com", NormalizedEmail="CEM.YILMAZ@GMAIL.COM", Gender="Erkek", DateOfBirth= new DateTime(1990,2,27), City="Ankara",Phone = "5323456789",EmailConfirmed=true, ImageId=1},

                new User {FirstName="Şevval", LastName="Demir", UserName="sevvaldemir", NormalizedUserName="SEVVALDEMIR", Email="esraaydin@hotmail.com", NormalizedEmail="sevval.demir@hotmail.com", Gender="Kadın", DateOfBirth= new DateTime(1992,9,2), City="İstanbul",Phone = "5387891234",EmailConfirmed=true, ImageId=1},

                new User {FirstName="Mehmet", LastName="Yıldız", UserName="mehmetyildiz", NormalizedUserName="MEHMETYILDIZ", Email="mehmet.yildiz@gmail.com", NormalizedEmail="MEHMET.YILDIZ@GMAIL.COM", Gender="Erkek", DateOfBirth= new DateTime(1994,10,26), City="İzmir",Phone = "5336549876",EmailConfirmed=true, ImageId=1},

                new User {FirstName="Gül", LastName="Şahin", UserName="gulsahin", NormalizedUserName="GULSAHIN", Email="gul.sahin@hotmail.com", NormalizedEmail="GUL.SAHIN@HOTMAIL.COM", Gender="Kadın", DateOfBirth= new DateTime(1980,12,4), City="Antalya",Phone = "5361234567",EmailConfirmed=true, ImageId=1},

                 new User {FirstName="Kemal", LastName="Kaya", UserName="kemalkaya", NormalizedUserName="KEMALKAYA", Email="kemal.kaya@gmail.com", NormalizedEmail="KEMAL.KAYA@GMAIL.COM", Gender="Erkek", DateOfBirth= new DateTime(1987,5,25), City="Kayseri",Phone = "5359876543",EmailConfirmed=true, ImageId=1},

                new User {FirstName="Gökhan", LastName="Aydın", UserName="gokhanaydin", NormalizedUserName="GOKHANAYDIN", Email="gokhan.aydin@gmail.com", NormalizedEmail="GOKHAN.AYDIN@GMAIL.COM", Gender="Erkek", DateOfBirth= new DateTime(1990,3,17), City="Adana",Phone = "5321234567",EmailConfirmed=true, ImageId=1},

                new User {FirstName="Şeyma", LastName="Yılmaz", UserName="seymayilmaz", NormalizedUserName="SEYMAYILMAZ", Email="seyma.yilmaz@hotmail.com", NormalizedEmail="SEYMA.YILMAZ@HOTMAIL.COM", Gender="Kadın", DateOfBirth= new DateTime(1992,11,7), City="Bursa",Phone = "5399876543",EmailConfirmed=true, ImageId=1}
            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion

            #region Öğrenci Bilgileri


            List<Student> students = new List<Student>() {
            new Student{
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[1].Id
                },
                new Student
                {
                    Id = 2,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[2].Id
                },
                new Student
                {
                    Id = 3,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[3].Id
                },
                new Student
                {
                    Id = 4,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[4].Id
                },
                new Student
                {
                    Id = 5,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[5].Id
                },
                new Student
                {
                    Id = 6,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[6].Id
                },
                new Student
                {
                    Id = 7,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[7].Id
                },
                new Student
                {
                    Id = 8,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[8].Id

                },
                new Student
                {
                    Id = 9,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[9].Id
                },
                new Student
                {
                    Id = 10,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    UserId=users[10].Id
                }
            };
            modelBuilder.Entity<Student>().HasData(students);
            #endregion

            #region Öğretmen Bİlgileri

            List<Teacher> teachers = new List<Teacher>()
            {
                 new Teacher
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Graduation = "Çanakkale Onsekiz Mart Üniversitesi",
                    UserId=users[11].Id
                },
                new Teacher
                {
                    Id = 2,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Graduation = "Orta Doğu Teknik Üniversitesi",
                    UserId=users[12].Id
                },
                new Teacher
                {
                    Id = 3,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Graduation = "İstanbul Teknik Üniversitesi",
                    UserId=users[13].Id
                },
                new Teacher
                {
                    Id = 4,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Graduation = "Ege Üniversitesi",
                    UserId=users[14].Id
                },
                new Teacher
                {
                    Id = 5,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Graduation = "Akdeniz Üniversitesi",
                    UserId=users[15].Id
                },
                new Teacher
                {
                    Id = 6,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Graduation = "Erciyes Üniversitesi",
                    UserId=users[16].Id
                },
                new Teacher
                {
                    Id = 7,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Graduation = "Çukurova Üniversitesi",
                    UserId=users[17].Id
                },
                new Teacher
                {
                    Id = 8,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Graduation = "Uludağ Üniversitesi",
                    UserId=users[18].Id
                }
            };
            modelBuilder.Entity<Teacher>().HasData(teachers);

            #endregion


            #region Parola İşlemleri
            var passwordHasher = new PasswordHasher<User>();
            //Admin

            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");

            //Student

            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Qwe123.");
            users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Qwe123.");
            users[3].PasswordHash = passwordHasher.HashPassword(users[3], "Qwe123.");
            users[4].PasswordHash = passwordHasher.HashPassword(users[4], "Qwe123.");
            users[5].PasswordHash = passwordHasher.HashPassword(users[5], "Qwe123.");
            users[6].PasswordHash = passwordHasher.HashPassword(users[6], "Qwe123.");
            users[7].PasswordHash = passwordHasher.HashPassword(users[7], "Qwe123.");
            users[8].PasswordHash = passwordHasher.HashPassword(users[8], "Qwe123.");
            users[9].PasswordHash = passwordHasher.HashPassword(users[9], "Qwe123.");
            users[10].PasswordHash = passwordHasher.HashPassword(users[10], "Qwe123.");

            //Teacher

            users[11].PasswordHash = passwordHasher.HashPassword(users[11], "Qwe123.");
            users[12].PasswordHash = passwordHasher.HashPassword(users[12], "Qwe123.");
            users[13].PasswordHash = passwordHasher.HashPassword(users[13], "Qwe123.");
            users[14].PasswordHash = passwordHasher.HashPassword(users[14], "Qwe123.");
            users[15].PasswordHash = passwordHasher.HashPassword(users[15], "Qwe123.");
            users[16].PasswordHash = passwordHasher.HashPassword(users[16], "Qwe123.");
            users[17].PasswordHash = passwordHasher.HashPassword(users[17], "Qwe123.");
            users[18].PasswordHash = passwordHasher.HashPassword(users[18], "Qwe123.");

            #endregion

            #region Rol Atama İşlemleri

            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>{UserId=users[0].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Admin").Id },

                new IdentityUserRole<string>{UserId=users[1].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Ogrenci").Id },
                new IdentityUserRole<string>{UserId=users[2].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Ogrenci").Id },
                new IdentityUserRole<string>{UserId=users[3].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Ogrenci").Id },
                new IdentityUserRole<string>{UserId=users[4].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Ogrenci").Id },
                new IdentityUserRole<string>{UserId=users[5].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Ogrenci").Id },
                new IdentityUserRole<string>{UserId=users[6].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Ogrenci").Id },
                new IdentityUserRole<string>{UserId=users[7].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Ogrenci").Id },
                new IdentityUserRole<string>{UserId=users[8].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Ogrenci").Id },
                new IdentityUserRole<string>{UserId=users[9].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Ogrenci").Id },
                new IdentityUserRole<string>{UserId=users[10].Id, RoleId= roles.FirstOrDefault(r=> r.Name == "Ogrenci").Id },

                new IdentityUserRole<string>{UserId=users[11].Id,RoleId= roles.FirstOrDefault(r=>r.Name=="Ogretmen").Id},
                new IdentityUserRole<string>{UserId=users[12].Id,RoleId= roles.FirstOrDefault(r=>r.Name=="Ogretmen").Id},
                new IdentityUserRole<string>{UserId=users[13].Id,RoleId= roles.FirstOrDefault(r=>r.Name=="Ogretmen").Id},
                new IdentityUserRole<string>{UserId=users[14].Id,RoleId= roles.FirstOrDefault(r=>r.Name=="Ogretmen").Id},
                new IdentityUserRole<string>{UserId=users[15].Id,RoleId= roles.FirstOrDefault(r=>r.Name=="Ogretmen").Id},
                new IdentityUserRole<string>{UserId=users[16].Id,RoleId= roles.FirstOrDefault(r=>r.Name=="Ogretmen").Id},
                new IdentityUserRole<string>{UserId=users[17].Id,RoleId= roles.FirstOrDefault(r=>r.Name=="Ogretmen").Id},
                new IdentityUserRole<string>{UserId=users[18].Id,RoleId= roles.FirstOrDefault(r=>r.Name=="Ogretmen").Id},
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion


            #region AlışVeriş Sepeti İşlemleri
            List<Cart> carts = new List<Cart>
            {
                new Cart{Id=1, UserId=users[0].Id},
                new Cart{Id=2, UserId=users[1].Id},
                new Cart{Id=3, UserId=users[2].Id},
                new Cart{Id=4, UserId=users[3].Id},
                new Cart{Id=5, UserId=users[4].Id},
                new Cart{Id=6, UserId=users[5].Id},
                new Cart{Id=7, UserId=users[6].Id},
                new Cart{Id=8, UserId=users[7].Id},
                new Cart{Id=9, UserId=users[8].Id},
                new Cart{Id=10, UserId=users[9].Id},
                new Cart{Id=11, UserId=users[10].Id},
                new Cart{Id=12, UserId=users[11].Id},
                new Cart{Id=13, UserId=users[12].Id},
                new Cart{Id=14, UserId=users[13].Id},
                new Cart{Id=15, UserId=users[14].Id},
                new Cart{Id=16, UserId=users[15].Id},
                new Cart{Id=17, UserId=users[16].Id},
                new Cart{Id=18, UserId=users[17].Id},
                new Cart{Id=19, UserId=users[18].Id},
            };
            modelBuilder.Entity<Cart>().HasData(carts);

            #endregion

            List<Advert> adverts = new List<Advert>()
            {
                new Advert{Id=1, TeacherId= 4, Description="dsdasd", Price=45, CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true, Url="dsdds", BranchId=4 }
            };
            modelBuilder.Entity<Advert>().HasData(adverts);

        }
    }
}
