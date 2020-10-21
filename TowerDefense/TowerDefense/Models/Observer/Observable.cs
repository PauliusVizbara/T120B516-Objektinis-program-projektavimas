using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Models.Observer
{
    public class Observable<T>
    {
        private List<IObserver<T>> observers = new List<IObserver<T>>();
        private T subject;

        public T Subject
        {
            get => subject;
            set
            {
                subject = value;
                Notify();
            }
        }

        public void Attach(IObserver<T> observer)
        {
            Console.WriteLine("Subject: Attached an observer.");
            observers.Add(observer);
        }

        public void Detach(IObserver<T> observer)
        {
            observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.");
        }

        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers...");

            observers.ForEach(x => x.Update(subject));
        }
    }
}
