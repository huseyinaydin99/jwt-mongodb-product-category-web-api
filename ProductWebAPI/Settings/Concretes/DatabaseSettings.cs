using CasgemMicroservice.Catalog.Settings.Abstracts;

namespace CasgemMicroservice.Services.Catalog.Settings.Abstracts
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
    }
}