using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DoraLux
{
    internal class ShopManager
    {
        public List<Division> Divisions { get; set; } = [];
        private const string DataFile = "shop_data_json";

        public void SaveData()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(DataFile, json);

        }

        public static ShopManager LoadData()
        {
            if (!File.Exists(DataFile))
                return new ShopManager();

            string json = File.ReadAllText(DataFile);
            return JsonSerializer.Deserialize<ShopManager>(json);

        }

        public void ShowDivisions()
        {
            if (Divisions.Count == 0)
            {
                Console.WriteLine("No divisions now.");
                return;
            }

            Console.WriteLine("\nDivisions: ");

            foreach (var d in Divisions) { 
                Console.WriteLine($"-{d.Name}"); 
            }
               
        }

    }
}
