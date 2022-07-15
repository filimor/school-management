using System.Linq.Expressions;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Domain.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task<T> GetAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
}
