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

        [SetUp]
        public void Setup()
        {
            grid = new Grid(10, 10);
        }

        [Test]
        public void InitalizesATwoDimensionalArrayWithCorrectWidth()
        {
            Assert.AreEqual(10, grid.Width());
        }
        
        [Test]
        public void InitalizesATwoDimensionalArrayWithCorrectHeight()
        {
            Assert.AreEqual(10, grid.Height());
        }

        
    }
}
