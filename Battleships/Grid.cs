using System;
using System.Linq;

namespace Battleships
{
    public class Grid
    {
        private readonly int height;
        private readonly int width;
        private int[,] array;

        public Grid(int width, int height)
        {
            this.height = height;
            this.width = width;
            array = new int[width,height];
        }


        public int Width()
        {
            return width;
        }

        public int Height()
        {
            return height;
        }


        public int GetCellValue(int height, int width)
        {
            return array[height,width];
        }
    }
}