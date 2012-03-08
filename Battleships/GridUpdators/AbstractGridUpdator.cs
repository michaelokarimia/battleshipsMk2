using Battleships.Enums;
using Battleships.Ships;

namespace Battleships.GridUpdators
{
    public abstract class AbstractGridUpdator
    {
        public abstract void Update(Ship vessel, GridValue[,] array);
    }
}