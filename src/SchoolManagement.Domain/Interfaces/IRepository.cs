using System.Linq.Expressions;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Domain.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task<T> GetAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
}
