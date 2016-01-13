using Jack.Model;

namespace Jack.Environment.Entity
{
    public class LookAheadEnvironment : EnvironmentEntity<uint, bool>
    {
        private readonly uint _jumpAt;

        public LookAheadEnvironment(uint jumpAt = 0)
        {
            _jumpAt = jumpAt;
        }

        protected override IntelligenceInput<uint> NextInput()
        {
            uint nextInput;
            if (Output.Object)
            {
                nextInput = ((Input.Object + 1) * 2) % 13;
            }
            else
            {
                nextInput = ((Input.Object + 2) * 3) % 17;
            }

            var success = !(nextInput == _jumpAt ^ Output.Object);
            return new IntelligenceInput<uint>
            {
                Contentment = success ? 1.0 : 0.0,
                Object = nextInput
            };
        }
    }
}