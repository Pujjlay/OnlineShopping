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
                Console.WriteLine("\nThe cart is emty.");
                return; 
            }

            Console.WriteLine("\nCart: ");

            foreach (var i in items)
            {
                Console.WriteLine($"* {i.Name} ({i.Price} €)");

            }
            Console.WriteLine($"Total: {Total()} €");
                
        }
        public List<Item> GetItems()
        {
            return items;
        }
    }
}
