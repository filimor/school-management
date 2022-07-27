using System.Linq.Expressions;
using AutoMapper;
using SchoolManagement.Application.Data.AddressDtos;
using SchoolManagement.Application.Interfaces;
using SchoolManagement.Domain.Models;
using SchoolManagement.Infrastructure.Interfaces;

namespace SchoolManagement.Application.Services;

public class AddressSyncService : IAddressSyncService
{
    private readonly IMapper _mapper;
    private readonly ISyncUnitOfWork _unitOfWork;

    public AddressSyncService(ISyncUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public GetAddressDto Get(int id)
    {
        var address = _unitOfWork.AddressRepository.Get(id);
        return _mapper.Map<GetAddressDto>(address);
    }

    public IEnumerable<GetAddressDto> GetAll()
    {
        var addresses = _unitOfWork.AddressRepository.GetAll();
        return _mapper.Map<IEnumerable<GetAddressDto>>(addresses);
    }

    public void Add(CreateAddressDto addressDto)
    {
        var address = _mapper.Map<Address>(addressDto);
        _unitOfWork.AddressRepository.Add(address);
        _unitOfWork.Save();
    }

    public void Update(ModifyAddressDto addressDto)
    {
        var address = _mapper.Map<Address>(addressDto);
        _unitOfWork.AddressRepository.Update(address);
        _unitOfWork.Save();
    }

    public void Delete(ModifyAddressDto addressDto)
    {
        var address = _mapper.Map<Address>(addressDto);
        _unitOfWork.AddressRepository.Delete(address);
        _unitOfWork.Save();
    }

    public IEnumerable<GetAddressDto> Find(Expression<Func<Address, bool>> predicate)
    {
        var addresses = _unitOfWork.AddressRepository.Find(predicate);
        return _mapper.Map<IEnumerable<GetAddressDto>>(addresses);
    }
}
