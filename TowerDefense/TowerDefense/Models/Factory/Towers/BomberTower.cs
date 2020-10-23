using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Models.Factory.Towers
{
    class BomberTower : Tower
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }
        public string Type { get; set; }

        public BomberTower(int range, int damage, string type)
        {
            this.Name = "Bomber";
            this.Range = range;
            this.Damage = damage;
            this.Type = type;
        }


        public override String getInfo()
        {
            return String.Format("Name: {0}, Range is {1} Damage is {2} Type is {3}", Name, Range, Damage, Type);
        }

        public override int GetDamage()
        {
            return Damage;
        }

        public override int GetRange()
        {
            return Range;
        }
    }
}
