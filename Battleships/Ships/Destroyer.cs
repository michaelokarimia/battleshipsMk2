using Battleships.Enums;

namespace Battleships.Ships
{
    public class Destroyer : Ship
    {
        public Destroyer(Position coOrdinate): base(coOrdinate){}

        public override GridValue GridValue
        {
            get { return GridValue.DestroyerIntact; }
        }

        public override int Length
        {
            get { return 3; }
        }
    }
}