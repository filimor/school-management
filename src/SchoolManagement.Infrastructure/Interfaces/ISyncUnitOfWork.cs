using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Infrastructure.Interfaces;

public interface ISyncUnitOfWork : IDisposable
{
    ISyncRepository<Student> StudentRepository { get; }
    ISyncRepository<Address> AddressRepository { get; }
    void Save();
}
