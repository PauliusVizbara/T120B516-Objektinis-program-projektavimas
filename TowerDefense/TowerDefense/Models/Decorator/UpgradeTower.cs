using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Decorator
{
    public abstract class UpgradeTower : CTower
    {
        CTower wrappee = null;

        protected int _Damage = 0;

        protected int _Range = 0;

        protected int _Money = 0;

        protected UpgradeTower(CTower wrappee)
        {
            this.wrappee = wrappee;
        }


        public override int GetDamage()
        {
            return (wrappee.GetDamage() + _Damage);
        }

        public override int GetRange()
        {
            return (wrappee.GetRange() + _Range);
        }

        public override int GetMoney()
        {
            return (wrappee.GetMoney() + _Money);
        }


        public override String getInfo()
        {
            return wrappee.getInfo();
        }

    }
}
