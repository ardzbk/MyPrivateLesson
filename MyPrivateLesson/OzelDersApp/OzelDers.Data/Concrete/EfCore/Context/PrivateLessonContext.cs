using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OzelDers.Data.Concrete.EfCore.Config;
using OzelDers.Data.Concrete.EfCore.Extensions;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;


namespace OzelDers.Data.Concrete.EfCore.Context
{
	public class PrivateLessonContext : IdentityDbContext<User,Role,string> 
	{
        public PrivateLessonContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }

		public DbSet<Student> Students { get; set; }

		public DbSet<Branch> Branches { get; set; }

		public DbSet<Image> Images { get; set; }

		public DbSet<Cart> Carts { get; set; }

		public DbSet<CartItem> CartItems { get; set; }

		public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<TeacherBranch> TeacherBranches { get; set; }

		public DbSet<TeacherStudent> TeacherStudents { get; set; }

        public DbSet<Advert> Adverts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.SeedData();
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(BranchConfig).Assembly);
			base.OnModelCreating(modelBuilder);

		}
    }
}

