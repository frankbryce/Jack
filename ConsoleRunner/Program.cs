using System;
using System.IO;
using Jack.Entity;
using Jack.Environment.Entity;
using Jack.Simulator;
using Jack.Simulator.Printers;
using System.Configuration;

namespace ConsoleRunner
{
    class Program
    {
        static void Main()
        {
            var datafileLocation = ConfigurationManager.AppSettings["DataFolderLocation"];
            var dataFile = 
                datafileLocation +
                "out"+
                //"."+DateTime.Now.ToString("yyyyMMddHHmmss")+
                ".csv";
            var entity = new MetaJack(new Jack.Entity.Jack(), new Jack.Entity.Jack());
            var environment = new LookAheadEnvironment2();
            var simulator = new IntelligentEntitySimulator<uint, bool>(
                new CompoundSimulatorPrinter(
                    new ConsoleIntelligenceStatusPrinter(),
                    new SimulatorFileLogger(dataFile)
                )
            );
            simulator.Run(entity, environment, 2500);
            Console.ReadLine();
        }
    }

    public class Benchmark
    {
        public Benchmark()
        {

        }
    }
}
