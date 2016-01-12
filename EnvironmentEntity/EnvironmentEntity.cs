using ConsoleApplication11.Model;

namespace ConsoleApplication11.EnvironmentEntity
{
    public abstract class EnvironmentEntity<I, O>
    {

        private IntelligenceOutput<O> _output;
        private IntelligenceInput<I> _input;

        public void Step(IntelligenceOutput<O> output)
        {
            _output = output;
            _input = NextInput();
        }

        public IntelligenceOutput<O> Output => _output;
        public IntelligenceInput<I> Input => _input;
        protected abstract IntelligenceInput<I> NextInput();
    }
}