using System.IO;
using Jack.Environment;

namespace Jack.Simulator.Printers
{
    public class SimulatorFileLogger<I, O> : ISimulatorPrinter<I, O>
    {
        private readonly string _filename;
        private int _time;

        public SimulatorFileLogger(string filename)
        {
            _filename = filename;
            File.WriteAllText(_filename,
                "Time,"+
                "Input Contentment" +
                "," +
                "Internal Contentment" +
                "\n");
            _time = 0;
        }

        public void Print(IntelligentEntity<I, O> intelligentEntity, EnvironmentEntity<I, O> environmentEntity)
        {
            File.AppendAllText(_filename,
                (_time++) +
                ","+
                intelligentEntity.Input.Contentment +
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