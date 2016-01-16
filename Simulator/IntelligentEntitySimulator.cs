using System.Threading;
using Jack.Environment;
using Jack.Model;
using Jack.Simulator.Printers;

namespace Jack.Simulator
{
    public class IntelligentEntitySimulator
    {
        private readonly int _timeSteps;

        public IntelligentEntitySimulator(int timeSteps)
        {
            _timeSteps = timeSteps;
        }

        public Intelligence Run(
            ISimulatorPrinter printer,
            IntelligentEntity intelligentEntity,
            EnvironmentEntity environmentEntity)
        {
            for (var t = 0; t < _timeSteps; t++)
            {
                var output = intelligentEntity.Output;
                var input = environmentEntity.Input;

                intelligentEntity.Step(input);
                environmentEntity.Step(output);
                printer.Print(intelligentEntity, environmentEntity);
            }

            printer.PrintIntelligence(intelligentEntity);

            return intelligentEntity.Contentment.Value;
        }

    }
}