using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly DbContext Context;
    protected readonly DbSet<T> Entities;

    public Repository(DbContext context)
    {
        Context = context;
        Entities = context.Set<T>();
    }

    public async Task<T> GetAsync(int id)
    {
        return (await Entities.FindAsync(id))!;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Entities.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await Entities.AddAsync(entity);
    }

    public void Update(T entity)
    {
        Entities.Update(entity);
    }

    public void Remove(T entity)
    {
        Entities.Remove(entity);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await Entities.Where(predicate).ToListAsync();
    }
}
