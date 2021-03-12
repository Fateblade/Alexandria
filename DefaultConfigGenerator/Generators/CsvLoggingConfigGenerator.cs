using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.Configuration.DataClasses;
using Fateblade.Components.CrossCutting.CoCo.Core.Configuration.NewtonsoftJson;
using System;
using System.IO;

namespace DefaultConfigGenerator.Generators
{
    internal class CsvLoggingConfigGenerator : IConfigGenerator
    {
        private readonly Action<string> _logMethod;

        public CsvLoggingConfigGenerator(Action<string> logMethod)
        {
            _logMethod = logMethod;
        }

        public void Generate(string basePath, bool deleteExistingFile)
        {
            Generate(basePath, "CsvLoggingConfig.json", deleteExistingFile);
        }

        public void Generate(string basePath, string fileName, bool deleteExistingFile)
        {
            generateAndWriteToFile(Path.Combine(basePath, fileName), deleteExistingFile);
        }

        private void generateAndWriteToFile(string fullPath, bool deleteAnyExistingFiles)
        {
            _logMethod("Generate CsvLoggingConfig");
            try
            {
                if (File.Exists(fullPath) && deleteAnyExistingFiles) { File.Delete(fullPath); }
                var configurationRepository = new DatabaseConfigurationRepository(fullPath);

                var entry = new ConfigEntry()
                {
                    Category = "Logging",
                    Key = "MessageBufferCount",
                    Persist = true,
                    Source = configurationRepository,
                    Value = 10
                };
                configurationRepository.SaveEntry(entry);

                entry = new ConfigEntry()
                {
                    Category = "Logging",
                    Key = "FullPathToLogFile",
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
