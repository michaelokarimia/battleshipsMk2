using System;

namespace Battleships
{
    public class Grid
    {
        private readonly int _height;
        private readonly int _width;

        public Grid(int height, int width)
        {
            _height = height;
            _width = width;
        }


        public int Width()
        {
            return _width;
        }

        public int Height()
        {
            return _height;
        }
    }
}