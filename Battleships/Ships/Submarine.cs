using System;
using Battleships.Enums;

namespace Battleships.Ships
{
    public class Submarine : IShip

    {
        public GridValues GridValue
        {
            get { return GridValues.Submarine; }
        }

        public int Length
        {
            get { return 3; }
        }
    }
}