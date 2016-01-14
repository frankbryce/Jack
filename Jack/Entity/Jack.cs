using System;
using System.Collections.Generic;
using System.Linq;
using Jack.Model;
using Jack.Utility;

namespace Jack.Entity
{
    public class Jack : IntelligentEntity<uint, bool>
    {
        private readonly List<IntelligentEntity<uint, bool>> _subEntities;
        private readonly List<Func<IntelligenceInput<uint>, IntelligenceInput<uint>>> _subEntityMaps;
        private readonly Dictionary<int, Dictionary<bool, CacheList<Contentment>>> _outLookup;
        private readonly CacheList<bool> _outMemory;
        private readonly CacheList<int> _hashMemory;
        private const int _memorySize = 10;

        public Jack(params IntelligentEntity<uint, bool>[] subEntities)
        {
            _subEntities = subEntities.ToList();
            var random = new Random((int) DateTime.Now.Ticks);
            _subEntityMaps = _subEntities.Select(_ => random.Next(100))
                .Select<int, Func<IntelligenceInput<uint>, IntelligenceInput<uint>>>(i =>
                    input => new IntelligenceInput<uint>
                    {
                        Object = (uint)((i + input.Object) % 100),
                        Contentment = input.Contentment
                    }).ToList();

            _outLookup = new Dictionary<int, Dictionary<bool, CacheList<Contentment>>>();
            _outMemory = new CacheList<bool>(2);
            _hashMemory = new CacheList<int>(2);
        }

        protected override IntelligenceOutput NextOutput()
        {
            for(var i=0;i<_subEntities.Count;i++)
            {
                _subEntities[i].Step(_subEntityMaps[i](Input));
            }

            // get hash and add lookup if one doesn't exist yet
            var hash = Hash.With(Input.Object);
            if (_subEntities.Any()) {
                hash.And(_subEntities.Select(x => x.Output.Object).ToArray());
            }

            if (!_outLookup.ContainsKey(hash))
            {
                _outLookup[hash] = new Dictionary<bool, CacheList<Contentment>>();
                _outLookup[hash][true] = new CacheList<Contentment>(2);
                _outLookup[hash][false] = new CacheList<Contentment>(2);
            }

            // add element to history
            if (_outMemory.Count == _outMemory.Capacity)
            {
                var list = _outLookup[_hashMemory[0]][_outMemory[0]];
                list.Add(Input.Contentment);
            }

            var trueAverageContentment = _outLookup[hash][true]
                .Select(x => x.Value)
                .Concat(_outLookup[hash][false].Select(x => 1 - x.Value))
                .AverageOrDefault(0.5);

            var falseAverageContentment = _outLookup[hash][false]
                .Select(x => x.Value)
                .Concat(_outLookup[hash][true].Select(x => 1 - x.Value))
                .AverageOrDefault(0.5);

            var output = trueAverageContentment >= falseAverageContentment ? 
                new IntelligenceOutput<bool> { Object = true } : 
                new IntelligenceOutput<bool> { Object = false };

            _outMemory.Add(output.Object);
            _hashMemory.Add(hash);
            return output;
        }
    }
}