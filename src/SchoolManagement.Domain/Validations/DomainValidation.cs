using SchoolManagement.Domain.Exceptions;

namespace SchoolManagement.Domain.Validations;

public static class DomainValidation
{
    public static void When(bool hasError, string message, Exception? innerException = null)
    {
        if (!hasError)
        {
            return;
        }

        if (innerException is not null)
        {
            throw new DomainException(message, innerException);
        }

        throw new DomainException(message);
    }
}