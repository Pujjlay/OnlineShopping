using OnlineShopping;
//using System.Text.Json;


//const string factoryFile = "Factory.json";

//List<Divisions> Factory = ReadFactoryFile();


DisplayDivisions();

void DisplayDivisions()
{
    bool running = true;

    while (running)
    {
        Console.WriteLine("******** You welcome to Dora Lux! *********\n**** We illuminate your life with LEDs ****\n\n " +
                       "Which division do you want to enter?\n\n 1. Factory" +
                          "\n 2. Home\n 3. Outside\n 4. Event" +
                            "\n 5. Exit\n\n Please make your choice...\n ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                FactoryDivision();
                break;

            case 2:
                //HomeDivision();
                break;
            case 3:
                //OutsideDivision();
                break;
            case 4:
                //EventDivision();
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


}

void FactoryDivision()
{
    Console.Clear();
    Console.WriteLine($"Enter the item number: ");
    var ItemNum = Console.ReadLine();
    Console.WriteLine($"Enter the name of the good: ");
    var Name = Console.ReadLine();
    Console.WriteLine($"Enter the price in euro: ");
    var Price = Console.ReadLine();

}