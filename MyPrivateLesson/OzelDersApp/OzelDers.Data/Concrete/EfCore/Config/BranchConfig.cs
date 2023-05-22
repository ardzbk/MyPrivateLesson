using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Concrete.EfCore.Config
{
	public class BranchConfig :  IEntityTypeConfiguration<Branch>
	{

		public void Configure(EntityTypeBuilder<Branch> builder)
		{
			builder.HasKey(b => b.Id);
			builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.CreatedDate).IsRequired();
            builder.Property(b => b.UpdatedDate).IsRequired();
            builder.Property(b => b.BranchName).IsRequired();

            builder.HasData(
                new Branch
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    BranchName = "Matematik",
                    Description = "Matematik Dersleri",
                    Url = "matematik"
                },
                new Branch
                {
                    Id = 2,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    BranchName = "Fizik",
                    Description = "Fizik Dersleri",
                    Url = "fizik"
                },
                new Branch
                {
                    Id = 3,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    BranchName = "Kimya",
                    Description = "Kimya Dersleri",
                    Url = "kimya"
                },
                new Branch
                {
                    Id = 4,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    BranchName = "Biyoloji",
                    Description = "Biyoloji Dersleri",
                    Url = "biyoloji"
                },
                new Branch
                {
                    Id = 5,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    BranchName = "Tarih",
                    Description = "Tarih Dersleri",
                    Url = "tarih"
                },
                new Branch
                {
                    Id = 6,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    BranchName = "Coğrafya",
                    Description = "Coğrafya Dersleri",
                    Url = "cografya"
                },
                new Branch
                {
                    Id = 7,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    BranchName = "İngilizce",
                    Description = "İngilizce Dersleri",
                    Url = "ingilizce"
                },
                new Branch
                {
                    Id = 8,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    BranchName = "Almanca",
                    Description = "Almanca Dersleri",
                    Url = "almanca"
                },
                new Branch
                {
                    Id = 9,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    BranchName = "Fransızca",
                    Description = "Fransızca Dersleri",
                    Url = "fransizca"
                },
                new Branch
                {
                    Id = 10,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    BranchName = "Felsefe",
                    Description = "Felsefe Dersleri",
                    Url = "felsefe"
                },
                new Branch
                {
                    Id = 11,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    BranchName = "Müzik",
                    Description = "Müzik Dersleri",
                    Url = "muzik"
                },
                new Branch
                {
                    Id = 12,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    BranchName = "Resim",
                    Description = "Resim Dersleri",
                    Url = "resim"
                }
                );
        }

    }
}

