using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Models.Monster.Black;
using TowerDefense.Models.Monster.Red;

namespace TowerDefense.Models.Monster
{
    public class WeakFactory :AbstractFactory
    {

        public override BlackMonster CreateBlackMonster(int index)
        {
            return new WeakBlackMonster(index, 90, 5);
        }

        public override RedMonster CreateRedMonster(int index)
        {
            return new WeakRedMonster(index, 60, 5);
        }
    }
}
