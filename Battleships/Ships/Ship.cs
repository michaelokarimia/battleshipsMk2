using Battleships.Enums;

namespace Battleships.Ships
{
    public abstract class Ship
    {
        public Position Position { get; protected set;  }
        public AbstractGridUpdator GridUpdator { get; protected set; }
        public abstract int Length { get; }
        public abstract GridValues GridValue { get; }
        public void AddToGrid(GridValues[,] arrary)
        {
            GridUpdator.Update(this, arrary);
        }
    }
}