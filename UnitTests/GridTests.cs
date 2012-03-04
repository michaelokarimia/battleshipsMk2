using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Battleships;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class GridTests
    {
        private Grid grid;
        private const int EMPTY_CELL_VALUE = 0;
        private const int WIDTH = 10;
        private const int HEIGHT = 10;

        [SetUp]
        public void Setup()
        {
            grid = new Grid(WIDTH, HEIGHT);
        }

        [Test]
        public void InitalizesATwoDimensionalArrayWithCorrectWidth()
        {
            Assert.AreEqual(WIDTH, grid.Width());
        }
        
        [Test]
        public void InitalizesATwoDimensionalArrayWithCorrectHeight()
        {
            Assert.AreEqual(HEIGHT, grid.Height());
        }

        [Test]
        public void IntializesWithEveryCellWithEmptySquareValue()
        {
            for (var i = 0; i < HEIGHT; i++)
            {
                for (var j = 0; j < WIDTH; j++)
                {
                    Assert.AreEqual(EMPTY_CELL_VALUE,grid.GetCellValue(i, j));
                }
            }
        }
    }
}
