namespace CodingTracker;

public class Menu()
{
    public static void ShowMenu()
    {
        Console.Clear();
        bool isOn = true;

        do
        {
            Console.WriteLine("Coding Tracker");
            Console.WriteLine("0. Close the application");
            Console.WriteLine("1. Show all Sessions");
            Console.WriteLine("2. Start a new session");

            Console.Write("Your option is: ");
            string? option = Console.ReadLine();

            switch (option)
            {
                case "0":
                    isOn = false;
                    break;
                case "1":
                    // Show all sessions
                    break;
                case "2":
                    // Start a new session
                    break;

            }



        } while (isOn);

    }
}