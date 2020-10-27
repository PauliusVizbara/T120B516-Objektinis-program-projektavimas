using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Models.Monster
{
    abstract class AbstractFactory
    {
        public abstract BlackMonster CreateBlackMonster();
        public abstract RedMonster CreateRedMonster();

    }
}
