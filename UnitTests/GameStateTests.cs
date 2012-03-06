using Battleships;
using Battleships.Enums;
using Battleships.Ships;
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

        [Test]
        public void InitalizesInShipDeploymentPhase()
        {
            Assert.True(gamestate.IsShipDeploymentPhase());
        }

        [Test]
        public void ShipDeploymentEndsWhenAllShipsPlaced()
        {
            gamestate.AddPlayerShip(new AircraftCarrier(new Position(0, 9, Orientation.Horizontal)));
            gamestate.AddPlayerShip(new BattleShip(new Position(0, 0, Orientation.Horizontal)));
            gamestate.AddPlayerShip(new Submarine(new Position(4, 1, Orientation.Horizontal)));
            gamestate.AddPlayerShip(new Destroyer(new Position(4, 3, Orientation.Vertical) ));
            gamestate.AddPlayerShip(new Minesweeper(new Position(7, 7, Orientation.Vertical)));

            Assert.False(gamestate.IsShipDeploymentPhase());
        }
    }
}