using Battleships.Enums;
using Battleships.Ships;

namespace Battleships
{
    public abstract class AbstractGridUpdator
    {
        public abstract void Update(Ship vessel, GridValues[,] array);
    }
}