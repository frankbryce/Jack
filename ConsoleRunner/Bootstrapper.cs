using Jack;
using Jack.Entity;
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
                new InputJack());
            kernel.Bind<IntelligentEntity>().ToConstant(
                new NullJack(new InputJack()));
            //kernel.Bind<IntelligentEntity>().ToConstant(
            //    new OutputJack());
            //kernel.Bind<IntelligentEntity>().ToConstant(
            //    new InputOutputJack());
            //kernel.Bind<IntelligentEntity>().ToConstant(
            //    new InOutMemoryJack(memorySize: 4));
            //kernel.Bind<IntelligentEntity>().ToConstant(
            //    new InputJack(
            //        new InputJack(1),
            //        new InputJack(2),
            //        new InputJack(3),
            //        new InputJack(4)
            //    ));
            //kernel.Bind<IntelligentEntity>().ToConstant(
            //    new OutputJack(
            //        new OutputJack(1),
            //        new OutputJack(2),
            //        new OutputJack(3),
            //        new OutputJack(4)
            //    ));
            //kernel.Bind<IntelligentEntity>().ToConstant(
            //    new InputOutputJack(
            //        new InputOutputJack(1),
            //        new InputOutputJack(2),
            //        new InputOutputJack(3),
            //        new InputOutputJack(4)
            //    ));
            //kernel.Bind<IntelligentEntity>().ToConstant(
            //    new InOutMemoryJack(
            //        4,
            //        new InOutMemoryJack(memorySize: 4, bufferSize: 1),
            //        new InOutMemoryJack(memorySize: 4, bufferSize: 2),
            //        new InOutMemoryJack(memorySize: 4, bufferSize: 3),
            //        new InOutMemoryJack(memorySize: 4, bufferSize: 4)));

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
