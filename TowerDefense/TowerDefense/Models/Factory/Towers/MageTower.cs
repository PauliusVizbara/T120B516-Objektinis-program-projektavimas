using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Models.Factory.Towers
{
    class MageTower : Tower
    {
        private readonly string name;
        public int range;
        public int damage;
        public string type;

        public MageTower(int range, int damage, string type)
        {
            this.name = "Mage";
            this.range = range;
            this.damage = damage;
            this.type = type;
        }


        public override String getInfo()
        {
            return String.Format("Name: {0}, Range is {1} Damage is {2} Type is {3}", name, range, damage, type);
        }

        public override int GetDamage()
        {
            return damage;
        }

        public override int GetRange()
        {
            return range;
        }
    }
}
