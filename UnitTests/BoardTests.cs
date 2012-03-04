using NUnit.Framework;

namespace Battleships
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
            for (var i = 0; i < HEIGHT; i++)
            {
                for (var j = 0; j < WIDTH; j++)
                {
                    Assert.AreEqual(GridValues.EMPTY_CELL_VALUE,board.GetCellValue(i, j));
                }
            }
        }

        [Test]
        public void ShotFiredAtEmptySquareIsAMiss()
        {
            board.FireShot(5, 5);
                  
            Assert.AreEqual(GridValues.MISSED_SHOT,board.GetCellValue(5,5));
        }
    }
}
