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
            //MonsterList = Monster.GetMockedList();
            UserList = new List<UserModel>();
        }


        public List<Monster> MonsterList { get; set; }
        public List<UserModel> UserList { get; set; }
        public List<MapPathCoordinate> PathCoordinates { get; set; }
    }
}
