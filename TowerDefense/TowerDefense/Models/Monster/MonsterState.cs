using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Models.Monster
{
    public abstract class MonsterState
    {
        protected Monster Handle { get; set; }

        public void SetMonsterState(Monster Handle)
        {
            this.Handle = Handle;
        }

        public virtual void Kill() { }
    }
}
