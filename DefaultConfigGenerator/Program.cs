using System;
using System.Collections.Generic;
using System.IO;
using Alexandria.UI.DefaultConfigGenerator.Generators;

namespace Alexandria.UI.DefaultConfigGenerator
{
    class Program
    {
        private readonly List<IConfigGenerator> _availableGenerators;

        public Program()
        {
            _availableGenerators = new List<IConfigGenerator>
            {
                new GenericDataStoringConfigGenerator(Console.WriteLine),
                new CsvLoggingConfigGenerator(Console.WriteLine)
            };

            string mergedConfigPath = Path.Combine(Directory.GetCurrentDirectory(), "MergedConfig.json");
            if (File.Exists(mergedConfigPath)) { File.Delete(mergedConfigPath); }
        }

        public void Generate()
        {

            Console.WriteLine("Generating default configuration files to current directory!");
            _availableGenerators.ForEach(t => t.Generate(Directory.GetCurrentDirectory(), true));

            Console.WriteLine("Generating merged configuration file to current directory!");
            _availableGenerators.ForEach(t => t.Generate(Directory.GetCurrentDirectory(), "MergedConfig.json", false));

            Console.WriteLine("Generation complete! Press any key to exit");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            var configGenerator = new Program();
            configGenerator.Generate();
        }

    }
}
