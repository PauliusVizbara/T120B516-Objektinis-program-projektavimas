using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.SignalR.Models
{
    public class MonsterModel
    {
        public int MonsterIndex { get; set; }
        public double CurrentHealth { get; set; }
        public int Loot { get; set; }
        public int Position { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public static List<MonsterModel> GetMockedList()
        {
            var monsters = new List<MonsterModel>();
            for (int i = 1; i <= 10; i++)
            {
                monsters.Add(new MonsterModel
                {
                    MonsterIndex = i,
                    CurrentHealth = 100,
                    Loot = 5,
                    Position = i * 2 - 20
                });
            }
            return monsters;
        }

    }
}
