﻿namespace Battleships
{
    public struct Position
    {
        private readonly int x;
        private readonly int y;
        private readonly Orientation orientation;

        public Position(int x, int y, Orientation orientation)
        {
            this.x = x;
            this.y = y;
            this.orientation = orientation;
        }

        public Orientation Orientation
        {
            get { return orientation; }
        }

        public int Y
        {
            get { return y; }
        }

        public int X
        {
            get { return x; }
        }
    }
}