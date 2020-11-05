namespace Walmart_search.Data
{
    public class WalmartConfiguration : IWalmartConfiguration
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
        public string ItemsCollectionName { get; set; }

    }

    public interface IWalmartConfiguration
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
        string ItemsCollectionName { get; set; }
    }
}