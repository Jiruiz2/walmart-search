using System.Collections.Generic;
using MongoDB.Driver;
using Walmart_search.Data;
using Walmart_search.Models;

namespace Walmart_search.Services
{
    public class ItemDb
    {
        private readonly IMongoCollection<Item> _itemsCollection;

        public ItemDb(IWalmartConfiguration settings)
        {
            var mdbClient = new MongoClient(settings.ConnectionString);
            var database = mdbClient.GetDatabase(settings.DatabaseName);
            _itemsCollection = database.GetCollection<Item>(settings.ItemsCollectionName);
        }

        public List<Item> Get()
        {
            return _itemsCollection.Find(item => true).ToList();
        }

        public Item GetById(int id)
        {
            return _itemsCollection.Find<Item>(item => item.id == id).FirstOrDefault();
        }
        
        public List<Item> GetByBrandOrDescription(string searchParam)
        {
            return _itemsCollection.Find(item => item.brand.Contains(searchParam) ||  item.description.Contains(searchParam)).ToList();
        }
    }
}