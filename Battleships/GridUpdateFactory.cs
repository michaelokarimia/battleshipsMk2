using Battleships.Enums;

namespace Battleships
{
    public static class GridUpdateFactory
    {
        public static AbstractGridUpdator GetOrientatedFactory(Position coOrdinate)
        {
            if (coOrdinate.Orientation == Orientation.Horizontal)
            {
                return new HorizontalGridUpdatorImpl();
            }
            else
            {
                return new VerticalGridUpdatorImpl();
            }
        }
    }
}