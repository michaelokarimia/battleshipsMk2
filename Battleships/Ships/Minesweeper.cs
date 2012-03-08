using Battleships.Enums;

namespace Battleships.Ships
{
    public class Minesweeper : Ship
    {
        public Minesweeper(Position coOrdinate) :base (coOrdinate) {}

        public override GridValue GridValue
        {
            get { return GridValue.MinesweeperIntact; }
        }

        public override int Length
        {
            get { return 2; }
        }
    }
}