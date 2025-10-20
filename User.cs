using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineShopping
{
    //Basic class
    internal abstract class User // Divisions to User and to class abstract changed because no logic was with Divions beginnen
    {
        public string Name { get; set; }
        protected User(string name)
        {
            Name = name;
        }

        public abstract void DisplayMenu();
    }
}

// Goods and Divisions
internal class Item
{
    public string Name { get; set; }
    public double Price { get; set; }
    public Item(string name, double price)
    {
        Name = name;
        Price = price;
    }
}

internal class Division
{
    public string Name { get; set; }
    public List<Item> Items { get; set; } = new List<Item>();
    public Division(string name) 
    { 
        Name = name; 
    }

}

// Data from Shop Management
internal class ShopManager
{
    public List<Division> Divisions { get; set; } = new List<Division>();
    private const string DataFile = "shop_data_json";

    public void SaveData()
    { 
        string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true});
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
        foreach (var d in Divisions)
            Console.WriteLine($"-{d.Name}");
    }

}