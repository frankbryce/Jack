using System;
using Jack.Environment;

namespace Jack.Simulator.Printers
{
    public class ConsoleIntelligenceStatusPrinter : ISimulatorPrinter
    {
        public void Print(IntelligentEntity intelligentEntity, EnvironmentEntity environmentEntity)
        {
            Console.Write(environmentEntity.Input.Object + ": ");
            Console.WriteLine(intelligentEntity + ", " + intelligentEntity.Contentment);
        }

        public void PrintIntelligence(IntelligentEntity intelligentEntity)
        {
            Console.WriteLine("Intelligence: " + intelligentEntity.Contentment);
        }
    }
}