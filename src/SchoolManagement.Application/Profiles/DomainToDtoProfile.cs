    using AutoMapper;
using SchoolManagement.Application.Data.AddressDtos;
using SchoolManagement.Application.Data.StudentDtos;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Application.Profiles;

public class DomainToDtoProfile : Profile
{
    public DomainToDtoProfile()
    {
        CreateMap<Address, GetAddressDto>();
        CreateMap<Student, GetStudentDto>();
    }
}
