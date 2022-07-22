using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Models;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class SyncRepository<T> : ISyncRepository<T> where T : Entity
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> Entities;

        public SyncRepository(DbContext context)
        {
            Context = context;
            Entities = context.Set<T>();
        }

        public T Get(int id)
        {
            return Entities.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return Entities.AsNoTracking().ToList();
        }

        public void Add(T entity)
        {
            Entities.Add(entity);
        }

        public void Update(T entity)
        {
            Entities.Update(entity);
        }

        public void Remove(T entity)
        {
            Entities.Remove(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Entities.AsNoTracking().Where(predicate).ToList();
        }
    }
}
