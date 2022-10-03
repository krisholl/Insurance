using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class TicketNotAvailableException : Exception
    {
        public TicketNotAvailableException()
        {
        }

        public TicketNotAvailableException(string? message) : base(message)
        {
        }

        public TicketNotAvailableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TicketNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
