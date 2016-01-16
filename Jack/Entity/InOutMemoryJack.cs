﻿using System.Linq;
using Jack.Utility;

namespace Jack.Entity
{
    public class InOutMemoryJack : BaseJack
    {
        private CacheList<Hash> _inOutHashMemory;
        private int _hashMemorySize;

        public override Hash State
        {
            get
            {
                var hash = Hash.With(Input.Object)
                    .AndWith(Output.Object);
                if (_subEntities.Any())
                {
                    hash = hash.AndWith(_subEntities.Select(x => x.Output.Object).ToArray());
                }
                _inOutHashMemory.Add(hash);
                return Hash.With(_inOutHashMemory.ToArray());
            }
        }

        public override void Reset()
        {
            _inOutHashMemory.Clear();
            base.Reset();
        }

        public InOutMemoryJack(int memorySize=2, int bufferSize=0, params BaseJack[] subEntities) : base(bufferSize, subEntities)
        {
            _hashMemorySize = memorySize;
            _inOutHashMemory = new CacheList<Hash>(_hashMemorySize);
        }

        public InOutMemoryJack(int memorySize = 2, params BaseJack[] subEntities) : this(memorySize, 0, subEntities)
        {}
    }
}