using System;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Abstract
{
	public interface IStudentRepository :IGenericRepository<Student>
	{
        Task CreateStudent(Student student);
        Task<List<Student>> GetAllStudentsWithTeachersAsync(bool ApprovedStatus);
        Task<Student> GetStudentFullDataAsync(int id);
        Task<List<Student>> GetStudentsByTeacher(int id);

    }
}

