using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.GameManagerSingleton;
using TowerDefense.Models.Monster;
using TowerDefense.Models.Observer;
using TowerDefense.Models.Tower;
using TowerDefense.SignalR.Models;

namespace TowerDefense.SignalR.GameFlowHelpers
{
    public class GameFlowOperations
    {
        public void GameTickOperations(List<Monster> monsters, List<Monster> deadMonsters, List<BuiltTower> towers, Score score)
        {
            DoDamage(monsters, deadMonsters, towers, score);
            MoveMonsters(monsters);            
        }

        public void MoveMonsters(List<Monster> monsters)
        {
            foreach (var monster in monsters)
            {
                monster.MovementMethod.Move(monster);
            }
        }

        private void DoDamage(List<Monster> monsters, List<Monster> deadMonsters, List<BuiltTower> towers, Score score)
        {
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
                        ScoreUpdate(score, monster.MonsterType);
                    }
                }
            }

            monsters.RemoveAll(x => deadMonsters.Contains(x));
        }

        private void ScoreUpdate(Score score, int monsterType)
        {
            //int currentScore = score.GetScore();
            score.ProcessScore(monsterType);
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
