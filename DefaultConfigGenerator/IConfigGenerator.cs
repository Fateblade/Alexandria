namespace Alexandria.UI.DefaultConfigGenerator
{
    internal interface IConfigGenerator
    {
        void Generate(string basePath, bool deleteExistingFile);
        void Generate(string basePath, string fileName, bool deleteExistingFile);
    }
}
