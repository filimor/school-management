using SchoolManagement.Application.Interfaces;

namespace SchoolManagement.Application.Data.AddressDtos;

public class GetAddressDto : IGetEntity
{
    public int Id { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string Street2 { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastModified { get; set; }
}
