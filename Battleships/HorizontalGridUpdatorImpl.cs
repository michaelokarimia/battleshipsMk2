using Battleships.Enums;
using Battleships.Exceptions;
using Battleships.Ships;

namespace Battleships
{
    class HorizontalGridUpdatorImpl : AbstractGridUpdator
    {
        public override void Update(Ship vessel, GridValues[,] array)
        {
            int length = vessel.Length;

            Position shipPosition = vessel.Position;

            if (shipPosition.X + length > array.GetUpperBound(0))
            {
                throw new InvalidShipPlacementException(
                    string.Format("Horizontal ship won't fit on the board, attempted to add: {0}",
                                  shipPosition.ToString()));
            }
            for (var x = shipPosition.X; x < (length + shipPosition.X); x++)
            {
                if (array[x, shipPosition.Y] != GridValues.EmptyCellValue)
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