namespace Battleships
{
    public class BattleShip : IShip
    {
        public GridValues GridValue
        {
            get { return GridValues.BattleshipIntact; }
        }

        public int Length
        {
            get { return 4; }
        }
    }
}