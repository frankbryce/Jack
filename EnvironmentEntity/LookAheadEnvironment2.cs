using Jack.Model;

namespace Jack.EnvironmentEntity
{
    public class LookAheadEnvironment2 : EnvironmentEntity<uint, bool>
    {
        protected override IntelligenceInput<uint> NextInput()
        {
            var nextInput = (Input.Object + 13) % 53;

            var success = !(nextInput % 2 == 0 ^ Output.Object);
            return new IntelligenceInput<uint>
            {
                Contentment = success ? 1.0 : 0.0,
                Object = nextInput
            };
        }
    }
}