﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Models.Monster.Black;
using TowerDefense.Models.Monster.Red;

namespace TowerDefense.Models.Monster
{
    public class FastFactory : AbstractFactory
    {

        public override BlackMonster CreateBlackMonster(int index)
        {
            return new FastBlackMonster(index, 120, 5);
        }

        public override RedMonster CreateRedMonster(int index)
        {
            return new FastRedMonster(index, 90, 5);
        }
    }
}
