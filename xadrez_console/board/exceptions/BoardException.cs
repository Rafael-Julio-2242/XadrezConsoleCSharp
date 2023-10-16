using System;

namespace board.exceptions
{
    class BoardException : Exception
    {
        public BoardException(string message) : base(message) { }

    }
}
