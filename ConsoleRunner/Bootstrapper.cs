using Jack;
using Jack.Environment;
using Jack.Environment.Entity;
using Jack.Simulator;
using Ninject;

namespace ConsoleRunner
{

    public static class Bootstrapper
    {
        public static StandardKernel Bootstrap()
        {
            var kernel = new StandardKernel();

            // line up our entities
            kernel.Bind<IntelligentEntity>().ToConstant(
                new Jack.Entity.Jack(new Jack.Entity.Jack(), new Jack.Entity.Jack())
            );

            //line up our environments
            kernel.Bind<EnvironmentEntity>().ToConstant(
                new CyclicEnvironment()
            );

            // ONLY ONE SINGLE simulator
            kernel.Bind<IntelligentEntitySimulator>().ToConstant(
                new IntelligentEntitySimulator()
            );

            return kernel;
        }
    }
}
