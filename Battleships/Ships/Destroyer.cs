using Battleships.Enums;

namespace Battleships.Ships
{
    public class Destroyer : IShip
    {
        public GridValues GridValue
        {
            get { return GridValues.DestroyerIntact; }
        }

        public int Length
        {
            get { return 3; }
        }
    }
}