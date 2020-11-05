using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Walmart_search.Data;
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
            TempData["discount"] = "false";
            if (item != null && IsPalindromeInt(id))
            {
                item.price = item.price / 2;
                TempData["discount"] = "true";
            }
            List<Item> itemList = new List<Item>(){item};
            return View(itemList);
        }
        
        public IActionResult SearchByDescriptionOrBrand(string searchParam)
        {
            List<Item> itemList = _itemDb.GetByBrandOrDescription(searchParam);
            TempData["discount"] = "false";
            if (itemList.Count > 0 && IsPalindrome(searchParam))
            {
                TempData["discount"] = "true";
                foreach (var position in Enumerable.Range(0, itemList.Count))
                {
                    var item = itemList[position];
                    item.price = item.price / 2;
                    itemList[position] = item;
                }   
            }
            return View(itemList);
        }
        
        public Boolean IsPalindrome(string param)
        {
            Console.WriteLine($"param: {param}");
            var length = param.Length;
            Console.WriteLine($"length: {length}");
            Console.WriteLine($"length%2: {length%2}");
            if (length%2 == 0)
            {
                foreach (var value in Enumerable.Range(0, length/2))
                {
                    Console.WriteLine($"first: {param[length / 2 - value - 1]}");
                    Console.WriteLine($"second: {param[value + length / 2]}");
                    if (param[length / 2 - value - 1] != param[value + length / 2])
                    {
                        Console.WriteLine("Son distintas jodeer");
                        return false;
                    }
                    Console.WriteLine("-----------------------------------------------");
                }
            }
            else
            {
                foreach (var value in Enumerable.Range(0, length/2))
                {
                    Console.WriteLine($"first: {param[length / 2 - value - 1]}");
                    Console.WriteLine($"second: {param[value + length / 2]}");
                    if (param[length / 2 - value - 1] != param[value + length / 2 + 1])
                    {
                        Console.WriteLine("Son distintas jodeer");
                        return false;
                    }
                    Console.WriteLine("-----------------------------------------------");
                } 
            }

            return true;
        }
        
        public Boolean IsPalindromeInt(int number)
        {
           var stringNumber = number.ToString();
           Console.WriteLine($"stringNumber: {stringNumber}");
           return IsPalindrome(stringNumber);
        }
    }
}