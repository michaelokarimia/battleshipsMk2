using Battleships.Enums;
using Battleships.GridUpdators;

namespace Battleships.Ships
{
    public abstract class Ship
    {
        private readonly Position coOoridinate;

        public Ship(Position position)
        {
            coOoridinate = position;
            GridUpdator = GridUpdateFactory.GetOrientatedFactory(position);
        }

        public Position GetPosition { get { return coOoridinate; } }
        protected AbstractGridUpdator GridUpdator { get; set; }
        public abstract int Length { get; }
        public abstract GridValue GridValue { get; }
        public void AddToGrid(GridValue[,] arrary)
        {
            GridUpdator.Update(this, arrary);
        }
    }
}