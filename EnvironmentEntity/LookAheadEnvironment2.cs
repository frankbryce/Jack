using Jack.Model;

namespace Jack.EnvironmentEntity
{
    public class LookAheadEnvironment2 : EnvironmentEntity<uint, bool>
    {
        protected override IntelligenceInput<uint> NextInput()
        {
            uint nextInput;
            if (Output.Object)
            {
                nextInput = ((Input.Object + 1) * 2) % 57;
            }
            else
            {
                nextInput = ((Input.Object + 2) * 3) % 61;
            }

            var success = !(nextInput % 3 == 0 ^ Output.Object);
            return new IntelligenceInput<uint>
            {
                Contentment = success ? 1.0 : 0.0,
                Object = nextInput
            };
        }
    }
}