using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Data;
using TowerDefense.Models;
using TowerDefense.Models.Monster;
using TowerDefense.Models.Tower;

namespace TowerDefense.SignalR.Models
{
    public class GameStatusModel
    {
        public GameStatusModel()
        {
            MonsterList = Monster.GetMockedList();
            DeadMonstersList = new List<Monster>();
            UserList = new List<UserModel>();
            //Towers = new List<BuiltTower>();
        }

        public List<Monster> MonsterList { get; set; }
        public List<Monster> DeadMonstersList { get; set; }
        public List<UserModel> UserList { get; set; }
        public List<MapPathCoordinate> PathCoordinates { get; set; }
        //public List<BuiltTower> Towers { get; set; }

        
    }
}
