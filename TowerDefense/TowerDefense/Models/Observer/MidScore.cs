using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Models.Observer
{
    public class MidScore : Score
    {
        public override void AddScore(int score)
        {
            this.SetScore(score + 150);
        }

        public override void ProcessScore(string monsterType, int score)
        {
            if (monsterType == "Fast")
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
