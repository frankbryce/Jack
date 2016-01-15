using System.Collections.Generic;
using System.Linq;
using Jack.Model;
using Jack.Utility;

namespace Jack.Entity
{
    public abstract class BaseBufferJack : IntelligentEntity<int, bool>
    {
        protected readonly List<IntelligentEntity<int, bool>> _subEntities;
        private Dictionary<Hash, CacheList<Contentment>> _outLookup;
        protected CacheList<Hash> _hashMemory;
        private const int _bufferSize = 2;
        private const int _stateSize = 2;
        private const int _memorySize = 8;
        private readonly CacheList<IntelligenceInput> _inputBuffer;
        private readonly int _layer;

        protected BaseBufferJack(int layer, params IntelligentEntity<int, bool>[] subEntities)
        {
            _layer = layer;
            _subEntities = subEntities.ToList();
            _outLookup = new Dictionary<Hash, CacheList<Contentment>>();
            _inputBuffer = new CacheList<IntelligenceInput>(_bufferSize);
            _hashMemory = new CacheList<Hash>(_memorySize);
        }

        public override void Reset()
        {
            _outLookup.Clear();
            _hashMemory.Clear();
            _inputBuffer.Clear();

            foreach (var subEntity in _subEntities)
            {
                subEntity.Reset();
            }
        }

        protected override IntelligenceOutput NextOutput()
        {
            if (_inputBuffer.IsFull)
            {
                for (var i = 0; i < _subEntities.Count; i++)
                {
                    _subEntities[i].Step(_inputBuffer.First());
                }
            }
            _inputBuffer.Add(Input);

            // get hash and add lookup if one doesn't exist yet
            var hash = State;
            var hashIfTrue = hash.And(true);
            var hashIfFalse = hash.And(false);
            if (!_outLookup.ContainsKey(hashIfTrue))
            {
                _outLookup[hashIfTrue] = new CacheList<Contentment>(_stateSize);
            }
            if (!_outLookup.ContainsKey(hashIfFalse))
            {
                _outLookup[hashIfFalse] = new CacheList<Contentment>(_stateSize);
            }

            // add element to history
            if (_hashMemory.IsFull)
            {
                var list = _outLookup[_hashMemory[_memorySize - (_layer * _bufferSize) - 2]];
                list.Add(Input.Contentment);
            }

            var trueAverageContentment = _outLookup[hashIfTrue]
                .Select(x => x.Value)
                .Concat(_outLookup[hashIfFalse].Select(x => 1 - x.Value))
                .AverageOrDefault(0.5);

            var falseAverageContentment = _outLookup[hashIfFalse]
                .Select(x => x.Value)
                .Concat(_outLookup[hashIfTrue].Select(x => 1 - x.Value))
                .AverageOrDefault(0.5);

            var output = trueAverageContentment >= falseAverageContentment ? 
                new IntelligenceOutput<bool> { Object = true } : 
                new IntelligenceOutput<bool> { Object = false };

            _hashMemory.Add(hash.And(output.Object));
            return output;
        }

        protected abstract Hash State { get; }
    }
}