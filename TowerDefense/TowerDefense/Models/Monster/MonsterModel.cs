using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Models.Strategies;
using TowerDefense.Models.Strategies.Movement;

namespace TowerDefense.Models.Monster
{
    public class Monster
    {
        public int MonsterIndex { get; set; }
        public double CurrentHealth { get; set; }
        public int Loot { get; set; }
        public int Position { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int MonsterType { get; set; }
        public MovementStrategy MovementMethod { get; set; }
        public static List<Monster> GetMockedList()
        {
            Random rnd = new Random();
            var movementStrategies = new MovementStrategy[] { new GroundMovement(), new UnderGroundMovement(), new AirMovement()};
            var monsters = new List<Monster>();
            for (int i = 1; i <= 10; i++)
            {
                monsters.Add(new Monster
                {
                    MonsterIndex = i,
                    CurrentHealth = 100,
                    Loot = 5,
                    Position = i * 2 - 20,
                    MonsterType = rnd.Next(1,4),
                    MovementMethod = movementStrategies[rnd.Next(0,3)]

                });
            }
            return monsters;
        }

    }
}
