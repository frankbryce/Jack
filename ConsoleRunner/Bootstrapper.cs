using Jack;
using Jack.Entity;
using Jack.Environment;
using Jack.Environment.Entity;
using Jack.Simulator;
using Ninject;

namespace ConsoleRunner
{
    public enum NinjectKey
    {
        timeSteps
    }

    public static class Bootstrapper
    {
        public static StandardKernel Bootstrap()
        {
            var kernel = new StandardKernel();

            // number of timesteps per simulation
            kernel.Bind<int>().ToConstant(500)
                .WhenInjectedInto<IntelligentEntitySimulator>();

            // line up our entities
            kernel.Bind<IntelligentEntity>().ToConstant(
                new InputJack());
            kernel.Bind<IntelligentEntity>().ToConstant(
                new NullJack(new InputJack()));
            kernel.Bind<IntelligentEntity>().ToConstant(
                new OutputJack());
            kernel.Bind<IntelligentEntity>().ToConstant(
                new NullJack(new OutputJack()));
            kernel.Bind<IntelligentEntity>().ToConstant(
                new InputOutputJack());
            kernel.Bind<IntelligentEntity>().ToConstant(
                new NullJack(new InputOutputJack()));
            kernel.Bind<IntelligentEntity>().ToConstant(
                new InOutMemoryJack(memorySize: 4));
            kernel.Bind<IntelligentEntity>().ToConstant(
                new NullJack(new InOutMemoryJack(memorySize: 4)));

            //line up our environments
            kernel.Bind<EnvironmentEntity>().To<CyclicEnvironment>();
            kernel.Bind<EnvironmentEntity>().To<StatefulEnvironment>();
            kernel.Bind<EnvironmentEntity>().To<StatefulEnvironment2>();
            
            return kernel;
        }
    }
}
