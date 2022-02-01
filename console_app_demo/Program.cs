using MainMenuNamespace;

namespace ConsoleAppDemo;

public class Program
{
    public static void Main(string[] args)
    {
        do
        {
            while (! Console.KeyAvailable)
            {
                MainMenuClass.MainMenu();
            }
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}