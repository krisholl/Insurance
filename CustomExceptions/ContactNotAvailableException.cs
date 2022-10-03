using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class ContactNotAvailableException : Exception
    {
        public ContactNotAvailableException()
        {
        }

        public ContactNotAvailableException(string? message) : base(message)
        {
        }

        public ContactNotAvailableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ContactNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
