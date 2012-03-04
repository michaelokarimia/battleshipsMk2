using System;

namespace Battleships
{
    public class InvalidShipPlacementException : Exception
    {
        public InvalidShipPlacementException(string message) :base(message)
        {
            
        }
    }
}