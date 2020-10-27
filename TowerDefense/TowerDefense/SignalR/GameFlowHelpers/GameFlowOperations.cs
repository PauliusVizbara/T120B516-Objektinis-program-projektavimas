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
            foreach (var monster in monsters)
            {
                monster.MovementMethod.Move(monster);
            }
        }
    }
}
