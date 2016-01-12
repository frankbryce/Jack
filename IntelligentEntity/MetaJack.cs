using System;
using System.Collections.Generic;
using System.Linq;
using Jack.Model;

namespace Jack.IntelligentEntity
{
    public class MetaJack : IntelligentEntity<uint, bool>
    {
        private readonly IntelligentEntity<uint, bool>[] _subEntities;
        private readonly List<Func<IntelligenceInput<uint>, IntelligenceInput<uint>>> _subEntityMaps;
        private readonly Dictionary<byte, Dictionary<bool, List<Contentment>>> _outLookup;
        private readonly List<bool> _memory;
        private const int _memorySize = 10;

        public MetaJack(params IntelligentEntity<uint, bool>[] subEntities)
        {
            _subEntities = subEntities;
            _subEntityMaps = new List<Func<IntelligenceInput<uint>, IntelligenceInput<uint>>>();
            var random = new Random((int) DateTime.Now.Ticks);
            foreach (var i in _subEntities.Select(_ => random.Next(5)))
            {
                _subEntityMaps.Add(input => new IntelligenceInput<uint>
                {
                    Object = (uint) (i + input.Object),
                    Contentment = input.Contentment
                });
            }

            _outLookup = new Dictionary<byte, Dictionary<bool, List<Contentment>>>();
            _memory = new List<bool>(2);
        }

        private static byte Hash(uint @in, params bool[] @bools)
        {
            var returnByte = (byte) (@in % 256);
            foreach (var @bool in @bools)
            {
                returnByte <<= 1;
                if (@bool)
                {
                    returnByte |= 1;
                }
            }
            return returnByte;
        }

        protected override IntelligenceOutput<bool> NextOutput()
        {
            var subOuts = new List<bool>();
            for(var i=0;i< _subEntities.Length;i++)
            {
                var entity = _subEntities[i];
                entity.Step(_subEntityMaps[i](Input));
                subOuts.Add(entity.Output.Object);
            }

            // get hash and add lookup if one doesn't exist yet
            var hash = Hash(Input.Object, subOuts.ToArray());
            if (!_outLookup.ContainsKey(hash))
            {
                _outLookup[hash] = new Dictionary<bool, List<Contentment>>();
            }

            // add element to history
            if (_memory.Count == _memory.Capacity)
            {
                if(!_outLookup[hash].ContainsKey(_memory[0]))
                {
                    _outLookup[hash][_memory[0]] = new List<Contentment>();
                }

                var list = _outLookup[hash][_memory[0]];
                list.Add(Input.Contentment);
                if (list.Count > _memorySize)
                {
                    list.RemoveAt(0);
                }

                // make room for the next Add()
                _memory.RemoveAt(0);
            }

            if (!_outLookup[hash].ContainsKey(true))
            {
                _outLookup[hash][true] = new List<Contentment>();
            }
            if(!_outLookup[hash].ContainsKey(false))
            {
                _outLookup[hash][false] = new List<Contentment>();
            }

            var trueList = _outLookup[hash][true]
                .Select(x => x.Value)
                .Concat(_outLookup[hash][false].Select(x => 1 - x.Value))
                .ToList();
            var trueAverageContentment = trueList.Any() ?
                trueList.Average() :
                0.0;

            var falseList = _outLookup[hash][false]
                .Select(x => x.Value)
                .Concat(_outLookup[hash][true].Select(x => 1 - x.Value))
                .ToList();
            var falseAverageContentment = falseList.Any() ?
                falseList.Average() :
                0.0;

            var output = trueAverageContentment >= falseAverageContentment ? 
                new IntelligenceOutput<bool> { Object = true } : 
                new IntelligenceOutput<bool> { Object = false };

            _memory.Add(output.Object);
            return output;
        }
    }
}