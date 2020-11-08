using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Walmart_search.Controllers;
using Walmart_search.Data;
using Walmart_search.Models;
using Walmart_search.Services;
using Xunit;
using Xunit.Abstractions;

namespace UnitTests
{
    public class TestItemControllers
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
        public static ItemDb _testItemDb = new ItemDb(TestConfiguration);
        public ItemController _itemController = new ItemController(_testItemDb);
        public ITestOutputHelper _testOutputHelper;
        public TestItemControllers(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        public bool AreEqualItems(Item item1, Item item2)
        {
            if (item1.brand == item2.brand && item1.description == item2.description && item1.image == item2.image
                && item1.id == item2.id)
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
        public void TestIsPalindrome()
        {
            Assert.True(_itemController.IsPalindrome("abba"));
            Assert.True(_itemController.IsPalindrome("abcba"));
            Assert.False(_itemController.IsPalindrome("abcdba"));
        }
        [Fact]
        public void TestIsPalindromeInt()
        {
            Assert.True(_itemController.IsPalindromeInt(121));
            Assert.True(_itemController.IsPalindromeInt(2112));
            Assert.False(_itemController.IsPalindromeInt(31));
        }
        [Fact]
        public void TestIndex()
        {
            var result = _itemController.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Item>>(viewResult.ViewData.Model);
            Assert.Equal(5, model.Count());
        }
        [Fact]
        public void TestSearchByIdDiscount()
        {
            var result = _itemController.SearchById(2112);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ListItemDiscount>(viewResult.ViewData.Model);
            Assert.True(AreEqualItems(model.ItemList[0], _item2));
            Assert.True(model.Discount);
        }
        [Fact]
        public void TestSearchByIdNotDiscount()
        {
            var result = _itemController.SearchById(31);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ListItemDiscount>(viewResult.ViewData.Model);
            Assert.True(AreEqualItems(model.ItemList[0], _item3));
            Assert.False(model.Discount);
        }
        [Fact]
        public void TestSearchByDescriptionOrBrandDiscount()
        {
            List<Item> baseItemList = new List<Item>(){_item1, _item3};
            var result = _itemController.SearchByDescriptionOrBrand("sbs");
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ListItemDiscount>(viewResult.ViewData.Model);
            Assert.True(AreEqualLists(model.ItemList, baseItemList));
            Assert.True(model.Discount);
            Assert.Equal(2, model.ItemList.Count());
        }
        [Fact]
        public void TestSearchByDescriptionOrBrandNotDiscount()
        {
            List<Item> baseItemList = new List<Item>(){_item3, _item4, _item5};
            var result = _itemController.SearchByDescriptionOrBrand("brand");
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ListItemDiscount>(viewResult.ViewData.Model);
            Assert.True(AreEqualLists(model.ItemList, baseItemList));
            Assert.False(model.Discount);
            Assert.Equal(3, model.ItemList.Count());
        }
    }
}