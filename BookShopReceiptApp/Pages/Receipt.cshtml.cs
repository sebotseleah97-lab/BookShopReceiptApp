using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Pages
{
    public class ReceiptModel : PageModel
    {
        public List<Item> Items { get; set; }
        public decimal Total { get; set; }

        public void OnGet()
        {
            Items = new List<Item>
            {
                new Item { Name = "Ball Point Pen", Price = 8 },
                new Item { Name = "Eraser", Price = 5 },
                new Item { Name = "Ruler", Price = 10 },
                new Item { Name = "Book", Price = 120 },
                new Item { Name = "Book Cover", Price = 20 }
            };

            Total = Items.Sum(i => i.Price);
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
