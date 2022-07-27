using System.Linq.Expressions;
using SchoolManagement.Application.Data.AddressDtos;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Application.Interfaces;

public interface IAddressSyncService
{
    GetAddressDto Get(int id);
    IEnumerable<GetAddressDto> GetAll();
    void Add(CreateAddressDto addressDto);
    void Update(ModifyAddressDto addressDto);
    void Delete(ModifyAddressDto addressDto);
    IEnumerable<GetAddressDto> Find(Expression<Func<Address, bool>> predicate);
}
