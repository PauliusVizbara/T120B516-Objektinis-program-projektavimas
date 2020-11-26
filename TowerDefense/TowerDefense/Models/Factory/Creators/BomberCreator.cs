using System;
using System.Collections.Generic;
using System.Text;
using TowerDefense.Models.Factory.Towers;

namespace TowerDefense.Models.Factory.Creators
{
    public class BomberCreator : TowerCreator
    {
        private int range;
        private int damage;
        private string type;

        public BomberCreator(int range, int damage, string type)
        {
            this.range = range;
            this.damage = damage;
            this.type = type;
        }


        public override Tower createTower()
        {
            return new BomberTower(range, damage, type);
        }
    }
}
