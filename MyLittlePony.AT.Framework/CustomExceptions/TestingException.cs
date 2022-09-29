using System;
using System.Runtime.Serialization;

namespace MyLittlePony.AT.Framework.CustomExceptions
{
    [Serializable]
    public class TestingException : Exception
    {
        public TestingException()
        {
        }

        public TestingException(string message) : base(message)
        {
        }

        public TestingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TestingException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }
    }
}
