using System;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Abstract
{
	public interface IStudentService
	{
        Task CreateAsync(Student student);

        Task<Student> GetByIdAsync(int id);

        Task<List<Student>> GetAllAsync();

        void Update(Student student);

        void Delete(Student student);

        Task CreateStudent(Student student);

        Task<List<Student>> GetAllStudentsWithTeachersAsync(bool ApprovedStatus);

        Task<Student> GetStudentFullDataAsync(int id);

        Task<List<Student>> GetStudentsByTeacher(int id);


    }
}

