using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoraLux
{
    internal class ShoppingCart
    {
        private readonly List<Item> items = [];

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public double Total()
        {
            return items.Sum(i => i.Price);
        }

        public void DisplayCart()
        {
            if (items.Count == 0)
            {
                Console.WriteLine($"\nThe cart 🛒 is emty.");
                return; 
            }

            Console.WriteLine("\nCart 🛒:  ");

            foreach (var i in items)
            {
                string value = $"* {i.Name} {i.Price,8:F2} € ";
                Console.WriteLine(value);

            }
            Console.WriteLine($"Total: {Total():F2} €");
                
        }

        public List<Item> GetItems()
        {
            return items;
        }
    }
}
