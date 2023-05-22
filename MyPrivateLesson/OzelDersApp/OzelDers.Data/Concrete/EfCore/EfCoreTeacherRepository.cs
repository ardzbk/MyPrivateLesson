using System;
using Microsoft.EntityFrameworkCore;
using OzelDers.Data.Abstract;
using OzelDers.Data.Concrete.EfCore.Context;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Concrete.EfCore
{
    public class EfCoreTeacherRepository : EfCoreGenericRepository<Teacher>, ITeacherRepository
    {
        public EfCoreTeacherRepository(PrivateLessonContext _appContext) : base(_appContext)
        {
        }

        PrivateLessonContext AppContext
        {
            get { return _dbContext as PrivateLessonContext; }
        }

        public async Task<List<Teacher>> GetAllTeachersFullDataAsync(bool IsApproved, string branchurl)
        {
            var teachers = AppContext
                        .Teachers
                        .Where(t => t.IsApproved == IsApproved)
                        .Include(t=>t.User)
                        .ThenInclude(t=>t.Image)
                        .Include(t => t.TeacherBranches)
                        .ThenInclude(tb => tb.Branch)
                        .AsQueryable();

            if (branchurl!=null)
            {
                teachers = teachers
                        .Where(t => t.TeacherBranches.Any(tb => tb.Branch.Url == branchurl));
            }

            return await teachers
                        .Include(t => t.TeacherStudents)
                        .ThenInclude(tb => tb.Student)
                        .ToListAsync();
        }


        public async Task CreateTeacher(Teacher teacher, int[] SelectedBranches)
        {
            await AppContext.Teachers.AddAsync(teacher);
            await AppContext.SaveChangesAsync();
            List<TeacherBranch> teacherBranches = new List<TeacherBranch>();
            foreach (var branchId in SelectedBranches)
            {
                teacherBranches.Add(new TeacherBranch
                {
                    BranchId = branchId,
                    TeacherId = teacher.Id
                });
            }
            AppContext.TeacherBranches.AddRange(teacherBranches);
            await AppContext.SaveChangesAsync();
        }

        public async Task<Teacher> GetTeacherFullDataAsync(int id)
        {
            var teacher = await AppContext
                .Teachers
                .Where(t => t.Id == id)
                .Include(t => t.User)
                .ThenInclude(t => t.Image)
                .Include(t=>t.TeacherStudents)
                .ThenInclude(ts=>ts.Student)
                .Include(t => t.TeacherBranches)
                .ThenInclude(tb => tb.Branch)
                .FirstOrDefaultAsync();
            return teacher;
        }

        public async Task UpdateTeacher(Teacher teacher, int[] SelectedBranches)
        {
            Teacher updateTeacher = AppContext
             .Teachers
             .Include(t => t.User)
             .Include(t => t.TeacherBranches)
             .FirstOrDefault(t => t.Id == teacher.Id);
            updateTeacher.User.FirstName = teacher.User.FirstName;
            updateTeacher.User.LastName = teacher.User.LastName;
            updateTeacher.User.DateOfBirth = teacher.User.DateOfBirth;
            updateTeacher.User.Gender = teacher.User.Gender;
            updateTeacher.User.City = teacher.User.City;
            updateTeacher.User.Phone = teacher.User.Phone;
            updateTeacher.IsApproved = teacher.IsApproved;
            updateTeacher.UpdatedDate = teacher.UpdatedDate;
            updateTeacher.Graduation = teacher.Graduation;
            updateTeacher.User.Image = teacher.User.Image;
            updateTeacher.TeacherBranches = SelectedBranches
                .Select(sb => new TeacherBranch
                {
                    TeacherId = updateTeacher.Id,
                    BranchId = sb
                }).ToList();
            AppContext.Update(teacher);
            await AppContext.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetTeachersByBranch(int id)
        {
            List<Teacher> teachers = await AppContext
                .Teachers
                .Where(t => t.IsApproved == true)
                .Include(t => t.TeacherStudents)
                .ThenInclude(ts => ts.Student)
                .ThenInclude(tu => tu.User)
                .ThenInclude(t => t.Image)
                .Include(tu => tu.User)
                .ThenInclude(t => t.Image)
                .Include(t => t.TeacherBranches)
               .ThenInclude(tb => tb.Branch)
               .Where(t => t.TeacherBranches.Any(x => x.BranchId == id))
               .ToListAsync();
            return teachers;
        }

        public async Task<List<Teacher>> GetTeachersByStudent(int id)
        {
            List<Teacher> teachers = await AppContext
                .Teachers
                .Where(t => t.IsApproved == true)

                .Include(tu => tu.User)
                .ThenInclude(t => t.Image)
                .Include(t => t.TeacherBranches)
               .ThenInclude(tb => tb.Branch)
               .Include(t => t.TeacherStudents)
                .ThenInclude(ts => ts.Student)
                .ThenInclude(tu => tu.User)
                .ThenInclude(t => t.Image)
                .Where(t => t.TeacherStudents.Any(x => x.StudentId == id))
               .ToListAsync();
            return teachers;
        }

        public  Task<int> GetByUrlAsync(string url)
        {
            var result = AppContext.Teachers.Where(t => t.Url == url).Select(t => t.Id).FirstOrDefaultAsync();
            return result;
        }

        public async  Task<Teacher> GetTeacherFullDataStringAsync(string Name)
        {
            var teacher = await AppContext
                .Teachers
                .Where(t => t.User.Id == Name)
                .Include(t => t.User)
                .ThenInclude(t => t.Image)
                .Include(t => t.TeacherStudents)
                .ThenInclude(ts => ts.Student)
                .Include(t => t.TeacherBranches)
                .ThenInclude(tb => tb.Branch)
                .FirstOrDefaultAsync();
            return teacher;
        }
    }
}

