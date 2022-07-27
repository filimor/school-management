namespace SchoolManagement.Infrastructure.Repositories;

/*
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
        return await Entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Entities.AsNoTracking().ToListAsync();
    }

    public void Add(T entity)
    {
        Entities.Add(entity);
    }

    public void Update(T entity)
    {
        Entities.Update(entity);
    }

    public void Delete(T entity)
    {
        Entities.Remove(entity);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await Entities.AsNoTracking().Where(predicate).ToListAsync();
    }
}
*/
