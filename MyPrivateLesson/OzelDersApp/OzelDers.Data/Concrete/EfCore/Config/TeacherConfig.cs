using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Concrete.EfCore.Config
{
	public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {

        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.CreatedDate).IsRequired();
            builder.Property(t => t.UpdatedDate).IsRequired();
            builder.Property(t => t.Graduation).IsRequired();
            builder.HasOne(t => t.User).WithOne(t => t.Teacher).HasForeignKey<Teacher>(t => t.UserId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}

