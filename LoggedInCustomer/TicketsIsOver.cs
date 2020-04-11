using System;
using System.Runtime.Serialization;

namespace FlyCenterProject
{
    [Serializable]
    internal class TicketsIsOver : Exception
    {
        public TicketsIsOver()
        {
        }

        public TicketsIsOver(string message) : base(message)
        {
        }

        public TicketsIsOver(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TicketsIsOver(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}