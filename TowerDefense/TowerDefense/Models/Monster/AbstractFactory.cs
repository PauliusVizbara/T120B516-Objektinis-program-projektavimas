using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Models.Monster
{
    public abstract class AbstractFactory
    {
        public abstract BlackMonster CreateBlackMonster(int index);
        public abstract RedMonster CreateRedMonster(int index);

    }
}
