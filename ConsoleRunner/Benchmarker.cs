using Jack;
using Jack.Environment;
using Jack.Simulator;
using Jack.Simulator.Printers;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace ConsoleRunner
{

    public class Benchmarker
    {
        private readonly string _datafileLocation;
        private readonly IEnumerable<IntelligentEntity> _entities;
        private readonly IEnumerable<EnvironmentEntity> _environments;
        private readonly IntelligentEntitySimulator _simulator;

        public Benchmarker(
            IEnumerable<IntelligentEntity> entities,
            IEnumerable<EnvironmentEntity> environments,
            IntelligentEntitySimulator simulator)
        {
            _entities = entities;
            _environments = environments;
            _simulator = simulator;
            _datafileLocation = ConfigurationManager.AppSettings["DataFolderLocation"];
        }

        public void Run(uint timeSteps = 200)
        {
            var i = 0;
            foreach (var entity in _entities)
            {
                var j = 0;
                foreach (var environment in _environments)
                {
                    entity.Reset();
                    environment.Reset();

                    var dataFileLocation =
                        _datafileLocation +
                        "" + i + "/";

                    Directory.CreateDirectory(dataFileLocation);

                    var dataFile = dataFileLocation +
                        "" + j +
                        ".csv";
                    var logger = new CompoundSimulatorPrinter(
                        new ConsoleIntelligenceStatusPrinter(),
                        new SimulatorFileLogger(dataFile)
                    );

                    _simulator.Run(
                        logger,
                        entity,
                        environment,
                        timeSteps);
                    j++;
                }
                i++;
            }
        }
    }
}
