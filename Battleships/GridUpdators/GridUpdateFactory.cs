using Battleships.Enums;

namespace Battleships.GridUpdators
{
    public static class GridUpdateFactory
    {
        public static AbstractGridUpdator GetOrientatedFactory(Position coOrdinate)
        {
            return coOrdinate.Orientation == Orientation.Horizontal
                       ? (AbstractGridUpdator) new HorizontalGridUpdatorImpl()
                       : new VerticalGridUpdatorImpl();
        }
    }
}