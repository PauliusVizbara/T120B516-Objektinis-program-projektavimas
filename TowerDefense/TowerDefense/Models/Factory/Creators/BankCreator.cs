using System;
using System.Collections.Generic;
using System.Text;
using TowerDefense.Models.Factory.Towers;

namespace TowerDefense.Models.Factory.Creators
{
    class BankCreator : TowerCreator
    {
        private int money;
        private string type;

        public BankCreator(int money, string type)
        {
            this.money = money;
            this.type = type;
        }

        public override Tower createTower()
        {
            return new BankTower(money, type);
        }
    }
}
