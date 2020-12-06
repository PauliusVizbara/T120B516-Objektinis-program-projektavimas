using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Models.Observer
{
    public class BigScore : Score
    {

        public override void AddScore(int score)
        {
            this.SetScore(score + 200);
        }

        public override void ProcessScore(string monsterType, int score)
        {
            if (monsterType == "Strong")
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
