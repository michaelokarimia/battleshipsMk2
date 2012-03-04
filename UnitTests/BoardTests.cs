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
            Assert.AreEqual(GridValues.EmptyCellValue, board.GetCellValue(5,5));
            board.FireShot(5, 5); 
            Assert.AreEqual(GridValues.MissedShot,board.GetCellValue(5,5));
        }
    }
}
