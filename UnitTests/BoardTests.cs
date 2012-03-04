using System;
using System.Text;
using Battleships;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class BoardTests
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
        public void InitalizesWithCorrectWidth()
        {
            Assert.AreEqual(WIDTH, board.Width());
        }
        
        [Test]
        public void InitalizesWithCorrectHeight()
        {
            Assert.AreEqual(HEIGHT, board.Height());
        }

        [Test]
        public void IntializesWithEveryCellWithEmptySquareValue()
        {
            for (var x = 0; x < WIDTH; x++)
            {
                for (var y = 0; y < HEIGHT; y++)
                {
                    Assert.AreEqual(GridValues.EmptyCellValue,board.GetCellValue(x, y));
                }
            }
        }

        [Test]
        public void ShotFiredAtEmptySquareIsAMiss()
        {
            board.FireShot(5, 5); 
            Assert.AreEqual(GridValues.MissedShot,board.GetCellValue(5,5));
        }

        [Test]
        public void ShotFiredTwiceASameSquareThrowsInvalidShotException()
        {
            board.FireShot(5, 5);
            Assert.Throws<InvalidShotException>(() => board.FireShot(5, 5), "Did not throw InvalidShotException after firing on the same square twice");
        }

        [Test]
        public void FiringOutsideOfBoardDimensionsThrowsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => board.FireShot(-1, 89),
                                     "Did not throw exception after firing outside the board dimensions");
        }

        [Test]
        public void ToStringMethodIsOverriden()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < HEIGHT; i++)
            {
                sb.AppendLine("-1-1-1-1-1-1-1-1-1-1");
            }
            string stringOutputOfGrid = sb.ToString();
            Assert.AreEqual(stringOutputOfGrid, board.ToString());
        }

        [Test]
        public void CanAddAnAircraftCarrierOnANewBoard()
        {
            var carrier = new AircraftCarrier();
            board.AddShip(carrier);
        }

        [Test]
        public void AddingSameAircraftCarrierTwiceThrowsException()
        {
            var carrier = new AircraftCarrier();
            board.AddShip(carrier);
            Assert.Throws<ShipAlreadyPlacedException>(() => board.AddShip(carrier));
        }

        [Test]
        public void AddingSecondAircraftCarrierThrowsException()
        {
            var carrier = new AircraftCarrier();
            board.AddShip(carrier);
            var carrier2 = new AircraftCarrier();
            Assert.Throws<ShipAlreadyPlacedException>(() => board.AddShip(carrier2));
        }
    }
    
}
