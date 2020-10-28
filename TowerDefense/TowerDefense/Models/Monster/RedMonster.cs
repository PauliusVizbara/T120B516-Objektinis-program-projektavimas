using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Models.Monster
{
    public abstract class RedMonster
    {
        public abstract int GetMonsterIndex();

        public abstract double GetCurrentHealth();

        public abstract int GetLoot();

        public abstract string GetMonsterType();
    }
}
