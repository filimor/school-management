using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Models;
using SchoolManagement.Infrastructure.Context;
using SchoolManagement.Infrastructure.Interfaces;
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagement.Infrastructure.UoW;

public sealed class SyncUnityOfWork : ISyncUnitOfWork
{
    private readonly SchoolDbContext _context;
    private ISyncRepository<Address> _addressRepository;
    private ISyncRepository<Student> _studentRepository;

    public SyncUnityOfWork(SchoolDbContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public ISyncRepository<Student> StudentRepository => _studentRepository ??= new SyncRepository<Student>(_context);

    public ISyncRepository<Address> AddressRepository => _addressRepository ??= new SyncRepository<Address>(_context);

    public void Save()
    {
        _context.SaveChanges();
    }
}
