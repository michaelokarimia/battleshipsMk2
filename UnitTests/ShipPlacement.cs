using System;
using System.Text;
using Battleships;
using Battleships.Enums;
using Battleships.Exceptions;
using Battleships.Ships;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class ShipPlacement
    {
        private Board board;
        private const int WIDTH = 10;
        private const int HEIGHT = 10;

        [SetUp]
        public void Setup()
        {
            board = new Board(WIDTH, HEIGHT);
        }
     
        [Test]
        public void CanAddShip()
        {
            var position = new Position(0,0,Orientation.Vertical);
            board.AddShip(new AircraftCarrier(), position);
        }

        [Test]
        public void AddingSameShipTwiceThrowsException()
        {
            var position = new Position(0, 0, Orientation.Vertical);
            var aircraftCarrier = new AircraftCarrier();
            board.AddShip(aircraftCarrier, position);
            Assert.Throws<ShipAlreadyPlacedException>(() => board.AddShip(aircraftCarrier, position));
        }

        [Test]
        public void AddingSecondAircraftCarrierThrowsException()
        {
            var position = new Position(0, 0, Orientation.Vertical);
            board.AddShip(new AircraftCarrier(), position);
            Assert.Throws<ShipAlreadyPlacedException>(() => board.AddShip(new AircraftCarrier(), position));
        }


        [Test]
        public void CanAddBattleShip()
        {
            var position = new Position(0, 0, Orientation.Vertical);
            board.AddShip(new BattleShip(), position);
        }

        [Test]
        public void CanAddTwoShips()
        {
            var position1 = new Position(0, 0, Orientation.Vertical);
            var position2 = new Position(1, 0, Orientation.Vertical);
            board.AddShip(new AircraftCarrier(), position1);
            board.AddShip(new BattleShip(), position2);
        }

        [Test]
        public void PlacingShipsOntopOfEachOtherThrowsException()
        {
            var position1 = new Position(0, 0, Orientation.Vertical);
            var position2 = new Position(0, 1, Orientation.Vertical);
            board.AddShip(new AircraftCarrier(), position1);
            Assert.Throws<InvalidShipPlacementException>(() => board.AddShip(new BattleShip(), position2));
        }

        [Test]
        public void CanAddHorizontalAndVerticalShipAsideEachOther()
        {
            var position1 = new Position(0, 0, Orientation.Horizontal);
            var position2 = new Position(0, 3, Orientation.Vertical);
            board.AddShip(new BattleShip(), position1);
            board.AddShip(new Destroyer(), position2);
        }

        [Test]
        public void HorizontalShipAndVerticalShipOverEachOtherThrowsException()
        {
            var position1 = new Position(0, 2, Orientation.Horizontal);
            var position2 = new Position(2, 0, Orientation.Vertical);
            board.AddShip(new BattleShip(), position1);
            Assert.Throws<InvalidShipPlacementException>(() => board.AddShip(new Destroyer(), position2));
        }

        [Test]
        public void TwoShipsVerticallyOverEachOtherThrowsException()
        {
            var position1 = new Position(4, 4, Orientation.Vertical);
            var position2 = new Position(4, 5, Orientation.Vertical);
            board.AddShip(new BattleShip(), position1);
            Assert.Throws<InvalidShipPlacementException>(() => board.AddShip(new Destroyer(), position2));
        }

        [Test]
        public void AddingShipUpdatesGridValues()
        {
            var position = new Position(0, 0, Orientation.Vertical);
            board.AddShip(new AircraftCarrier(), position);
            Assert.AreEqual(GridValues.AircraftcarrierIntact, board.GetCellValue(0,0));
        }

        [Test]
        public void AddingShipsOntopOfEachOtherThrowsException()
        {
            var position = new Position(0, 0, Orientation.Vertical);
            board.AddShip(new AircraftCarrier(), position);
            Assert.Throws<InvalidShipPlacementException>(() => board.AddShip(new BattleShip(), position));
        }

        [Test]
        public void AddingHorizontalShipOnTopOfAnotherThrowsException()
        {
            var position = new Position(1,7, Orientation.Horizontal);
            board.AddShip(new BattleShip(), position);
            var position2 = new Position(4,7,Orientation.Horizontal);
            Assert.Throws<InvalidShipPlacementException>(() => board.AddShip(new Destroyer(), position2));
        }

        [Test]
        public void PlacingShipOffHorizonalEdgeOfBoardThrowsException()
        {
            var position = new Position(9, 3, Orientation.Horizontal);
            Assert.Throws<InvalidShipPlacementException>(() => board.AddShip(new Destroyer(), position));
        }

        [Test]
        public void PlacingShipOffVerticalEdgeOfBoardThrowsException()
        {
            var position = new Position(4, 8, Orientation.Vertical);
            Assert.Throws<InvalidShipPlacementException>(() => board.AddShip(new Destroyer(), position));
        }

        [Test]
        public void AllShipsPlacedReturnsTrueWhenAll5ShipsArePlaced()
        {
             board.AddShip(new AircraftCarrier(), new Position(0, 0, Orientation.Horizontal));
             board.AddShip(new BattleShip(), new Position(0,1,Orientation.Horizontal));
             board.AddShip(new Destroyer(), new Position(0, 2, Orientation.Horizontal));
             board.AddShip(new Submarine(), new Position(0, 3, Orientation.Horizontal));
             board.AddShip(new Minesweeper(), new Position(0, 4, Orientation.Horizontal));

             Assert.True(board.AreAllShipsPlaced(), "Not every ship was placed");
        }

        [Test]
        public void AllShipsPlacedReturnFalseWhenNotAllShipsPlaced()
        {
            board.AddShip(new AircraftCarrier(), new Position(0, 0, Orientation.Horizontal));
            board.AddShip(new BattleShip(), new Position(0, 1, Orientation.Horizontal));
            
            Assert.False(board.AreAllShipsPlaced(), "Not every ship was placed, yet reported as true");
        }
    }
}
