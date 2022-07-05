using System.Runtime.Serialization;

namespace BlazorChat.Common.Exceptions;

public class DataBaseValidationException: Exception
{
    public DataBaseValidationException()
    {
        
    }

    public DataBaseValidationException(string message):base(message)
    {
        
    }

    public DataBaseValidationException(string message,Exception innerException):base(message,innerException)
    {
        
    }

    protected DataBaseValidationException(SerializationInfo serializationInfo, StreamingContext context) : base(serializationInfo, context)
    {
    }
}