using System.Runtime.Serialization;

namespace CustomExceptions
{
    public class UserNotAvailableException : Exception
    {
        public UserNotAvailableException()
        {
        }

        public UserNotAvailableException(string? message) : base(message)
        {
        }

        public UserNotAvailableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}