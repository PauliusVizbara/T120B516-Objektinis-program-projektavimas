using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Models.Factory.Towers
{
    class BankTower : Tower
    {
        private readonly string name;
        public int money;
        public string type;

        public BankTower(int money, string type)
        {
            this.name = "Bank";
            this.money = money;
            this.type = type;
        }


        public override String getInfo()
        {
            return String.Format("Name: {0}, Money create every round {1} Type is {2}", name, money, type);
        }

        public override int GetDamage()
        {
            return 0;
        }

        public override int GetRange()
        {
            return 0;
        }
    }
}
