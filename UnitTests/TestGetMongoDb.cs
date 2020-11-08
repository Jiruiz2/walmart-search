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
        public static readonly IWalmartConfiguration TestConfiguration = new WalmartConfiguration
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
        
        public ItemDb _testItemDb = new ItemDb(TestConfiguration);
        public ITestOutputHelper _testOutputHelper;

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
        public bool AreEqualLists(List<Item> itemList1, List<Item> itemList2)
        {
            if (itemList1.Count != itemList2.Count)
            {
                return false;
            }

            var equalItems = 0;
            foreach (var item1 in itemList1)
            {
                foreach (var item2 in itemList2)
                {
                    if (AreEqualItems(item1, item2))
                    {
                        equalItems += 1;
                        break;
                    }
                }
            }
            return equalItems == itemList1.Count;
        }
        [Fact]
        public void TestGetItemDb()
        {
            List<Item> baseItemList = new List<Item>(){_item1, _item2, _item3, _item4, _item5};
            List<Item> items = _testItemDb.Get();
            Assert.True(AreEqualLists(items, baseItemList));
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
            List<Item> baseItemList = new List<Item>(){_item3, _item4, _item5};
            List<Item> items = _testItemDb.GetByBrandOrDescription("not palindrome brand");
            Assert.True(AreEqualLists(items, baseItemList));
            Assert.Equal(3, items.Count);
        }
        [Fact]
        public void TestGetByDescription()
        {
            List<Item> baseItemList = new List<Item>(){_item1, _item2, _item5};
            List<Item> items = _testItemDb.GetByBrandOrDescription("not palindrome description");
            Assert.True(AreEqualLists(items, baseItemList));
            Assert.Equal(3, items.Count);
        }
    }
}