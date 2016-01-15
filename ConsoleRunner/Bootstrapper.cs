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
                new Jack.Entity.InputJack()
            );
            kernel.Bind<IntelligentEntity>().ToConstant(
                new Jack.Entity.OutputJack()
            );
            kernel.Bind<IntelligentEntity>().ToConstant(
                new Jack.Entity.InputOutputJack()
            );
            kernel.Bind<IntelligentEntity>().ToConstant(
                new Jack.Entity.InputJack(new Jack.Entity.InputBufferJack(1))
            );
            kernel.Bind<IntelligentEntity>().ToConstant(
                new Jack.Entity.OutputJack(new Jack.Entity.OutputBufferJack(1, new Jack.Entity.OutputBufferJack(2)))
            );
            kernel.Bind<IntelligentEntity>().ToConstant(
                new Jack.Entity.InputOutputJack(
                    new Jack.Entity.InputOutputBufferJack(
                        1,
                        new Jack.Entity.InputBufferJack(2),
                        new Jack.Entity.OutputBufferJack(2),
                        new Jack.Entity.InputOutputBufferJack(2)
                    ),
                    new Jack.Entity.InputOutputBufferJack(
                        1,
                        new Jack.Entity.InputBufferJack(2),
                        new Jack.Entity.OutputBufferJack(2),
                        new Jack.Entity.InputOutputBufferJack(2)
                    )
                )
            );

            //line up our environments
            kernel.Bind<EnvironmentEntity>().To<CyclicEnvironment>();
            kernel.Bind<EnvironmentEntity>().To<StatefulEnvironment>(); 
            kernel.Bind<EnvironmentEntity>().To<StatefulEnvironment2>();

            // ONLY ONE SINGLE simulator
            kernel.Bind<IntelligentEntitySimulator>().ToConstant(
                new IntelligentEntitySimulator()
            );

            return kernel;
        }
    }
}
