using System.Threading;
using Jack.EnvironmentEntity;
using Jack.IntelligentEntity;
using Jack.Model;
using Jack.Printers;

namespace Jack.Simulator
{
    public class IntelligentEntitySimulator<I, O>
    {
        private readonly ISimulatorPrinter<I, O> _printer;

        public IntelligentEntitySimulator(ISimulatorPrinter<I, O> printer)
        {
            _printer = printer;
        }

        public Intelligence Run(
            IntelligentEntity<I,O> intelligentEntity,
            EnvironmentEntity<I, O> environmentEntity,
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

            return new Intelligence(intelligentEntity.CurrentContentment.Value);
        }
    }
}