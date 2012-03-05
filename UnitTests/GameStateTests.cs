using Battleships;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class GameStateTests
    {
        private Gamestate gamestate;

        [SetUp]
        public void Setup()
        {
            gamestate = new Gamestate();
        }

        [Test]
        public void GameStateInitializesCorrectly()
        {
            Assert.False(gamestate.IsGameOver());
        }
    }
}