using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Models.Monster.Red
{
    public class WeakRedMonster : RedMonster
    {

        public override double Health()
        {
            return 60;
        }

    }
}
