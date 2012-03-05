using System;
using Battleships;
using Battleships.Enums;
using Battleships.Exceptions;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class ShotTests
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
        public void ShotFiredAtEmptySquareIsAMiss()
        {
            board.FireShot(5, 5);
            Assert.AreEqual(GridValues.MissedShot, board.GetCellValue(5, 5));
        }

        [Test]
        public void ShotFiredTwiceASameSquareThrowsException()
        {
            board.FireShot(5, 5);
            Assert.Throws<InvalidShotException>(() => board.FireShot(5, 5), "Did not throw InvalidShotException after firing on the same square twice");
        }

        [Test]
        public void FiringOutsideOfBoardDimensionsException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => board.FireShot(-1, 89),
                                     "Did not throw exception after firing outside the board dimensions");
        }
    }
}
