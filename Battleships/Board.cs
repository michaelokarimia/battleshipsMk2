using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
    public class Board
    {
        private readonly int _height;
        private readonly int _width;
        private readonly GridValues[,] array;
        private readonly List<IShip> placedShips = new List<IShip>();

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

        public void AddShip(IShip vessel, Position position)
        {
            if (placedShips.Contains(vessel))
                throw new ShipAlreadyPlacedException();

            if (placedShips.Exists(x => x.GetType().Equals(vessel.GetType())))
            {
                throw new ShipAlreadyPlacedException();
            }

            AddShipToGrid(position, vessel);

            placedShips.Add(vessel);
        }

        private void AddShipToGrid(Position coOrd, IShip vessel)
        {
            if (coOrd.Orientation == Orientation.Horizontal)
            {
                if (coOrd.X + vessel.Length < _width)
                {
                    for (int x = coOrd.X; x < (vessel.Length+ coOrd.X); x++)
                    {
                        if (array[x, coOrd.Y] != GridValues.EmptyCellValue)
                        {
                            throw new InvalidShipPlacementException(string.Format("There is already a ship here:{0}",
                                                                                  array[x, coOrd.Y]));
                        }
                    }
                    //have checked ahead that the grid values are valid, now update the cells
                    for (int x = coOrd.X; x < (vessel.Length + coOrd.X); x++)
                    {
                        array[x, coOrd.Y] = vessel.GridValue;
                    }
                }
                else
                {
                    throw new InvalidShipPlacementException(
                        string.Format("Horizontal ship won't fit on the board, attempted to add: {0}",
                                      coOrd.ToString()));
                }
            }
            else
            {
                if (coOrd.Y + vessel.Length < _height)
                {
                    for (int y = coOrd.Y; y < (vessel.Length + coOrd.Y); y++)
                    {
                        if (array[coOrd.X, y] != GridValues.EmptyCellValue)
                        {
                            throw new InvalidShipPlacementException(string.Format("There is already a ship here:{0}",
                                                                                  array[coOrd.X, y]));
                        }
                    }
                    //have checked ahead that the grid values are valid, now update the cells
                    for (int y = coOrd.Y; y < (vessel.Length + coOrd.Y); y++)
                    {
                        array[coOrd.X, y] = vessel.GridValue;
                    }
                }
                else
                {
                    throw new InvalidShipPlacementException(
                       string.Format("Vertical ship won't fit on the board, attempted to add: {0}",
                                     coOrd.ToString()));
                }


            }
        }
    }
}