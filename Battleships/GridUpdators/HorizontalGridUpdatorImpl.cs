using Battleships.Enums;
using Battleships.Exceptions;
using Battleships.Ships;

namespace Battleships.GridUpdators
{
    class HorizontalGridUpdatorImpl : AbstractGridUpdator
    {
        public override void Update(Ship vessel, GridValue[,] array)
        {
            int length = vessel.Length;

            Position shipPosition = vessel.GetPosition;

            if (shipPosition.X + length > array.GetUpperBound(0))
            {
                throw new InvalidShipPlacementException(
                    string.Format("Horizontal ship won't fit on the board, attempted to add: {0}",
                                  shipPosition.ToString()));
            }
            for (var x = shipPosition.X; x < (length + shipPosition.X); x++)
            {
                if (array[x, shipPosition.Y] != GridValue.EmptyCellValue)
                {
                    throw new InvalidShipPlacementException(string.Format("There is already a ship here:{0}",
                                                                          array[x, shipPosition.Y]));
                }
            }

            for (var x = shipPosition.X; x < (length + shipPosition.X); x++)
            {
                array[x, shipPosition.Y] = vessel.GridValue;
            }
        }
    }
}