using System;
using System.Runtime.Serialization;

namespace Cqrs
{
    [Serializable]
    public class HandlerNotImplementedException : NotImplementedException
    {
        public HandlerNotImplementedException() { }

        public HandlerNotImplementedException(string message) : base(message) { }

        public HandlerNotImplementedException(string message, Exception inner) : base(message, inner) { }

        protected HandlerNotImplementedException(
          SerializationInfo info,
          StreamingContext context) : base(info, context)
        { }
    }
}