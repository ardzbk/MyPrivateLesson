using System;
using OzelDers.Business.Abstract;
using OzelDers.Data.Abstract;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private IStudentRepository _studentRepository;

        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task CreateAsync(Student student)
        {
            await _studentRepository.CreateAsync(student);
        }

        public async Task CreateStudent(Student student)
        {
            await _studentRepository.CreateStudent(student);
        }

        public void Delete(Student student)
        {
            _studentRepository.Delete(student);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<List<Student>> GetAllStudentsWithTeachersAsync(bool ApprovedStatus)
        {
            return await _studentRepository.GetAllStudentsWithTeachersAsync(ApprovedStatus);
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<Student> GetStudentFullDataAsync(int id)
        {
            return await _studentRepository.GetStudentFullDataAsync(id);
        }

        public void Update(Student student)
        {
            _studentRepository.Update(student);
        }

        public async Task<List<Student>> GetStudentsByTeacher(int id)
        {
            return await _studentRepository.GetStudentsByTeacher(id);
        }
    }
}

