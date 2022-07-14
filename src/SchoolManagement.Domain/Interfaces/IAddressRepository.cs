using SchoolManagement.Domain.Models;

namespace SchoolManagement.Domain.Interfaces;

public interface IAddressRepository
{
    IQueryable<Address> GetAddresses();
    Task<Address> GetAddressByIdAsync(int id);
    Task<Address>  AddAddressAsync(Address address);
    Task<Address>  UpdateAddressAsync(Address address);
    Task<Address>  DeleteAddressAsync(int id);
}
