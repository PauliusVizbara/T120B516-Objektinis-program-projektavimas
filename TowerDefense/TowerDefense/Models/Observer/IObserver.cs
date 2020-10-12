using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Models.Observer
{
    public interface IObserver
    {

        void Update(ISubject subject);
    }
}
