using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Decorator
{
    public abstract class CTower
    {
        public abstract int GetDamage();
        public abstract int GetRange();

        public abstract int GetMoney();

        public abstract String getInfo();
    }
}
