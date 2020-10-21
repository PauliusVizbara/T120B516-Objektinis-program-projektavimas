using System;
using System.Collections.Generic;
using System.Text;
using TowerDefense.Models.Factory.Towers;

namespace TowerDefense.Models.Factory.Creators
{
    class MageCreator : TowerCreator
    {
        private int range;
        private int damage;
        private string type;

        public MageCreator(int range, int damage, string type)
        {
            this.range = range;
            this.damage = damage;
            this.type = type;
        }

        public override Tower createTower()
        {
            return new MageTower(range, damage, type);
        }
    }
}
