using UtilsNamespace;
using AppMethodsNamespace;
using ConversionMethodsNamespace;

namespace MainMenuNamespace;

public class MainMenuClass
{
    public static void MainMenu()
    {
        AppMethodsClass appMethodsClass = new AppMethodsClass();

        Console.Clear();
        Console.WriteLine("Welcome! Please choose an option below:");
        Console.WriteLine("(Press the ESC key for the exit prompt.)");
        Thread.Sleep((int)UtilsClass.SleepyTime.Small);
        Console.WriteLine("1) I'd like to import an XML file and convert it into a JSON file.");
        Console.WriteLine("2) I'd like to import a JSON file and convert it into an XML file.");
        Console.WriteLine("3) I took a wrong turn and arrived here by mistake. Unhand me, knave!");

        ConsoleKeyInfo cki;
        cki = Console.ReadKey(true);

        switch (cki.Key)
        {
            case ConsoleKey.D1:
                ConversionMethodsClass.XmlToJsonConversion();
                break;
            case ConsoleKey.D2:
                ConversionMethodsClass.JsonToXmlConversion();
                break;
            case ConsoleKey.D3:
                appMethodsClass.WrongTurn();
                break;
            case ConsoleKey.Escape:
                appMethodsClass.EscapeApp();
                break;
            default:
                appMethodsClass.NoOptionsSelected();
                break;
        }
    }
}