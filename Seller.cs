using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoraLux
{
    internal class Seller : User
    {
        private ShopManager shop;

        public Seller(string name, ShopManager shop) : base(name)
        {
            this.shop = shop;
        }

        public override void DisplayMenu()
        {
            bool running = true;
            
            while (running)
            {
                try
                {
                    Console.WriteLine("💡💡💡💡💡 You welcome to Dora Lux! 💡💡💡💡💡\n" +
                                  "💡💡💡 We illuminate your life with LEDs💡💡💡\n\n" +
                                  "🛠️🛠️🛠️🛠️🛠️🛠️🛠️ Employee Site 🛠️🛠️🛠️🛠️🛠️🛠️🛠️\n\n" +
                                    $"What do you want {Name}?\n\n" +
                                    "1. Show divisions\n" +
                                    "2. New division to add\n" +
                                    "3. Goods to add?\n" +
                                    "4. Goods to remove?\n" +
                                    "5. Exit\n\n " +
                                    "Please make your choice...\n ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            shop.ShowDivisions();
                            break;
                        case 2:
                            Console.WriteLine("New division: ");
                            string divName = Console.ReadLine();
                            shop.Divisions.Add(new Division(divName));
                            shop.SaveData();
                            break;
                        case 3:
                            Console.WriteLine("Divions: ");
                            string div = Console.ReadLine();
                            var d = shop.Divisions.FirstOrDefault(x => x.Name == div);
                            if (d != null)
                            {
                                Console.WriteLine("Name of goods: ");
                                string itemName = Console.ReadLine();
                                Console.Write("Preis: ");
                                double price = double.Parse(Console.ReadLine());
                                d.Items.Add(new Item(itemName, price));
                                shop.SaveData();
                            }
                            else Console.WriteLine("Division not found");
                            break;
                        case 4:
                            Console.WriteLine("Division: ");
                            string delDiv = Console.ReadLine();
                            var dd = shop.Divisions.FirstOrDefault(d => d.Name == delDiv);
                            if (dd != null)
                            {
                                dd.ListItems();
                                Console.WriteLine("\nName of goods to remove: ");
                                string name = Console.ReadLine();
                                var item = dd.Items.FirstOrDefault(i => i.Name == name);
                                if (item != null)
                                {
                                    dd.Items.Remove(item);
                                    shop.SaveData();
                                    Console.WriteLine("Goods removed.");
                                }
                                else Console.WriteLine("Goods not found.");

                            }
                            else Console.WriteLine("Division not found");
                            break;

                        case 5:
                            running = false;
                            Console.WriteLine("\nThanks for your collaboration! See you!");
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"⚠️ Input error: {ex.Message}");
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine($"⚠️ Unexpected null value: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"⚠️ An unexpected error occurred: {ex.Message}");
                }
            }


        }

    }
}