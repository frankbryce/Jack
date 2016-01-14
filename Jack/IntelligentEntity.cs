using System;
using Jack.Model;

namespace Jack
{
    public abstract class IntelligentEntity
    {
        protected IntelligentEntity(double alpha = 0.05)
        {
            Contentment = 0.0;

            if (alpha <= 0 || alpha >= 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(alpha),
                    "alpha needs to be between 0 and 1, not inclusive");
            }
            Alpha = alpha;
        }

        public void Step(IntelligenceInput input)
        {
            Input = input;
            Output = NextOutput();
            Contentment =
                Alpha * input.Contentment +
                (1.0 - Alpha) * Contentment;
        }

        private double Alpha { get; }
        public IntelligenceOutput Output { get; protected set; }
        public IntelligenceInput Input { get; protected set; }
        public Contentment Contentment { get; private set; }
        protected abstract IntelligenceOutput NextOutput();
    }

    public abstract class IntelligentEntity<I, O> : IntelligentEntity
    {
        public new IntelligenceOutput<O> Output
        {
            get
            {
                return base.Output;
            }
            protected set
            {
                base.Output = value;
            }
        }

        public new IntelligenceInput<I> Input
        {
            get
            {
                return base.Input;
            }
            protected set
            {
                base.Input = value;
            }
        }
    }
}