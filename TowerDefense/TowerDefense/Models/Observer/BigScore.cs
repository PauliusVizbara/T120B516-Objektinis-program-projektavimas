using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Models.Observer
{
    public class BigScore : Score
    {

        public override void AddScore()
        {
            this.score += 150;
        }

        public override void ProcessScore(int monsterType)
        {
            if (monsterType == 3)
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
