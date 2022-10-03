using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class ClaimNotAvailableException : Exception
    {
        public ClaimNotAvailableException()
        {
        }

        public ClaimNotAvailableException(string? message) : base(message)
        {
        }

        public ClaimNotAvailableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ClaimNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
