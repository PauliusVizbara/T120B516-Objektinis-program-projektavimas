using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Decorator
{
    class RangeUpgrade : UpgradeTower
    {
        public RangeUpgrade(CTower wrappee) : base(wrappee)
        {
            this._Range = 10;
        }


        //public override int range
        //{
        //    get
        //    {
        //        return base.Range + 3;
        //    }
        //}
            

        //public override String getInfo()
        //{
        //    return base.getInfo();
        //}
    }
}
