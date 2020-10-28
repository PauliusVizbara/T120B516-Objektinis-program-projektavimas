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
        public override BlackMonster CreateBlackMonster(int index)
        {
            return new FastBlackMonster(index, 150, 5);
        }

        public override RedMonster CreateRedMonster(int index)
        {
            return new FastRedMonster(index, 120, 5);
        }

    }
}
