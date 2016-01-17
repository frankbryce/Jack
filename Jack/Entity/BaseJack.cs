using System.Collections.Generic;
using System.Linq;
using Jack.Model;
using Jack.Utility;

namespace Jack.Entity
{
    public abstract class BaseJack : IntelligentEntity<int, bool>
    {
        protected readonly List<BaseJack> _subEntities;
        private Dictionary<Hash, CacheList<Contentment>> _outLookup;
        protected CacheList<Hash> _hashMemory;
        private const int _stateSize = 10;
        private const int _roundTripDelay = 2;
        private readonly CacheList<IntelligenceInput<int>> _inputBuffer;

        protected BaseJack(int bufferSize, params BaseJack[] subEntities)
        {
            _subEntities = subEntities.ToList();
            _outLookup = new Dictionary<Hash, CacheList<Contentment>>();
            _inputBuffer = new CacheList<IntelligenceInput<int>>(bufferSize);
            _hashMemory = new CacheList<Hash>(_roundTripDelay + bufferSize);
            State = Hash.Identity;
        }

        public override void Reset()
        {
            base.Reset();

            foreach (var subEntity in _subEntities)
            {
                subEntity.Reset();
            }

            _outLookup.Clear();
            _inputBuffer.Clear();
            _hashMemory.Clear();
            State = Hash.Identity;
        }

        protected override void Iterate()
        {
            try
            {
                if (_inputBuffer.IsFull)
                {
                    for (var i = 0; i < _subEntities.Count; i++)
                    {
                        // if buffer is empty, and "IsFull" then there is no buffer
                        // and so we throw in non-buffered input
                        _subEntities[i].Step(Input);
                    }

                    // get hash and add lookup if one doesn't exist yet
                    var hash = State = GetState();
                    var hashIfTrue = hash.AndWith(true);
                    var hashIfFalse = hash.AndWith(false);
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
                        var list = _outLookup[_hashMemory.First()]; //FIFO
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

                    Output = trueAverageContentment >= falseAverageContentment ?
                        new IntelligenceOutput<bool> { Object = true } :
                        new IntelligenceOutput<bool> { Object = false };

                    _hashMemory.Add(hash.AndWith(Output.Object));
                }
            }
            finally
            {
                _inputBuffer.Add(Input); // If size 0, essentially a no-op
            }
        }

        protected virtual Hash GetState()
        {
            var hash = Hash.Identity;
            if (_subEntities.Any())
            {
                hash = hash.AndWith(_subEntities.Select(x => x.Output.Object).ToArray());
            }
            return hash;
        }

        public Hash State { get; private set; }

        public override IntelligenceInput<int> Input => _inputBuffer.Any() ? _inputBuffer.First() : base.Input;
    }
}