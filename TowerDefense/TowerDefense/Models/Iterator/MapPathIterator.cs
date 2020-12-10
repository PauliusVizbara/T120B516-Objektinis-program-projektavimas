using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.Data;

namespace TowerDefense.Models.Iterator
{
    abstract class MapPathIterator : IEnumerator
    {
        object IEnumerator.Current => Current();

        public abstract int Key();

        public abstract object Current();

        public abstract bool MoveNext();

        public abstract void Reset();
    }

    public abstract class IteratorAggregate : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }

    class OrderIterator : MapPathIterator
    {
        private MapPathsCollection _collection;

        private int _position = -1;

        private bool _reverse = false;

        public OrderIterator(MapPathsCollection collection, bool reverse = false)
        {
            this._collection = collection;
            this._reverse = reverse;

            if (reverse)
            {
                this._position = collection.getItems().Count;
            }
        }

        public override object Current()
        {
            return this._collection.getItems()[_position];
        }

        public override int Key()
        {
            return this._position;
        }

        public override bool MoveNext()
        {
            int updatedPosition = this._position + (this._reverse ? -1 : 1);

            if (updatedPosition >= 0 && updatedPosition < this._collection.getItems().Count)
            {
                this._position = updatedPosition;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            this._position = this._reverse ? this._collection.getItems().Count - 1 : 0;
        }
    }

    public class MapPathsCollection : IteratorAggregate
    {
        List<MapPathCoordinate> _collection = new List<MapPathCoordinate>();

        bool _direction = false;

        public void ReverseDirection()
        {
            _direction = !_direction;
        }

        public List<MapPathCoordinate> getItems()
        {
            return _collection;
        }

        public void AddItem(List<MapPathCoordinate> items)
        {
            this._collection.AddRange(items);
        }

        public override IEnumerator GetEnumerator()
        {
            return new OrderIterator(this, _direction);
        }

        public MapPathCoordinate FirstOrDefault()
        {
            return _collection.FirstOrDefault();
        }
    }
}
