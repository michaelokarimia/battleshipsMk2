using System;

namespace Battleships
{
    public class InvalidShotException : Exception
    {
        public InvalidShotException(string msg) :base(msg)
        {}
    }
}   