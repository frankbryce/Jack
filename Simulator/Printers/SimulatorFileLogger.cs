using System.IO;
using Jack.Environment;

namespace Jack.Simulator.Printers
{
    public class SimulatorFileLogger : ISimulatorPrinter
    {
        private readonly string _filename;
        private int _time;

        public SimulatorFileLogger(string filename)
        {
            _filename = filename;
            File.WriteAllText(_filename,
                "Time," +
                "Input Object" +
                "," +
                "Output Object" +
                "," +
                "Input Contentment" +
                "," +
                "Internal Contentment" +
                "\n");
            _time = 0;
        }

        public void Print(IntelligentEntity intelligentEntity, EnvironmentEntity environmentEntity)
        {
            File.AppendAllText(_filename,
                (_time++) +
                "," +
                (intelligentEntity.Input.Object ?? "0") +
                "," +
                (intelligentEntity.Output.Object ?? "False") +
                "," +
                intelligentEntity.Input.Contentment.Value +
                ","+
                intelligentEntity.Contentment.Value +
                "\n");
        }

        public void PrintIntelligence(IntelligentEntity intelligentEntity)
        {
            // do nothing
        }
    }
}