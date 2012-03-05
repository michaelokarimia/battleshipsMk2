using System;
using Battleships.Enums;

namespace Battleships.Ships
{
    public class Submarine : IShip

    {
        public GridValues GridValue
        {
            get { return GridValues.SubmarineIntact; }
        }

        public int Length
        {
            get { return 3; }
        }
    }
}