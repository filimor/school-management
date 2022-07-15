using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Models;
using SchoolManagement.Infrastructure.Context;
using SchoolManagement.Infrastructure.Interfaces;

namespace SchoolManagement.Infrastructure.Repositories;

public sealed class UnityOfWork : IUnitOfWork, IDisposable
{
    private readonly SchoolDbContext _context;

    public UnityOfWork(SchoolDbContext context)
    {
        _context = context;
        StudentRepository = new Repository<Student>(_context);
        AddressRepository = new Repository<Address>(_context);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IRepository<Student> StudentRepository { get; }

    public IRepository<Address> AddressRepository { get; }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
