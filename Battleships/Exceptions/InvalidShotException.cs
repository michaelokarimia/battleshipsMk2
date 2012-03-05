using System;

namespace Battleships.Exceptions
{
    public class InvalidShotException : Exception
    {
        public InvalidShotException(string msg) :base(msg)
        {}
    }
}   