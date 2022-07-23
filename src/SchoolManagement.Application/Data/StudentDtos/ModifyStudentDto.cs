using System.ComponentModel.DataAnnotations;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Application.Data.StudentDtos;

public class ModifyStudentDto
{
    [Required] public int Id { get; set; }

    [Required] public string Name { get; set; }

    [Required] public DateTime Birthday { get; set; }

    [Required] public Gender Gender { get; set; }

    [Required] public SkinColor SkinColor { get; set; }

    [Required] public int AddressId { get; set; }
}
