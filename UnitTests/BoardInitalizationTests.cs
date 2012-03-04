using System.Text;
using Battleships;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class BoardInitalizationTests
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
                    Assert.AreEqual(GridValues.EmptyCellValue, board.GetCellValue(x, y));
                }
            }
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
    }
}
