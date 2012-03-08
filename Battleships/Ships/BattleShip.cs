using Battleships.Enums;

namespace Battleships.Ships
{
    public class BattleShip : Ship
    {

        public BattleShip(Position coOrdinate) : base(coOrdinate){}

        public override GridValue GridValue
        {
            get { return GridValue.BattleshipIntact; }
        }

        public override int Length
        {
            get { return 4; }
        }
    }
}