using Jack.Environment.Entity;
using Jack.Simulator;
using Jack.Simulator.Printers;
using System.Configuration;
using Ninject;
using Jack;
using Jack.Environment;
using System.Collections.Generic;
using System.IO;

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
