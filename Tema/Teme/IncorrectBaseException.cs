using System;
using System.Runtime.Serialization;

namespace Tema1
{
    [Serializable]
    internal class IncorrectBaseException : Exception
    {
        public IncorrectBaseException()
        {
        }

        public IncorrectBaseException(string message) : base(message)
        {
        }

        public IncorrectBaseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IncorrectBaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}