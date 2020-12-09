using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Models.Observer
{
    public class SmallScore : Score
    {
        public override void AddScore()
        {
            this.score += 50;
        }

        public override void ProcessScore(int monsterType)
        {
            if (monsterType == 1)
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
