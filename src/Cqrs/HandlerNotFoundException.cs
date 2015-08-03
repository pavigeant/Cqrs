namespace Cqrs
{
    using System;

    [Serializable]
    public class HandlerNotImplementedException : NotImplementedException
    {
        public HandlerNotImplementedException() { }

        public HandlerNotImplementedException(string message) : base(message) { }

        public HandlerNotImplementedException(string message, Exception inner) : base(message, inner) { }

        protected HandlerNotImplementedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}