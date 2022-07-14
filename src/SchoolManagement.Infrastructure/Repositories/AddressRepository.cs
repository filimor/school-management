using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Models;
using SchoolManagement.Infrastructure.Context;

namespace SchoolManagement.Infrastructure.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly SchoolDbContext _context;

    public AddressRepository(SchoolDbContext context)
    {
        _context = context;
    }

    public IQueryable<Address> GetAddresses()
    {
        return _context.Addresses.AsQueryable();
    }

    public async Task<Address> GetAddressByIdAsync(int id)
    {
        return (await _context.Addresses.SingleOrDefaultAsync(a => a.Id == id))!;
    }

    public async Task<Address> AddAddressAsync(Address address)
    {
        await _context.Addresses.AddAsync(address);
        await _context.SaveChangesAsync();
        return address;
    }

    public async Task<Address> UpdateAddressAsync(Address address)
    {
        if (!_context.Addresses.Any(a => a.Id == address.Id))
        {
            return null!;
        }

        _context.Addresses.Update(address);
        await _context.SaveChangesAsync();
        return address;
    }

    public async Task<Address> DeleteAddressAsync(int id)
    {
        var address = await _context.Addresses.FindAsync(id);
        if (address == null)
        {
            return null!;
        }

        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();
        return address;
    }
}
