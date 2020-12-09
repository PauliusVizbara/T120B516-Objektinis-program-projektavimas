using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Models.Observer
{
    public class MidScore : Score
    {
        public override void AddScore()
        {
            this.score += 100;
        }

        public override void ProcessScore(int monsterType)
        {
            if (monsterType == 2)
            {
                AddScore();
            }
            else if (nextScore != null)
            {
                nextScore.ProcessScore(monsterType);
            }
        }
    }
}
