using AutoMapper;
using SchoolManagement.Application.Data.AddressDtos;
using SchoolManagement.Application.Data.StudentDtos;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Application.Profiles;

public sealed class DtoToDomainProfile : Profile
{
    public DtoToDomainProfile()
    {
        CreateMap<CreateAddressDto, Address>();
        CreateMap<ModifyAddressDto, Address>();
        CreateMap<CreateStudentDto, Student>();
        CreateMap<ModifyStudentDto, Student>();
    }
}
