using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Application.Data.AddressDtos;

public class CreateAddressDto
{
    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string Street { get; set; }

    [Required]
    [StringLength(10, MinimumLength = 1)]
    public string Number { get; set; }

    [MaxLength(100)] public string Street2 { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string District { get; set; }

    [StringLength(100, MinimumLength = 5)] public string City { get; set; }

    [StringLength(2, MinimumLength = 2)] public string State { get; set; }

    [Required]
    [StringLength(9, MinimumLength = 8)]
    [DataType(DataType.PostalCode)]
    public string ZipCode { get; set; }
}
