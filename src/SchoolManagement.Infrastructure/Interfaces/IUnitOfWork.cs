using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Infrastructure.Interfaces;

public interface IUnitOfWork
{
    IRepository<Student> StudentRepository { get; }
    IRepository<Address> AddressRepository { get; }
    Task SaveAsync();
}
