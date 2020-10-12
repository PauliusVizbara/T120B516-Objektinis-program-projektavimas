using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Models.Observer
{
    public class ScoreSystem : ISubject
    {
        private List<IObserver> _observers;

        public int Score
        {
            get { return _score; } 
            set
            {
                _score = value;
                Notify();
            }


        }
        private int _score;

        public ScoreSystem()
        {
            _observers = new List<IObserver>();
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Notify()
        {
            _observers.ForEach(o =>
            {
                o.Update(this);
            });
        }
    }
}
