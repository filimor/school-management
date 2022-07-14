using SchoolManagement.Domain.Models;

namespace SchoolManagement.Domain.Interfaces;

public interface IStudentRepository
{
    IQueryable<Student> GetStudents();
    Student GetStudentById(int id);
    void AddStudent(Student student);
    void UpdateStudent(Student student);
    void DeleteStudent(int id);
}