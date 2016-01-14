using Jack.Environment;

namespace Jack.Simulator.Printers
{
    public class CompoundSimulatorPrinter : ISimulatorPrinter
    {
        private readonly ISimulatorPrinter[] _simulators;

        public CompoundSimulatorPrinter(params ISimulatorPrinter[] simulators)
        {
            _simulators = simulators;
        }

        public void Print(IntelligentEntity intelligentEntity, EnvironmentEntity environmentEntity)
        {
            foreach (var simulator in _simulators)
            {
                simulator.Print(intelligentEntity, environmentEntity);
            }
        }

        public void PrintIntelligence(IntelligentEntity intelligentEntity)
        {
            foreach(var simulator in _simulators)
            {
                simulator.PrintIntelligence(intelligentEntity);
            }
        }
    }
}