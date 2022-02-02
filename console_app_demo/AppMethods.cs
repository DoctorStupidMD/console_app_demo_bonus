using MainMenuNamespace;
using ConversionMethodsNamespace;

namespace AppMethodsNamespace;

public class AppMethodsClass
{
    private enum SleepyTime
    {
        Small = 1000,
        Medium = 2000,
        Large = 3000
    }

    public void WrongTurn()
    {
        Console.WriteLine("Forsooth, then be on your merry way!");
        Environment.Exit(0);
    }

    public void EscapeApp()
    {
        Console.WriteLine("Chau for now!");
        Environment.Exit(0);
    }

    public static void NoFilePathHandler()
    {
        if (ConversionMethodsClass.filePath == null || ConversionMethodsClass.filePath == "")
        {
            Console.WriteLine("Oops, perhaps you got trigger happy with that Enter button?");
            Thread.Sleep((int)SleepyTime.Small);
            Console.WriteLine("Returning to the Main Menu...");
            Thread.Sleep(2000);
            MainMenuClass.MainMenu();
        }
    }

    public void NoOptionsSelected()
    {
        Console.WriteLine("That wasn't one of the menu options. Please select 1, 2 or 3 from the above menu.");
        Thread.Sleep((int)SleepyTime.Medium);
        Console.Clear();
        MainMenuClass.MainMenu();
    }
    public static void NoFileFoundReturnToMain()
    {
        Thread.Sleep((int)SleepyTime.Medium);
        Console.WriteLine("Pobody's nerfect, let's try this again...");
        Thread.Sleep((int)SleepyTime.Medium);
        MainMenuClass.MainMenu();
    }

    public static string SuccessMessage(string formatType)
    {
        Thread.Sleep((int)SleepyTime.Large);
        Console.Clear();
        Console.WriteLine($"Your file has been successfully converted and preserved in {formatType} format.");
        Console.WriteLine("Please close this console and navigate to the files directory in the repo to retrieve your new file.");
        Console.WriteLine("Have a lovely day!");
        return string.Empty;
    }
}