using System;

namespace FindLineWithMaxSum
{
    public class WrongFormatLineException : Exception
    {
        public WrongFormatLineException()
        {
        }

        public WrongFormatLineException(String message) : base(message)
        {
        }

        public WrongFormatLineException(String message, Exception inner) : base(message, inner)
        {
        }
    }
}
