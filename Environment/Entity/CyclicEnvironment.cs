using System;
using Jack.Model;

namespace Jack.Environment.Entity
{
    public class CyclicEnvironment : EnvironmentEntity<int, bool>
    {
        public override void Reset()
        {
            // no state
        }

        protected override IntelligenceInput NextInput()
        {
            var nextInput = (Input.Object + 13) % 53;

            var success = !(nextInput % 2 == 0 ^ Output.Object);
            return new IntelligenceInput<int>
            {
                Contentment = success ? 1.0 : 0.0,
                Object = nextInput
            };
        }
    }
}