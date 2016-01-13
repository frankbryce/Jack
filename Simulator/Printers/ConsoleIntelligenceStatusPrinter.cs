using System;
using Jack.Environment;

namespace Jack.Simulator.Printers
{
    public class ConsoleIntelligenceStatusPrinter<I, O> : ISimulatorPrinter<I, O>
    {
        public void Print(IntelligentEntity<I, O> intelligentEntity, EnvironmentEntity<I, O> environmentEntity)
        {
            Console.Write(environmentEntity.Input.Object + ": ");
            Console.WriteLine(intelligentEntity + ", " + intelligentEntity.CurrentContentment);
        }

        public void PrintIntelligence(IntelligentEntity<I, O> intelligentEntity)
        {
            Console.WriteLine("Intelligence: " + intelligentEntity.CurrentContentment);
        }
    }
}