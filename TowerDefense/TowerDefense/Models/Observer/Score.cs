using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Models.Observer
{
    public class Score : IObserver
    {

        public void Update(ISubject subject)
        {
            if (subject is ScoreSystem scoreSystem)
            {
                Console.WriteLine(String.Format("The score is {0}", scoreSystem.Score));
            }
        }
    }
}
