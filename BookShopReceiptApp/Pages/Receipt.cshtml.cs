using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Pages
{
    public class ReceiptModel : PageModel
    {
        public List<Item> Items { get; set; }

        public decimal SubTotal { get; set; }
        public decimal VATAmount { get; set; }
        public decimal Total { get; set; }

        public const decimal VAT_PERCENTAGE = 15;
        public const decimal DISCOUNT_PERCENTAGE = 10;

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

            foreach (var item in Items)
            {
                item.DiscountAmount = item.Price * DISCOUNT_PERCENTAGE / 100;
                item.PriceAfterDiscount = item.Price - item.DiscountAmount;
            }

            SubTotal = Items.Sum(i => i.PriceAfterDiscount);
            VATAmount = SubTotal * VAT_PERCENTAGE / 100;
            Total = SubTotal + VATAmount;
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal PriceAfterDiscount { get; set; }
    }
}
