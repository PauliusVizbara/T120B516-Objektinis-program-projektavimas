﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TowerDefense.Models.Observer
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Notify();
    }
}
