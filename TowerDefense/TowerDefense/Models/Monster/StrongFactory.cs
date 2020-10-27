using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Models.Monster.Black;
using TowerDefense.Models.Monster.Red;

namespace TowerDefense.Models.Monster
{
    class StrongFactory : AbstractFactory
    {
        public override BlackMonster CreateBlackMonster()
        {
            return new FastBlackMonster();
        }

        public override RedMonster CreateRedMonster()
        {
            return new FastRedMonster();
        }

    }
}
