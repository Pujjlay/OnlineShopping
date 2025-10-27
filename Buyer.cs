using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoraLux
{
    internal class Buyer : User
    {
        private ShopManager shop;
        private ShoppingCart cart = new ShoppingCart();

        public Buyer(string name, ShopManager shop) : base(name)
        {
            this.shop = shop;
        }


        public override void DisplayMenu()
        {


            bool running = true;
            bool isPaid = false;

            while (running)
            {
                try
                {
                    Console.WriteLine("💡💡💡💡💡 You welcome to Dora Lux! 💡💡💡💡💡\n" +
                                  "💡💡💡 We illuminate your life with LEDs💡💡💡\n\n" +
                                  "👑👑👑👑👑👑👑 Customer Site 👑👑👑👑👑👑👑\n\n" +
                                    $"What do you want {Name}?\n\n" +
                                    "1. Show divisions\n" +
                                    "2. Goods to buy\n" +
                                    "3. Show your cart\n" +
                                    "4. Pay your buy\n" +
                                    "5. Exit\n\n" +
                                    "Please make your choice...\n ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            shop.ShowDivisions();
                            break;
                        case 2:
                            Console.WriteLine("Enter division name: ");
                            string div = Console.ReadLine();

                            var d = shop.Divisions.FirstOrDefault(d => d.Name == div);
                            if (d != null)
                            {
                                if (d.Items.Count == 0)
                                {
                                    Console.WriteLine("⚠️ No items available in this division.\n");
                                    break;
                                }

                                Console.WriteLine("\nAvailable items:");

                                d.ListItems();

                                Console.WriteLine("Enter the article name to buy: ");
                                string name = Console.ReadLine();

                                var item = d.Items.FirstOrDefault(i => i.Name == name);
                                if (item != null)
                                {
                                    cart.AddItem(item);
                                    isPaid = false;
                                    Console.WriteLine($"✅{item.Name} added in to cart 🛒.");
                                }
                                else
                                {
                                    Console.WriteLine("⚠️ Item not found in this division.");
                                }
                            }
                            else Console.WriteLine("⚠️ Division not found.");
                            break;

                        case 3:
                            cart.DisplayCart();
                            break;

                        case 4:
                            if (isPaid)
                            {
                                Console.WriteLine("⚠️ You have already paid for your cart. No double payment allowed.\n");
                                break;
                            }

                            cart.DisplayCart();
                            if (cart.GetItems().Count != 0)
                            {
                                Console.WriteLine("Processing payment...💳");

                                var invoice = new Invoice(this.Name, cart);
                                invoice.SaveInvoice();
                                invoice.SaveEInvoice();

                                Console.WriteLine("✅ Payment successfull! Invoice saved.");
                                isPaid = true; //prevent double payment
                                cart.GetItems().Clear();
                            }
                            else
                            {
                                Console.WriteLine("Your cart is empty. Nothing to pay.");
                            }
                            break;
                        case 5:
                            running = false;
                            Console.WriteLine("\n🙏 Thanks for your visit!");
                            break;
                        default:
                            Console
                                .WriteLine("⚠️ Invalid choice. Please try again. \n");
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
