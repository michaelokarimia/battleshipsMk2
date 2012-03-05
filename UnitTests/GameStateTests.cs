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
            gamestate.AddPlayerShip(new Position(0, 9, Orientation.Horizontal), new AircraftCarrier());
            gamestate.AddPlayerShip(new Position(0, 0, Orientation.Horizontal), new BattleShip());
            gamestate.AddPlayerShip(new Position(4, 1, Orientation.Horizontal), new Submarine());
            gamestate.AddPlayerShip(new Position(4, 3, Orientation.Vertical), new Destroyer());
            gamestate.AddPlayerShip(new Position(7, 7, Orientation.Vertical), new Minesweeper());

            Assert.False(gamestate.IsShipDeploymentPhase());
        }
    }
}