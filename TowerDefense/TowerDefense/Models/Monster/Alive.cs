using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Models.Monster
{
    public class Alive : MonsterState
    {

        public override void Kill()
        {
            this.Handle.TransitionTo(new Dead());
        }
    }
}
