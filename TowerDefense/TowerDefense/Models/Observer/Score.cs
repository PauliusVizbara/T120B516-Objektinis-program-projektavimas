using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Models.Observer
{
    public class Score
    {
        public string name { get; set; }
        public int score { get; set; }
        public Score(string name, int value)
        {
            this.name = name;
            this.score = value;
        }
    }
}
