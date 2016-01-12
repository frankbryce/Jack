using Jack.EnvironmentEntity;
using Jack.IntelligentEntity;

namespace Jack.Printers
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