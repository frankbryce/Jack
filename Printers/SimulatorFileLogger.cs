using System.IO;
using ConsoleApplication11.EnvironmentEntity;
using ConsoleApplication11.IntelligentEntity;

namespace ConsoleApplication11.Printers
{
    public class SimulatorFileLogger<I, O> : ISimulatorPrinter<I, O>
    {
        private readonly string _filename;

        public SimulatorFileLogger(string filename)
        {
            _filename = filename;
            File.WriteAllText(_filename,
                "Input Contentment" +
                "," +
                "Internal Contentment" +
                "\n");
        }

        public void Print(IntelligentEntity<I, O> intelligentEntity, EnvironmentEntity<I, O> environmentEntity)
        {
            File.WriteAllText(_filename, 
                intelligentEntity.Input.Contentment+
                ","+
                intelligentEntity.CurrentContentment+
                "\n");
        }

        public void PrintIntelligence(IntelligentEntity<I, O> intelligentEntity)
        {
            // do nothing
        }
    }
}