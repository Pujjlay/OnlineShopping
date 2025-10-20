using DoraLux;

internal class Program
{
    static void Main()
    {
        ShopManager shop = ShopManager.LoadData();

        Console.WriteLine("Please, if you are a buyer enter 1, else enter 2.");
        string role = Console.ReadLine();

    }
}



