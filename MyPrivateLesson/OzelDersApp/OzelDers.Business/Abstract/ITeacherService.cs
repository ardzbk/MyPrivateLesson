using System;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Abstract
{
	public interface ITeacherService
	{
        Task CreateAsync(Teacher teacher);

        Task<Teacher> GetByIdAsync(int id);

        Task<List<Teacher>> GetAllAsync();

        void Update(Teacher teacher);

        void Delete(Teacher teacher);

        Task<List<Teacher>> GetAllTeachersFullDataAsync(bool IsApproved, string branchurl = null);

        Task CreateTeacher(Teacher teacher, int[] SelectedBranches);

        Task<Teacher> GetTeacherFullDataAsync(int id);

        Task<Teacher> GetTeacherFullDataStringAsync(string Name);

        Task UpdateTeacher(Teacher teacher, int[] SelectedBranches);

        Task<List<Teacher>> GetTeachersByBranch(int id);

        Task<List<Teacher>> GetTeachersByStudent(int id);

        Task<int> GetByUrlAsync(string url);

    }
}

