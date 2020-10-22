using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.SignalR.Models;
using TowerDefense.Models.Monster;

namespace TowerDefense.Models.Strategies
{
    public abstract class MovementStrategy
    {
        public abstract void Move(Monster.Monster monster);
    }
}
