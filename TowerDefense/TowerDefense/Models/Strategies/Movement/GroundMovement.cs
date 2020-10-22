using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.SignalR.Models;
using TowerDefense.Models.Monster;
using TowerDefense.GameManagerSingleton;

namespace TowerDefense.Models.Strategies.Movement
{
    public class GroundMovement : MovementStrategy
    {
        GameManager gameManager = GameManager.GetGameManager();
        public override void Move(Monster.Monster monster)
        {
            var coordinates = gameManager.GetCoordinates();
            monster.Position++;
            var coordinatesByPosition = coordinates.FirstOrDefault(x => x.CoordinateIndex == monster.Position);
            monster.XCoordinate = coordinatesByPosition != null ? coordinatesByPosition.XCoordinate : 0;
            monster.YCoordinate = coordinatesByPosition != null ? coordinatesByPosition.YCoordinate : 0;                 
        }
    }
}
