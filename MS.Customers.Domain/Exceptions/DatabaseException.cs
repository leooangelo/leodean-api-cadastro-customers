using System;

namespace MS.Customer.Domain.Exceptions
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}