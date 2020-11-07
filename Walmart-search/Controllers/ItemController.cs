using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Walmart_search.Models;
using Walmart_search.Services;

namespace Walmart_search.Controllers
{
    public class ItemController: Controller
    {
        private readonly ItemDb _itemDb;

        public ItemController(ItemDb itemDb)
        {
            _itemDb = itemDb;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_itemDb.Get().Take(100));
        }

        public IActionResult SearchById(int id)
        {
            var item = _itemDb.GetById(id);
            ListItemDiscount listItemDiscount = new ListItemDiscount();
            listItemDiscount.Discount = false;
            if (item != null && IsPalindromeInt(id))
            {
                item.price = item.price / 2;
                listItemDiscount.Discount = true;
            }
            List<Item> itemList = new List<Item>(){item};
            listItemDiscount.ItemList = itemList;
            return View(listItemDiscount);
        }
        
        public IActionResult SearchByDescriptionOrBrand(string searchParam)
        {
            List<Item> itemList = _itemDb.GetByBrandOrDescription(searchParam);
            ListItemDiscount listItemDiscount = new ListItemDiscount();
            listItemDiscount.Discount = false;
            if (itemList.Count > 0 && IsPalindrome(searchParam))
            {
                listItemDiscount.Discount = true;
                foreach (var position in Enumerable.Range(0, itemList.Count))
                {
                    var item = itemList[position];
                    item.price = item.price / 2;
                    itemList[position] = item;
                }   
            }
            listItemDiscount.ItemList = itemList;
            return View(listItemDiscount);
        }
        
        public Boolean IsPalindrome(string param)
        {
            var length = param.Length;
            if (length%2 == 0)
            {
                foreach (var value in Enumerable.Range(0, length/2))
                {
                    if (param[length / 2 - value - 1] != param[value + length / 2])
                    {
                        return false;
                    }
                }
            }
            else
            {
                foreach (var value in Enumerable.Range(0, length/2))
                {
                    if (param[length / 2 - value - 1] != param[value + length / 2 + 1])
                    {
                        return false;
                    }
                } 
            }

            return true;
        }
        
        public Boolean IsPalindromeInt(int number)
        {
           var stringNumber = number.ToString();
           return IsPalindrome(stringNumber);
        }
    }
}