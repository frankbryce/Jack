using ConsoleApplication11.EnvironmentEntity;
using ConsoleApplication11.IntelligentEntity;

namespace ConsoleApplication11.Printers
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