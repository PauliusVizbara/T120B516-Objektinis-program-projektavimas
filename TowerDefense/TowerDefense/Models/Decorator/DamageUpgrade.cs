using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Decorator
{
    public class DamageUpgrade : UpgradeTower
    {
        public DamageUpgrade(CTower wrappee) : base(wrappee)
        {
            this._Damage = 110;
        }
    }
}
