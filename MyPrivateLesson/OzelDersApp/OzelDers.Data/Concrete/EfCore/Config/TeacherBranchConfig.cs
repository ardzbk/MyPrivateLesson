using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Concrete.EfCore.Config
{
    public class TeacherBranchConfig : IEntityTypeConfiguration<TeacherBranch>
    {
        public void Configure(EntityTypeBuilder<TeacherBranch> builder)
        {

            builder.HasKey(tb => new { tb.BranchId, tb.TeacherId });
            builder.HasOne(t => t.Teacher).WithMany(t => t.TeacherBranches).HasForeignKey(t => t.TeacherId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(t => t.Branch).WithMany(t => t.TeacherBranches).HasForeignKey(t => t.BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
                new TeacherBranch { BranchId = 1, TeacherId = 1 },
                new TeacherBranch { BranchId = 2, TeacherId = 2 },
                new TeacherBranch { BranchId = 3, TeacherId = 3 },
                new TeacherBranch { BranchId = 4, TeacherId = 4 },
                new TeacherBranch { BranchId = 5, TeacherId = 5 },
                new TeacherBranch { BranchId = 6, TeacherId = 6 },
                new TeacherBranch { BranchId = 7, TeacherId = 7 },
                new TeacherBranch { BranchId = 7, TeacherId = 8 }
                );
        }
    }
}

