using System.Runtime.Serialization;

namespace SchoolManagement.Domain.Exceptions;

[Serializable]
public class DomainException : Exception
{
    public DomainException()
    {
    }

    public DomainException(string message) : base(message)
    {
    }

    public DomainException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}