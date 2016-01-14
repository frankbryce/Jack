using Jack.Model;

namespace Jack.Environment.Entity
{
    public class NimbleEnvironment : EnvironmentEntity<uint, bool>
    {
        private readonly uint _wallPeriod;
        private readonly uint _jumpAt;

        public NimbleEnvironment(uint wallPeriod = 5, uint jumpAt = 1)
        {
            _wallPeriod = wallPeriod;
            _jumpAt = jumpAt;
        }

        protected override IntelligenceInput NextInput()
        {
            var success = !(Input.Object == _jumpAt ^ Output.Object);
            return new IntelligenceInput<uint>
            {
                Object = Input.Object == 0 ? _wallPeriod : Input.Object - 1,
                Contentment = success ? 1.0 : 0.0
            };
        }
    }
}