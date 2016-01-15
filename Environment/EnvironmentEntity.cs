using Jack.Model;

namespace Jack.Environment
{
    public abstract class EnvironmentEntity
    {
        public void Step(IntelligenceOutput output)
        {
            Output = output;
            Input = NextInput();
        }

        public abstract void Reset();

        public IntelligenceOutput Output { get; protected set; }
        public IntelligenceInput Input { get; protected set; }
        protected abstract IntelligenceInput NextInput();
    }

    public abstract class EnvironmentEntity<I,O> : EnvironmentEntity
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