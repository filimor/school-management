using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Models;
using SchoolManagement.Infrastructure.Context;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _context;

        public StudentRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public IQueryable<Student> GetStudents()
        {
            return _context.Students.AsQueryable();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return (await _context.Students.Include(s => s.Address).SingleOrDefaultAsync(s => s.Id == id))!;
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            if (!_context.Students.Any(a => a.Id == student.Id))
            {
                return null!;
            }

            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return null!;
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
