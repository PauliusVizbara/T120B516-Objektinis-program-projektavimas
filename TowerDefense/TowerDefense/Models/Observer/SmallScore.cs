using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Models.Observer
{
    public class SmallScore : Score
    {
        public override void AddScore(int score)
        {
            this.SetScore(score + 100);
        }

        public override void ProcessScore(string monsterType, int score)
        {
            if (monsterType == "Weak")
            {
                AddScore(score);
            }
            else if (nextScore != null)
            {
                nextScore.ProcessScore(monsterType, score);
            }
        }
    }
}
