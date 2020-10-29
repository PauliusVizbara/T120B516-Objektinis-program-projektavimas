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
            monster.SetPosition(monster.GetPosition() + 1);
            var coordinatesByPosition = coordinates.FirstOrDefault(x => x.CoordinateIndex == monster.GetPosition());
            if (coordinatesByPosition != null)
            {
                monster.SetXCoordinate(coordinatesByPosition.XCoordinate);
                monster.SetYCoordinate(coordinatesByPosition.YCoordinate);
            }
            else
            {
                monster.SetXCoordinate(0);
                monster.SetYCoordinate(0);
            }
        }
    }
}
