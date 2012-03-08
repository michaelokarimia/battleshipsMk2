using Battleships.Enums;
using Battleships.Exceptions;
using Battleships.Ships;

namespace Battleships.GridUpdators
{
    public class VerticalGridUpdatorImpl : AbstractGridUpdator
    {
        public override void Update(Ship vessel, GridValue[,] array)
        {
            var shipPosition = vessel.GetPosition;
            int Length = vessel.Length;
            if (shipPosition.Y + Length > array.GetUpperBound(1))
            {
                throw new InvalidShipPlacementException(
                    string.Format("Vertical ship won't fit on the board, attempted to add: {0}",
                                  shipPosition.ToString()));
            }
            int row = shipPosition.X;

            for (int y = shipPosition.Y; y < (Length + shipPosition.Y); y++)
            {
                if (array[row, y] != GridValue.EmptyCellValue)
                {
                    throw new InvalidShipPlacementException(string.Format("There is already a ship here:{0}",
                                                                          array[row, y]));
                }
            }

            for (int y = shipPosition.Y; y < (Length + shipPosition.Y); y++)
            {
                array[row, y] = vessel.GridValue;
            }
        }
    }
}