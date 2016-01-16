using Ninject;

namespace ConsoleRunner
{
    class Program
    {
        static void Main()
        {
            var kernel = Bootstrapper.Bootstrap();

            var benchmarker = kernel.Get<Benchmarker>();
            benchmarker.Run();
        }
    }
}
