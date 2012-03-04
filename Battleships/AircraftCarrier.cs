﻿namespace Battleships
{
    public class AircraftCarrier : IShip
    {
        public GridValues GridValue
        {
            get { return GridValues.AircraftcarrierIntact; }
        }

        public int Length
        {
            get { return 5; }
        }
    }
}