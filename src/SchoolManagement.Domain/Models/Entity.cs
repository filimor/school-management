using SchoolManagement.Domain.Validations;

namespace SchoolManagement.Domain.Models;

public abstract class Entity
{
    protected Entity()
    {
        CreatedAt = DateTime.Now;
        LastModified = DateTime.Now;
        DeletedFlag = false;
    }

    protected Entity(int id) : this()
    {
        Validate(id);
        Id = id;
    }

    public int Id { get; }

    public DateTime CreatedAt { get; }

    public DateTime LastModified { get; protected set; }

    public bool DeletedFlag { get; protected set; }

    public virtual void Update()
    {
        LastModified = DateTime.Now;
    }

    public void Delete()
    {
        DeletedFlag = true;
        Update();
    }

    public void Restore()
    {
        DeletedFlag = false;
        Update();
    }

    protected static void Validate(int id)
    {
        DomainValidation.When(id <= 0, "O id deve ser um número inteiro maior ou igual a 1.");
    }
}
