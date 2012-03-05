using System;

namespace Battleships.Exceptions
{
    public class InvalidShipPlacementException : Exception
    {
        public InvalidShipPlacementException(string message) :base(message)
        {
            
        }
    }
}