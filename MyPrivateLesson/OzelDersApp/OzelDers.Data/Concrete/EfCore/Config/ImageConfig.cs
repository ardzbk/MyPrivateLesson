using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Concrete.EfCore.Config
{
	public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Property(i => i.CreatedDate).IsRequired();
            builder.Property(i => i.UpdatedDate).IsRequired();
            //builder.HasOne(t => t.User).WithOne(t => t.Image).HasForeignKey<Image>(t => t.UserId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(

                new Image { Id = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsApproved = true, Url = "teacher-1.jpg" },
                new Image { Id = 2 ,CreatedDate=DateTime.Now , UpdatedDate = DateTime.Now,IsApproved=true, Url = "teacher-2.jpg" },
                new Image { Id = 3 ,CreatedDate=DateTime.Now , UpdatedDate = DateTime.Now,IsApproved=true, Url = "teacher-3.jpg" },
                new Image { Id = 4 ,CreatedDate=DateTime.Now , UpdatedDate = DateTime.Now,IsApproved=true, Url = "teacher-4.jpg" },
                new Image { Id = 5 ,CreatedDate=DateTime.Now , UpdatedDate = DateTime.Now,IsApproved=true, Url = "teacher-5.jpg" }
                );
        }
    }
}

