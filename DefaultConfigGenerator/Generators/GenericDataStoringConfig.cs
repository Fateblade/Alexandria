using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Configuration.DataClasses;
using Fateblade.Components.CrossCutting.CoCo.Core.Configuration.NewtonsoftJson;
using System;
using System.IO;

namespace DefaultConfigGenerator.Generators
{
    internal class GenericDataStoringConfigGenerator : IConfigGenerator
    {
        private readonly Action<string> _logMethod;

        public GenericDataStoringConfigGenerator(Action<string> logMethod)
        {
            _logMethod = logMethod;
        }

        public void Generate(string basePath, bool deleteExistingFile)
        {
            Generate(basePath, "GenericDataStoringConfig.json", deleteExistingFile);
        }

        public void Generate(string basePath, string fileName, bool deleteExistingFile)
        {
            generateAndWriteToFile(Path.Combine(basePath, fileName), deleteExistingFile);
        }

        private void generateAndWriteToFile(string fullPath, bool deleteAnyExistingFiles)
        {
            _logMethod("Generate GenericDataStoringConfig");
            try
            {
                if (File.Exists(fullPath) && deleteAnyExistingFiles) { File.Delete(fullPath); }
                var configurationRepository = new DatabaseConfigurationRepository(fullPath);

                var entry = new ConfigEntry()
                {
                    Category = "DataStoring.Generic.Json",
                    Key = "RootPath",
                    Persist = true,
                    Source = configurationRepository,
                    Value = ""
                };
                configurationRepository.SaveEntry(entry);
            }
            catch (Exception ex)
            {
                do
                {
                    _logMethod($"Exception encountered: {ex.Message}");
                    _logMethod($"Stacktrace: {ex.StackTrace}");
                    ex = ex.InnerException;
                } while (ex != null);
            }
        }
    }
}
