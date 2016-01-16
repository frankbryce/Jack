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
            //kernel.Bind<IntelligentEntity>().ToConstant(
            //    new Jack.Entity.InputJack());
            //kernel.Bind<IntelligentEntity>().ToConstant(
            //    new Jack.Entity.OutputJack());
            //kernel.Bind<IntelligentEntity>().ToConstant(
            //    new Jack.Entity.InputOutputJack());
            kernel.Bind<IntelligentEntity>().ToConstant(
                new Jack.Entity.MemoryJack(memorySize: 8));
            //kernel.Bind<IntelligentEntity>().ToConstant(
            //    new Jack.Entity.InputJack(
            //        new Jack.Entity.InputJack(1),
            //        new Jack.Entity.InputJack(2),
            //        new Jack.Entity.InputJack(3),
            //        new Jack.Entity.InputJack(4)
            //    ));
            //kernel.Bind<IntelligentEntity>().ToConstant(
            //    new Jack.Entity.OutputJack(
            //        new Jack.Entity.OutputJack(1),
            //        new Jack.Entity.OutputJack(2),
            //        new Jack.Entity.OutputJack(3),
            //        new Jack.Entity.OutputJack(4)
            //    ));
            //kernel.Bind<IntelligentEntity>().ToConstant(
            //    new Jack.Entity.InputOutputJack(
            //        new Jack.Entity.InputOutputJack(1),
            //        new Jack.Entity.InputOutputJack(2),
            //        new Jack.Entity.InputOutputJack(3),
            //        new Jack.Entity.InputOutputJack(4)
            //    ));
            kernel.Bind<IntelligentEntity>().ToConstant(
                new Jack.Entity.MemoryJack(
                    8,
                    new Jack.Entity.MemoryJack(memorySize: 8, bufferSize: 1),
                    new Jack.Entity.MemoryJack(memorySize: 8, bufferSize: 2),
                    new Jack.Entity.MemoryJack(memorySize: 8, bufferSize: 3),
                    new Jack.Entity.MemoryJack(memorySize: 8, bufferSize: 4)));

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
