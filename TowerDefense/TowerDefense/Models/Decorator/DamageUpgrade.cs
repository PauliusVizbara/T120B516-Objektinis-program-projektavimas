using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Decorator
{
    class DamageUpgrade : UpgradeTower
    {
        public DamageUpgrade(CTower wrappee) : base(wrappee)
        {
            this._Damage = 110;
        }

    }
}
