using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class PolicyNotAvailableException : Exception
    {
        public PolicyNotAvailableException()
        {
        }

        public PolicyNotAvailableException(string? message) : base(message)
        {
        }

        public PolicyNotAvailableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PolicyNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
