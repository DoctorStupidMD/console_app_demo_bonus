using AppMethodsNamespace;

namespace MainMenuNamespace;

public class MainMenuClass
{
    public static void MainMenu()
    {
        AppMethods converters = new AppMethods();

        Console.Clear();
        Console.WriteLine("Welcome! Please choose an option below:");
        Console.WriteLine("(Press the ESC key for the exit prompt.)");
        Thread.Sleep(1000);
        Console.WriteLine("1) I'd like to import an XML file and convert it into a JSON file.");
        Console.WriteLine("2) I'd like to import a JSON file and convert it into an XML file.");
        Console.WriteLine("3) I took a wrong turn and arrived here by mistake. Unhand me, knave!");

        ConsoleKeyInfo cki;
        cki = Console.ReadKey(true);

        switch (cki.Key)
        {
            case ConsoleKey.D1:
                converters.XmlToJsonConversion();
                break;
            case ConsoleKey.D2:
                converters.JsonToXmlConversion();
                break;
            case ConsoleKey.D3:
                converters.WrongTurn();
                break;
            case ConsoleKey.Escape:
                converters.EscapeApp();
                break;
            default:
                converters.NoOptionsSelected();
                break;
        }
    }
}