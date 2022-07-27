namespace SchoolManagement.Infrastructure.UoW;

/*
public sealed class UnityOfWork : IUnitOfWork
{
    private readonly SchoolDbContext _context;
    private IRepository<Address> _addressRepository;
    private IRepository<Student> _studentRepository;

    public UnityOfWork(SchoolDbContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IRepository<Student> StudentRepository => _studentRepository ??= new Repository<Student>(_context);

    public IRepository<Address> AddressRepository => _addressRepository ??= new Repository<Address>(_context);

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
*/
