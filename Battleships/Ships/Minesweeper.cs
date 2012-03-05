using Battleships.Enums;

namespace Battleships.Ships
{
    public class Minesweeper : IShip
    {
        public GridValues GridValue
        {
            get { return GridValues.MinesweeperIntact; }
        }

        public int Length
        {
            get { return 2; }
        }
    }
}