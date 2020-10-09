using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Data;

namespace TowerDefense.SignalR.Models
{
    public class GameStatusModel
    {
        public GameStatusModel()
        {
            MonsterList = MonsterModel.GetMockedList();
            UserList = new List<UserModel>();
        }

        public List<MonsterModel> MonsterList { get; set; }
        public List<UserModel> UserList { get; set; }
        public List<MapPathCoordinate> PathCoordinates { get; set; }
    }
}
