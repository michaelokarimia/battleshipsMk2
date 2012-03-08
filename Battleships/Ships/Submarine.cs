using System;
using Battleships.Enums;

namespace Battleships.Ships
{
    public class Submarine : Ship

    {
        public Submarine(Position coOrdinate): base(coOrdinate){}

        public override GridValue GridValue
        {
            get { return GridValue.SubmarineIntact; }
        }

        public override int Length
        {
            get { return 3; }
        }
    }
}