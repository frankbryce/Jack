using System;
using System.IO;
using Jack.Entity;
using Jack.Environment.Entity;
using Jack.Simulator;
using Jack.Simulator.Printers;

namespace ConsoleRunner
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
            var entity = new MetaJack(new Jack.Entity.Jack(), new Jack.Entity.Jack());
            var environment = new LookAheadEnvironment2();
            var simulator = new IntelligentEntitySimulator<uint, bool>(
                new CompoundSimulatorPrinter<uint, bool>(
                    new ConsoleIntelligenceStatusPrinter<uint, bool>(),
                    new SimulatorFileLogger<uint, bool>(dataFile)
                )
            );
            simulator.Run(entity, environment, 2500);
            Console.ReadLine();
        }
    }
}
