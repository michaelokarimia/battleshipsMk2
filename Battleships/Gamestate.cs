using System;
using Battleships.Enums;
using Battleships.Ships;

namespace Battleships
{
    public class Gamestate
    {
        private Board board = new Board(10, 10);
        private bool _IsShipDeploymentPhase;

        public Gamestate()
        {
            _IsShipDeploymentPhase = true;
        }
        public bool IsGameOver()
        {
            return false;
        }

        public bool IsShipDeploymentPhase()
        {
            return _IsShipDeploymentPhase;
        }

        public void AddPlayerShip(Position position, IShip vessel)
        {
            board.AddShip(vessel, position);
            _IsShipDeploymentPhase = !board.AreAllShipsPlaced();
        }
    }
}
