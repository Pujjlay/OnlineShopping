using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DoraLux
{
    internal class Invoice
    {
        private readonly JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        private readonly string BuyerName;
        private readonly List<Item> Items;
        private readonly double Total; 

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
    }
}
