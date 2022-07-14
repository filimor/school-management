using SchoolManagement.Domain.Models;

namespace SchoolManagement.Domain.Interfaces;

public interface IStudentRepository
{
    IQueryable<Student> GetStudents();
    Task<Student> GetStudentByIdAsync(int id);
    Task<Student> AddStudentAsync(Student student);
    Task<Student> UpdateStudentAsync(Student student);
    Task<Student> DeleteStudentAsync(int id);
}
