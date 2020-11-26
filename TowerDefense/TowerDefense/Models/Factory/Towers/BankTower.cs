using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Models.Factory.Towers
{
    public class BankTower : Tower
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public string Type { get; set; }

        public BankTower(int money, string type)
        {
            this.Name = "Bank";
            this.Money = money;
            this.Type = type;
        }


        public override String getInfo()
        {
            return String.Format("Name: {0}, Money create every round {1} Type is {2}", Name, Money, Type);
        }

        public override int GetMoney()
        {
            return Money;
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
