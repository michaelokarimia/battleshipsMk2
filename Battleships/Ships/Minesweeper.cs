using Battleships.Enums;
using Battleships.Exceptions;

namespace Battleships.Ships
{
    public class Minesweeper : Ship
    {
        public Minesweeper(Position coOoridinate)
        {
            Position = coOoridinate;
            GridUpdator = GridUpdateFactory.GetOrientatedFactory(coOoridinate);
        }

        public Position CoOrdinate
        {
            get { return Position; }
        }

        public override GridValues GridValue
        {
            get { return GridValues.MinesweeperIntact; }
        }

        public override int Length
        {
            get { return 2; }
        }

      

        private void PlaceShipVertically(Position shipPosition, GridValues[,] array)
        {
            if (shipPosition.Y + Length > array.GetUpperBound(1))
            {
                throw new InvalidShipPlacementException(
                    string.Format("Vertical ship won't fit on the board, attempted to add: {0}",
                                  shipPosition.ToString()));
            }
            int row = shipPosition.X;

            for (int y = shipPosition.Y; y < (Length + shipPosition.Y); y++)
            {
                if (array[row, y] != GridValues.EmptyCellValue)
                {
                    throw new InvalidShipPlacementException(string.Format("There is already a ship here:{0}",
                                                                          array[row, y]));
                }
            }

            for (int y = shipPosition.Y; y < (Length + shipPosition.Y); y++)
            {
                array[row, y] = GridValue;
            }
        }

        private void PlaceShipHorizontally(Position shipPosition, GridValues[,] array)
        {
            if (shipPosition.X + Length > array.GetUpperBound(0))
            {
                throw new InvalidShipPlacementException(
                    string.Format("Horizontal ship won't fit on the board, attempted to add: {0}",
                                  shipPosition.ToString()));
            }
            for (var x = shipPosition.X; x < (Length + shipPosition.X); x++)
            {
                if (array[x, shipPosition.Y] != GridValues.EmptyCellValue)
                {
                    throw new InvalidShipPlacementException(string.Format("There is already a ship here:{0}",
                                                                          array[x, shipPosition.Y]));
                }
            }

            for (var x = shipPosition.X; x < (Length + shipPosition.X); x++)
            {
                array[x, shipPosition.Y] = GridValue;
            }
        }
    }
}