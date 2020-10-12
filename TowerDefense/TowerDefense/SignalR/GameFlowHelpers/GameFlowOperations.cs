using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.GameManagerSingleton;
using TowerDefense.SignalR.Models;

namespace TowerDefense.SignalR.GameFlowHelpers
{
    public class GameFlowOperations
    {
        private GameManager gameManager = GameManager.GetGameManager();

        public void MoveMonstersPosition(List<MonsterModel> monsters)
        {
            var coordinates = gameManager.GetCoordinates();

            foreach (var monster in monsters)
            {
                monster.Position++;
                var coordinatesByPosition = coordinates.FirstOrDefault(x => x.CoordinateIndex == monster.Position);
                monster.XCoordinate = coordinatesByPosition.XCoordinate;
                monster.YCoordinate = coordinatesByPosition.YCoordinate;
            }
        }
    }
}
