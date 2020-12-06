using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Models.Observer
{
    public abstract class Score
    {
        protected Score nextScore;
        private string name;
        private int score;

        public Score()
        {
            this.name = "Gold";
            this.score = 100;
        }

        public void SetProccess(Score score)
        {
            this.nextScore = score;
        }

        public abstract void AddScore(int score);

        public abstract void ProcessScore(string monsterType, int score);

        public string GetName()
        {
            return name;
        }

        public void SetName(string value)
        {
            name = value;
        }

        

        public int GetScore()
        {
            return score;
        }

        public void SetScore(int value)
        {
            score = value;
        }

        
    }
}
