using DoraLux;
using System.Text;

internal class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        var shop = ShopManager.GetLoadData();

        Console.WriteLine("Please, if you are a buyer enter 1, else enter 2.");
        string role = Console.ReadLine( );

        Console.Write("\nYour name: \n");
        string name = Console.ReadLine();

        User user = role == "2"
            ? new Seller(name, shop)
            : new Buyer(name, shop);


        user.DisplayMenu();

        
    }
}