using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Models.Tower;

namespace TowerDefense.Models.Memento
{
    public class TowerCaretaker
    {
        public BuiltTower Originator { get; set; }
        public Stack<TowerMemento> Mementos { get; set; }

        public void Backup()
        {
            Mementos.Push(Originator.CreateMemento());
        }

        public void Restore()
        {
            if (Mementos.Count == 0) return;

            TowerMemento towerMemento = Mementos.Pop();
            Originator.SetMemento(towerMemento);
        }
    }
}
