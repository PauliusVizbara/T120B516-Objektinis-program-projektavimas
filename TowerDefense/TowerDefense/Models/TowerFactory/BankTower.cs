using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Models.MapFactory;

namespace TowerDefense.Models.TowerFactory
{
    public class BankTower : GameTower
    {
        public Int32 Id;
        public Int32 Money;
        public String Type;

        public virtual String getInfo()
        {
            return String.Format("Money makes per round {0} Type is {1}", Money, Type);
        }
    }
}
