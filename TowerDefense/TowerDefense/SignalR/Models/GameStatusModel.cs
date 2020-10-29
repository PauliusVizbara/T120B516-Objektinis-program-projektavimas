using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Data;
using TowerDefense.Models;
using TowerDefense.Models.Monster;

namespace TowerDefense.SignalR.Models
{
    public class GameStatusModel
    {
        
        public GameStatusModel()
        {
            List<Monster> monsters = GetMockedList();
            MonsterList = monsters;
            UserList = new List<UserModel>();
        }

        public List<Monster> GetMockedList()
        {
            AbstractFactory fastFactory = new FastFactory();
            AbstractFactory strongFactory = new StrongFactory();
            AbstractFactory weakFactory = new WeakFactory();
            var monsters = new List<Monster>();
            for (int i = 1; i < 10; i++)
            {
                var weakmonster = weakFactory.CreateRedMonster(i);
                weakmonster.SetPosition(i * 2 - 20);
                monsters.Add(weakmonster);
                i++;

                var fastmonster1 = fastFactory.CreateRedMonster(i);
                fastmonster1.SetPosition(i * 2 - 20);
                monsters.Add(fastmonster1);
                i++;

                var fastmonster2 = fastFactory.CreateRedMonster(i);
                fastmonster2.SetPosition(i * 2 - 20);
                monsters.Add(fastmonster2);
            }
            return monsters;
        }


        public List<Monster> MonsterList { get; set; }
        public List<UserModel> UserList { get; set; }
        public List<MapPathCoordinate> PathCoordinates { get; set; }
    }
}
