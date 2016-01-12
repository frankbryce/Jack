using System;
using Jack.Model;

namespace Jack.IntelligentEntity
{
    public abstract class IntelligentEntity<I, O>
    {
        private readonly double _alpha;
        private IntelligenceOutput<O> _output;
        private IntelligenceInput<I> _input;
        private Contentment _contentment;
        
        protected IntelligentEntity(double alpha = 0.05)
        {
            _contentment = 0.0;

            if (alpha <= 0 || alpha >= 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(alpha),
                    "alpha needs to be between 0 and 1, not inclusive");
            }
            _alpha = alpha;
        }

        public void Step(IntelligenceInput<I> input)
        {
            _input = input;
            _output = NextOutput();
            _contentment =
                _alpha * input.Contentment +
                (1.0 - _alpha) * _contentment;
        }

        public IntelligenceOutput<O> Output => _output;
        public IntelligenceInput<I> Input => _input;
        public Contentment CurrentContentment => _contentment;
        protected abstract IntelligenceOutput<O> NextOutput();
    }
}