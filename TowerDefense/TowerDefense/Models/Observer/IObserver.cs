using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Models.Observer
{
    public interface IObserver<T>
    {

        void Update(T data);

    }
}
