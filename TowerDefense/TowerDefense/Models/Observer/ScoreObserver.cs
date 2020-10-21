using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Models.Observer
{
    public class ScoreObserver : IObserver<Score>
    {
        public void Update(Score data)
        {
            Console.WriteLine(String.Format("The score is {0}", data.score));
        }

    }
}
