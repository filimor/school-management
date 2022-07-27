using System.Linq.Expressions;
using SchoolManagement.Application.Data.AddressDtos;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Application.Interfaces;

public interface IAddressService
{
    Task<GetAddressDto> GetAsync(int id);
    Task<IEnumerable<GetAddressDto>> GetAllAsync();
    Task AddAsync(CreateAddressDto addressDto);
    Task UpdateAsync(ModifyAddressDto addressDto);
    Task DeleteAsync(ModifyAddressDto addressDto);
    Task<IEnumerable<GetAddressDto>> FindAsync(Expression<Func<Address, bool>> predicate);
}
