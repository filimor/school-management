using System.Linq.Expressions;
using SchoolManagement.Application.Data.StudentDtos;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Application.Interfaces;

public interface IStudentSyncService
{
    GetStudentDto Get(int id);
    IEnumerable<GetStudentDto> GetAll();
    void Add(CreateStudentDto studentDto);
    void Update(ModifyStudentDto studentDto);
    void Delete(ModifyStudentDto studentDto);
    IEnumerable<GetStudentDto> Find(Expression<Func<Student, bool>> predicate);
}
