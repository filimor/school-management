using System.Linq.Expressions;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Domain.Interfaces;

public interface ISyncRepository<T> where T : Entity
{
    T Get(int id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
}
