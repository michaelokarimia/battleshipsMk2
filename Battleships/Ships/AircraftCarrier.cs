using Battleships.Enums;

namespace Battleships.Ships
{
    public class AircraftCarrier : Ship
    {
        public AircraftCarrier(Position coOrdinate): base(coOrdinate){}

        public override int Length
        {
            get { return 5; }
        }

        public override GridValue GridValue
        {
            get { return GridValue.AircraftcarrierIntact; }
        }

          
    }
}