using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.GameManagerSingleton;
using TowerDefense.Models.Monster;
using TowerDefense.SignalR.Models;

namespace TowerDefense.SignalR.GameFlowHelpers
{
    public class GameFlowOperations
    {
        private GameManager gameManager = GameManager.GetGameManager();

        public void MoveMonstersPosition(List<Monster> monsters)
        {
            var coordinates = gameManager.GetCoordinates();

            foreach (var monster in monsters)
            {
                monster.Position++;
                var coordinatesByPosition = coordinates.FirstOrDefault(x => x.CoordinateIndex == monster.Position);
                monster.XCoordinate = coordinatesByPosition != null ? coordinatesByPosition.XCoordinate : 0;
                monster.YCoordinate = coordinatesByPosition != null ? coordinatesByPosition.YCoordinate : 0;
            }
        }
    }
}
