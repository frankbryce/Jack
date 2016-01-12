using System;
using System.IO;
using Jack.EnvironmentEntity;
using Jack.IntelligentEntity;
using Jack.Printers;
using Jack.Simulator;

namespace Jack
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
                "out"+
                //"."+DateTime.Now.ToString("yyyyMMddHHmmss")+
                ".csv";
            var entity = new Jack2();
            var environment = new LookAheadEnvironment(4);
            var simulator = new IntelligentEntitySimulator<uint, bool>(
                new CompoundSimulatorPrinter<uint, bool>(
                    new ConsoleIntelligenceStatusPrinter<uint, bool>(),
                    new SimulatorFileLogger<uint, bool>(dataFile)
                )
            );
            simulator.Run(entity, environment, 1500);
            Console.ReadLine();
        }
    }
}
