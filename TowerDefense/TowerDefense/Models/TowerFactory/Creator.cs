using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Models.MapFactory;

namespace TowerDefense.Models.TowerFactory
{
    abstract class Creator
    {
        public abstract GameTower GetTower();
    }
}
