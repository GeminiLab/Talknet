using System;

namespace Talknet.Invoker {
    public class InvalidCommandHandlerException : Exception {
        // public InvalidCommandHandlerException() { }
        public InvalidCommandHandlerException(string message) : base(message) { }
        public InvalidCommandHandlerException(string message, Exception inner) : base(message, inner) { }
    }
}
