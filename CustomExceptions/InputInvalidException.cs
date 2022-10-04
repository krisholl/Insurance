using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class InputInvalidException : Exception
    {
        public InputInvalidException()
        {
        }

        public InputInvalidException(string? message) : base(message)
        {
        }

        public InputInvalidException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InputInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
