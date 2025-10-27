using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DoraLux
{
    internal class Invoice
    {
        private readonly JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        public string BuyerName { get; set; }
        public List<Item> Items { get; set; }
        public double Total { get; set; }

        public Invoice(string name, ShoppingCart cart)
        {
            BuyerName = name;
            Items = cart.GetItems();
            Total = cart.Total();
        }

        public void SaveInvoice()
        {
            string file = $"invoice_{BuyerName}_{DateTime.Now:yyyyMMddHHmmss}.json";
            string json = JsonSerializer.Serialize(this, options);
            File.WriteAllText(file, json);
        }

        public void SaveEInvoice()
        {
            string file = $"Invoice_{BuyerName}_{DateTime.Now:yyyyMMddHHmmss}.txt";
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("⛯⛯⛯⛯⛯ Invoice ⛯⛯⛯⛯⛯");
            sb.AppendLine($"Customer: {BuyerName}");
            sb.AppendLine($"Date: {DateTime.Now:f}");
            sb.AppendLine("-----------------------");

            foreach (Item item in Items)
            {
                StringBuilder stringBuilder = sb.AppendLine($"{item.Name.PadRight(20)}{item.Price,8:F2} €");

            }

            sb.AppendLine("---------------");
            sb.AppendLine($"Total: {Total:F2} €");
            sb.AppendLine("Thank you for your buy!");
            sb.AppendLine("⛯⛯⛯⛯⛯⛯⛯⛯⛯⛯⛯⛯⛯⛯⛯");

            File.WriteAllText (file, sb.ToString());

            Console.WriteLine($"The invoice was saved: {file}");
        }
    }
}