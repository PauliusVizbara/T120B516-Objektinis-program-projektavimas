using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.GameManagerSingleton;
using TowerDefense.Models.Monster;
using TowerDefense.Models.Tower;
using TowerDefense.SignalR.Models;

namespace TowerDefense.SignalR.GameFlowHelpers
{
    public class GameFlowOperations
    {
        public void GameTickOperations(List<Monster> monsters, List<BuiltTower> towers)
        {
            DoDamage(monsters, towers);
            MoveMonsters(monsters);            
        }

        private void MoveMonsters(List<Monster> monsters)
        {
            foreach (var monster in monsters)
            {
                monster.MovementMethod.Move(monster);
            }
        }

        private void DoDamage(List<Monster> monsters, List<BuiltTower> towers)
        {
            List<Monster> deadMonsters = new List<Monster>();
            foreach (var tower in towers)
            {
                foreach (var monster in monsters)
                {
                    if (IsMonsterInRange(monster, tower))
                    {
                        monster.CurrentHealth -= 20; //TODO: Pasiimti pagal tower tipa
                    }
                    if (monster.CurrentHealth < 1)
                    {
                        deadMonsters.Add(monster); //TODO: Notify Score tracker
                    }
                }
            }

            monsters.RemoveAll(x => deadMonsters.Contains(x));
        }

        private bool IsMonsterInRange(Monster monster, BuiltTower tower)
        {
            double distance = 100;
            if (monster.Position > 0)
            {
                distance = GetDistance(monster.XCoordinate, monster.YCoordinate, tower.xCoordinate, tower.yCoordinate);
            }

            return distance < 4; //TODO: Pasiimti pagal tower tipa
        }

        private static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
    }
}
