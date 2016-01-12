using ConsoleApplication11.Model;

namespace ConsoleApplication11.EnvironmentEntity
{
    public class NimbleEnvironment : EnvironmentEntity<uint, bool>
    {
        private const uint wallPeriod = 5;

        protected override IntelligenceInput<uint> NextInput()
        {
            if (Input == null)
            {
                return new IntelligenceInput<uint>
                {
                    Object = wallPeriod,
                    Contentment = 0.5
                };
            }

            if (Output == null)
            {
                return new IntelligenceInput<uint>
                {
                    Object = Input.Object - 1,
                    Contentment = 0.0
                };
            }

            var success = !(Input.Object == wallPeriod ^ Output.Object);
            return new IntelligenceInput<uint>
            {
                Object = Input.Object == 0 ? wallPeriod : Input.Object - 1,
                Contentment = success ? 1.0 : 0.0
            };
        }
    }
}