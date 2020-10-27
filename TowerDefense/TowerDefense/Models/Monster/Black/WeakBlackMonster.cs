using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Models.Monster.Black
{
    public class WeakBlackMonster : BlackMonster
    {
        public override double Health()
        {
            return 90;
        }
    }
}
