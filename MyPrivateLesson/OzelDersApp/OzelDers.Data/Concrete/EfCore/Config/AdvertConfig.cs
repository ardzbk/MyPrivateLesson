using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Concrete.EfCore.Config
{
	public class AdvertConfig : IEntityTypeConfiguration<Advert>
    {
		

        public void Configure(EntityTypeBuilder<Advert> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(t => t.Teacher).WithMany(t => t.Adverts).HasForeignKey(t => t.TeacherId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(t => t.Branch).WithMany(t => t.Adverts).HasForeignKey(t => t.BranchId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

