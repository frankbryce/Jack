using System;
using Jack.Model;

namespace Jack
{
    public abstract class IntelligentEntity
    {
        private double Alpha { get; }

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
            Output = default(IntelligenceOutput);
            Input = default(IntelligenceInput);
        }

        public void Step(IntelligenceInput input)
        {
            Input = input;
            Contentment =
                Alpha * input.Contentment +
                (1.0 - Alpha) * Contentment;

            Iterate();
        }

        public virtual IntelligenceOutput Output { get; protected set; }
        public virtual IntelligenceInput Input { get; protected set; }
        public virtual Contentment Contentment { get; private set; }

        public virtual void Reset()
        {
            Output = default(IntelligenceOutput);
            Input = default(IntelligenceInput);
        }
        protected abstract void Iterate();
    }

    public abstract class IntelligentEntity<I, O> : IntelligentEntity
    {
        public virtual new IntelligenceOutput<O> Output
        {
            get { return base.Output; }
            protected set { base.Output = value; }
        }

        public virtual new IntelligenceInput<I> Input
        {
            get { return base.Input; }
            protected set { base.Input = value; }
        }
    }
}