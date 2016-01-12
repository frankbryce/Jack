using System;
using System.IO;
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
            var dataFile = Directory
                .GetParent(Directory.GetCurrentDirectory())
                .Parent
                .FullName +
                "/Data/"+
                "out."+
                DateTime.Now.ToString("yyyyMMddHHmmss")+
                ".csv";
            var entity = new Jack();
            var environment = new NimbleEnvironment();
            var simulator = new IntelligentEntitySimulator<uint, bool>(
                new CompoundSimulatorPrinter<uint, bool>(
                    new ConsoleIntelligenceStatusPrinter<uint, bool>(),
                    new SimulatorFileLogger<uint, bool>(dataFile)
                )
            );
            simulator.Run(entity, environment, 100, 0);
            Console.ReadLine();
        }
    }
}
