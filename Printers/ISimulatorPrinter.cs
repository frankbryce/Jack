using ConsoleApplication11.EnvironmentEntity;
using ConsoleApplication11.IntelligentEntity;

namespace ConsoleApplication11.Printers
{
    public interface ISimulatorPrinter<I, O>
    {
        void Print(
            IntelligentEntity<I, O> intelligentEntity,
            EnvironmentEntity<I, O> environmentEntity);
        void PrintIntelligence(
            IntelligentEntity<I, O> intelligentEntity);
    }
}