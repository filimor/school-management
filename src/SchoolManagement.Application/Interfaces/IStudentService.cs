using System.Linq.Expressions;
using SchoolManagement.Application.Data.StudentDtos;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Application.Interfaces;

public interface IStudentService
{
    Task<GetStudentDto> GetAsync(int id);
    Task<IEnumerable<GetStudentDto>> GetAllAsync();
    Task AddAsync(CreateStudentDto studentDto);
    Task UpdateAsync(ModifyStudentDto studentDto);
    Task DeleteAsync(ModifyStudentDto studentDto);
    Task<IEnumerable<GetStudentDto>> FindAsync(Expression<Func<Student, bool>> predicate);
}
