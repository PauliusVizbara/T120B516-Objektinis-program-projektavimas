using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Decorator
{
    public class RangeUpgrade : UpgradeTower
    {
        public RangeUpgrade(CTower wrappee) : base(wrappee)
        {
            this._Range = 10;
        }

    }
}
