using System;
using System.Collections.Generic;
using System.Text;
using TowerDefense.Models.Factory.Towers;

namespace TowerDefense.Models.Factory.Creators
{
    class FreezeCreator : TowerCreator
    {
        private int range;
        private int damage;
        private string type;

        public FreezeCreator(int range, int damage, string type)
        {
            this.range = range;
            this.damage = damage;
            this.type = type;
        }

        public override Tower createTower()
        {
            return new FreezeTower(range, damage, type);
        }
    }
}
