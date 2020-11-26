using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Decorator;

namespace TowerDefense.Models.Decorator
{
    public class MoneyUpgrade : UpgradeTower
    {

        public MoneyUpgrade(CTower wrappee) : base(wrappee)
        {
            this._Money = 1000;
        }
    }
}
