using Jack.EnvironmentEntity;
using Jack.IntelligentEntity;

namespace Jack.Printers
{
    public class CompoundSimulatorPrinter<I, O> : ISimulatorPrinter<I, O>
    {
        private readonly ISimulatorPrinter<I, O>[] _simulators;

        public CompoundSimulatorPrinter(params ISimulatorPrinter<I, O>[] simulators)
        {
            _simulators = simulators;
        }

        public void Print(IntelligentEntity<I, O> intelligentEntity, EnvironmentEntity<I, O> environmentEntity)
        {
            foreach (var simulator in _simulators)
            {
                simulator.Print(intelligentEntity, environmentEntity);
            }
        }

        public void PrintIntelligence(IntelligentEntity<I, O> intelligentEntity)
        {
            foreach(var simulator in _simulators)
            {
                simulator.PrintIntelligence(intelligentEntity);
            }
        }
    }
}