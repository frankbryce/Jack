using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.Utility
{
    public class CacheList<T> : List<T>
    {
        public CacheList(int capacity) {
            Capacity = capacity;
        }

        public new void Add(T item)
        {
            base.Add(item);
            if (Count > Capacity)
            {
                RemoveAt(0);
            }
        }

        public new int Capacity { get; }

        public bool IsFull => Count == Capacity;
    }
}
