using SchoolManagement.Domain.Models;

namespace SchoolManagement.Domain.Interfaces;

public interface IAddressRepository
{
    IQueryable<Address> GetAddresses();
    Address GetAddressById(int id);
    void AddAddress(Address address);
    void UpdateAddress(Address address);
    void DeleteAddress(int id);
}