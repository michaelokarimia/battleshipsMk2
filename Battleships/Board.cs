using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Battleships.Enums;
using Battleships.Exceptions;
using Battleships.Ships;

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
            array = new GridValues[_width, _height];
  
            foreach (var x in Enumerable.Range(0, _width))
            {
                foreach (var y in Enumerable.Range(0, _height))
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

            foreach (var x in Enumerable.Range(0, _width))
            {
                foreach (var y in Enumerable.Range(0, _height))
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

        private void AddShipToGrid(Position gridSquare, IShip vessel)
        {
            switch (gridSquare.Orientation)
            {
                case Orientation.Horizontal:
                    PlaceShipHorizontally(gridSquare, vessel);
                    break;
                    case Orientation.Vertical:
                    PlaceShipVertically(gridSquare, vessel);
                    break;
            }
        }

        private void PlaceShipVertically(Position shipPosition, IShip vessel)
        {
            if (shipPosition.Y + vessel.Length >= _height)
            {
                throw new InvalidShipPlacementException(
                    string.Format("Vertical ship won't fit on the board, attempted to add: {0}",
                                  shipPosition.ToString()));
            }
            int row = shipPosition.X;

            for (int y = shipPosition.Y; y < (vessel.Length + shipPosition.Y); y++)
            {
                if (array[row, y] != GridValues.EmptyCellValue)
                {
                    throw new InvalidShipPlacementException(string.Format("There is already a ship here:{0}",
                                                                          array[row, y]));
                }
            }

            for (int y = shipPosition.Y; y < (vessel.Length + shipPosition.Y); y++)
            {
                array[row, y] = vessel.GridValue;
            }
        }

        private void PlaceShipHorizontally(Position shipPosition, IShip vessel)
        {
            if (shipPosition.X + vessel.Length >= _width)
            {
                throw new InvalidShipPlacementException(
                    string.Format("Horizontal ship won't fit on the board, attempted to add: {0}",
                                  shipPosition.ToString()));
            }
            for (var x = shipPosition.X; x < (vessel.Length + shipPosition.X); x++)
            {
                if (array[x, shipPosition.Y] != GridValues.EmptyCellValue)
                {
                    throw new InvalidShipPlacementException(string.Format("There is already a ship here:{0}",
                                                                          array[x, shipPosition.Y]));
                }
            }
            
            for (var x = shipPosition.X; x < (vessel.Length + shipPosition.X); x++)
            {
                array[x, shipPosition.Y] = vessel.GridValue;
            }
        }

        public bool AreAllShipsPlaced()
        {
            return (
                placedShips.Any(x => x.GetType().Equals(typeof(AircraftCarrier))) && 
                placedShips.Any(x => x.GetType().Equals(typeof(BattleShip))) &&
                placedShips.Any(x => x.GetType().Equals(typeof(Submarine))) &&
                placedShips.Any(x => x.GetType().Equals(typeof(Destroyer))) &&
                placedShips.Any(x => x.GetType().Equals(typeof(Minesweeper)))
                );
        }
    }
}