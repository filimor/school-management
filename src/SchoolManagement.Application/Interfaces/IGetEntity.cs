namespace SchoolManagement.Application.Interfaces;

public interface IGetEntity
{
    public int Id { get; }

    public DateTime CreatedAt { get; }

    public DateTime LastModified { get; }
}
