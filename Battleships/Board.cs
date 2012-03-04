using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
    public enum Orientation
    {
        Horizontal,
        Vertical
    }
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

        public Orientation Orientation1
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

    public class Board
    {
        private readonly int _height;
        private readonly int _width;
        private readonly GridValues[,] array;
        private List<AircraftCarrier> PlacedShip = new List<AircraftCarrier>();

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

        public void AddShip(AircraftCarrier carrier, Position position)
        {
            if (PlacedShip.Contains(carrier))
                throw new ShipAlreadyPlacedException();

            if (PlacedShip.Exists(x => x.GetType().Equals(typeof(AircraftCarrier))))
            {
                throw new ShipAlreadyPlacedException();
            }

            PlacedShip.Add(carrier);
        }
    }
}