using Battleships.Enums;

namespace Battleships.Ships
{
    public class AircraftCarrier : Ship
    {
        public AircraftCarrier(Position coOrdinate)
        {
            Position = coOrdinate;
            GridUpdator = GridUpdateFactory.GetOrientatedFactory(coOrdinate);
        }

        public Position CoOrdinate
        {
            get { return Position; }
        }

        public override int Length
        {
            get { return 5; }
        }

        public override GridValues GridValue
        {
            get { return GridValues.AircraftcarrierIntact; }
        }

          
    }
}