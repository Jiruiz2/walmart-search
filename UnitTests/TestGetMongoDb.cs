using System.Collections.Generic;
using Walmart_search.Data;
using Walmart_search.Models;
using Walmart_search.Services;
using Xunit;
using Xunit.Abstractions;

namespace UnitTests
{
    public class TestGetMongoDb
    {
        private static readonly IWalmartConfiguration TestConfiguration = new WalmartConfiguration
        {
            ConnectionString = "mongodb+srv://test-user:test-password@cluster0.oysy7.mongodb.net/test-db?retryWrites=true&w=majority", 
            DatabaseName = "test-db",
            ItemsCollectionName = "test-collection"
        };
        
        Item _item1 = new Item()
        {
            _id = "aaa",
            id = 121,
            brand = "asdasbsa",
            description = "not palindrome description",
            image = "www.lider.cl/catalogo/images/whiteLineIcon.svg",
            price = 100000
        };
        
        Item _item2 = new Item()
        {
            _id = "bbb",
            id = 2112,
            brand = "dsaasd",
            description = "not palindrome description",
            image = "www.lider.cl/catalogo/images/babyIcon.svg",
            price = 100000
        };
        
        Item _item3 = new Item()
        {
            _id = "ccc",
            id = 31,
            brand = "not palindrome brand",
            description = "asdasbsa",
            image = "www.lider.cl/catalogo/images/homeIcon.svg",
            price = 100000
        };
        
        Item _item4 = new Item()
        {
            _id = "ddd",
            id = 41,
            brand = "not palindrome brand",
            description = "asdasbbs",
            image = "www.lider.cl/catalogo/images/computerIcon.svg",
            price = 100000
        };
        
        Item _item5 = new Item()
        {
            _id = "ddd",
            id = 51,
            brand = "not palindrome brand",
            description = "not palindrome description",
            image = "www.lider.cl/catalogo/images/whiteLineIcon.svg",
            price = 100000
        };
        
        private ItemDb _testItemDb = new ItemDb(TestConfiguration);
        private ITestOutputHelper _testOutputHelper;

        public TestGetMongoDb(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        public bool AreEqualItems(Item item1, Item item2)
        {
            if (item1.brand == item2.brand && item1.description == item2.description && item1.image == item2.image
                && item1.id == item2.id && item1.price == item2.price)
            {
                return true;
            }

            return false;
        }
        [Fact]
        public void TestGetItemDb()
        {
            List<Item> items = _testItemDb.Get();
            Assert.True(AreEqualItems(items[0], _item5));
            Assert.True(AreEqualItems(items[1], _item1));
            Assert.True(AreEqualItems(items[2], _item4));
            Assert.True(AreEqualItems(items[3], _item3));
            Assert.True(AreEqualItems(items[4], _item2));
            Assert.Equal(5, items.Count);
        }
        [Fact]
        public void TestGetById()
        {
            Item item = _testItemDb.GetById(121);
            Assert.True(AreEqualItems(item, _item1));
        }
        [Fact]
        public void TestGetByBrand()
        {
            List<Item> items = _testItemDb.GetByBrandOrDescription("not palindrome brand");
            Assert.True(AreEqualItems(items[0], _item5));
            Assert.True(AreEqualItems(items[1], _item4));
            Assert.True(AreEqualItems(items[2], _item3));
            Assert.Equal(3, items.Count);
        }
        [Fact]
        public void TestGetByDescription()
        {
            List<Item> items = _testItemDb.GetByBrandOrDescription("not palindrome description");
            Assert.True(AreEqualItems(items[0], _item5));
            Assert.True(AreEqualItems(items[1], _item1));
            Assert.True(AreEqualItems(items[2], _item2));
            Assert.Equal(3, items.Count);

        }
    }
}