using System.Threading;
using Jack.Environment;
using Jack.Model;
using Jack.Simulator.Printers;

namespace Jack.Simulator
{
    public class IntelligentEntitySimulator
    {
        private ISimulatorPrinter _printer;
        public IntelligentEntitySimulator(ISimulatorPrinter printer)
        {
            _printer = printer;
        }

        public Intelligence Run(
            IntelligentEntity intelligentEntity,
            EnvironmentEntity environmentEntity,
            uint timeSteps,
            int timeBetweenSteps = 0)
        {
            for (var t = 0; t < timeSteps; t++)
            {
                var output = intelligentEntity.Output;
                var input = environmentEntity.Input;

                intelligentEntity.Step(input);
                environmentEntity.Step(output);
                _printer.Print(intelligentEntity, environmentEntity);
                if (timeBetweenSteps > 0) Thread.Sleep(timeBetweenSteps);
            }

            _printer.PrintIntelligence(intelligentEntity);

            return intelligentEntity.Contentment.Value;
        }

    }
}