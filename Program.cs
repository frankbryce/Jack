using System;
using ConsoleApplication11.EnvironmentEntity;
using ConsoleApplication11.IntelligentEntity;
using ConsoleApplication11.Printers;
using ConsoleApplication11.Simulator;

namespace ConsoleApplication11
{
    class Program
    {
        static void Main()
        {
            var entity = new Jack();
            var environment = new NimbleEnvironment();
            var simulator = new IntelligentEntitySimulator<uint, bool>(
                new ConsoleIntelligenceStatusPrinter<uint, bool>());
            simulator.Run(entity, environment, 100, 0);
            Console.ReadLine();
        }
    }
}
