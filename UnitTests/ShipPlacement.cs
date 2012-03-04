using System;
using System.Text;
using Battleships;
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
        public void CanAddAnAircraftCarrierOnANewBoard()
        {
            var position = new Position(0,0,Orientation.Vertical);
            board.AddShip(new AircraftCarrier(), position);
        }

        [Test]
        public void AddingSameAircraftCarrierTwiceThrowsException()
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
        public void CanAddAnBattleShipOnANewBoard()
        {
            var position = new Position(0, 0, Orientation.Vertical);
            board.AddShip(new BattleShip(), position);
        }

        [Test]
        public void CanAddAircraftcarrierAndBattleShipOnANewBoard()
        {
            var position1 = new Position(0, 0, Orientation.Vertical);
            var position2 = new Position(1, 0, Orientation.Vertical);
            board.AddShip(new AircraftCarrier(), position1);
            board.AddShip(new BattleShip(), position2);
        }

        [Test]
        public void AircraftcarrierAndBattleShipOntopOfEachOtherThrowsException()
        {
            var position1 = new Position(0, 0, Orientation.Vertical);
            var position2 = new Position(0, 1, Orientation.Vertical);
            board.AddShip(new AircraftCarrier(), position1);
            Assert.Throws<InvalidShipPlacementException>(() => board.AddShip(new BattleShip(), position2));
        }

        [Test]
        public void AddingAircraftcarrierUpdateGridValues()
        {
            var position = new Position(0, 0, Orientation.Vertical);
            board.AddShip(new AircraftCarrier(), position);
            Assert.AreEqual(GridValues.AircraftcarrierIntact, board.GetCellValue(0,0));
        }

        [Test]
        public void AddingAircraftcarrierOntopOfBattleShipThrowsException()
        {
            var position = new Position(0, 0, Orientation.Vertical);
            board.AddShip(new AircraftCarrier(), position);
            Assert.Throws<InvalidShipPlacementException>(() => board.AddShip(new BattleShip(), position));
        }
    }
}
