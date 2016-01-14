using Jack.Environment;

namespace Jack.Simulator.Printers
{
    public interface ISimulatorPrinter
    {
        void Print(
            IntelligentEntity intelligentEntity,
            EnvironmentEntity environmentEntity);
        void PrintIntelligence(
            IntelligentEntity intelligentEntity);
    }
}