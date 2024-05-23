using System;
using System.Collections.Generic;

namespace QueueApp
{
    public class Queue<T>
    {
        private readonly List<T> _items = new List<T>();

        public void Enqueue(T item)
        {
            _items.Add(item);
        }

        public T Dequeue()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Очередь пуста");
            }

            var item = _items[0];
            _items.RemoveAt(0);
            return item;
        }

        public bool IsEmpty => _items.Count == 0;

        public int Count => _items.Count;

        public T CurrentElement => _items[0];

        internal void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
