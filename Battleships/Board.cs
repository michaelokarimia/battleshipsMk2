using System;
using System.Linq;
using System.Text;
using Battleships;

namespace Battleships
{
    public class Board
    {
        private readonly int _height;
        private readonly int _width;
        private readonly GridValues[,] array;

        public Board(int width, int height)
        {
            _height = height;
            _width = width;
            array = new GridValues[width, height];

            for (var x = 0; x < _width; x++)
            {
                for (var y = 0; y < _height; y++)
                {
                    array[x, y] = GridValues.EmptyCellValue;
                }
            }

        }     

        public int Width()
        {
            return _width;
        }

        public int Height()
        {
            return _height;
        }


        public GridValues GetCellValue(int height, int width)
        {
            return array[height,width];
        }

        public void FireShot(int x, int y)
        {
            if (array[x,y].Equals(GridValues.EmptyCellValue))
            {
                array[x, y] = GridValues.MissedShot;
            }
            else
            {
                throw new InvalidShotException(string.Format("Can't fire at this square, cell value is: {0}", array[x,y]));
            }

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            
            for (var x = 0; x < _width; x++)
            {
                
                for (var y = 0; y < _height; y++)
                {
                    sb.Append((int)array[x,y]);
                }
                sb.AppendLine("");
            }
                
            

            return sb.ToString();
        }
    }
}