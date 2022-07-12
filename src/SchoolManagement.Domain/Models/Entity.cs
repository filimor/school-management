using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Domain.Models;

public abstract class Entity
{
    [Key]
    public int Id { get; }
    public DateTime CreatedAt { get; }
    public DateTime LastModified { get; private set; }
    public bool DeletedFlag { get; private set; }

    protected Entity(int id)
    {
        Validate(id);
        Id = id;
        CreatedAt = DateTime.Now;
        LastModified = DateTime.Now;
        DeletedFlag = false;
    }

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
        if (id <= 0)
            throw new ArgumentException("O id deve ser um número inteiro maior do que 1.", nameof(id));
    }
}