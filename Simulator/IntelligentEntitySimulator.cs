using System.Threading;
using ConsoleApplication11.EnvironmentEntity;
using ConsoleApplication11.IntelligentEntity;
using ConsoleApplication11.Model;
using ConsoleApplication11.Printers;

namespace ConsoleApplication11.Simulator
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
            int timeBetweenSteps=200)
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