using SchoolManagement.Application.Interfaces;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Application.Data.StudentDtos;

public class GetStudentDto : IGetEntity
{
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public Gender Gender { get; set; }
    public SkinColor SkinColor { get; set; }
    public Address Address { get; set; }
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastModified { get; set; }
}
