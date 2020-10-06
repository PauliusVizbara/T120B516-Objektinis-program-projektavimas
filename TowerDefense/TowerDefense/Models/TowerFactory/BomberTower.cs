using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Models.MapFactory
{
    class BomberTower : GameTower
    {
        public Int32 Id;
        public Int32 Range;
        public Int32 Damage;
        public String Type;

        public virtual String getInfo()
        {
            return String.Format("Range is {0} Damage is {1} Type is {2}", Range, Damage, Type);
        }

    }
}
