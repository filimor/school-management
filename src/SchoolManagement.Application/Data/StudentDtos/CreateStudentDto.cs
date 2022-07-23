using System.ComponentModel.DataAnnotations;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Application.Data.StudentDtos;

public class CreateStudentDto
{
    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Birthday { get; set; }

    [Required]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }

    [Required]
    [EnumDataType(typeof(SkinColor))]
    public SkinColor SkinColor { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int AddressId { get; set; }
}
