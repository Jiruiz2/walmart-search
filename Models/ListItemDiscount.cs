using System.Collections.Generic;

namespace Walmart_search.Models
{
    public class ListItemDiscount
    {
        public List<Item> ItemList { get; set; }
        public bool Discount { get; set; }
    }
}