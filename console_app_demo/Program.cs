using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleAppDemo;

public class Program
{
    public static void Main(string[] args)
    {
        do
        {
            while (! Console.KeyAvailable)
            {
                MainMenu();
            }
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }

    private static void MainMenu()
    {
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
                XmlToJsonConversion();
                break;
            case ConsoleKey.D2:
                JsonToXmlConversion();
                break;
            case ConsoleKey.D3:
                WrongTurn();
                break;
            case ConsoleKey.Escape:
                Console.WriteLine("Chau for now!");
                Environment.Exit(0);
                break;
            default:
                NoOptionsSelected();
                break;
        }
    }
   
    public static string? filePath;

    private static void XmlToJsonConversion()
    {
        Console.WriteLine("Please input the absolute path to your XML file and press ENTER so I can automagically convert it:");
        filePath = Console.ReadLine();

        NoFilePathHandler();

        XmlDocument importXmlDoc = new();

        try
        {
            importXmlDoc.Load(filePath);
            Console.Clear();
            Console.WriteLine("I found your XML file! Beep boop...");

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = Path.Combine(baseDir, $@"..\..\..\..\console_app_demo\files\XmlToJsonResult.json");
            string jsonFormattedText = JsonConvert.SerializeXmlNode(importXmlDoc, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFilePath, jsonFormattedText);

            SuccessMessage("JSON");
        }
        catch (Exception exception)
        {
            if (exception is FileNotFoundException || exception is XmlException || Path.GetExtension(filePath) != ".xml")
            {
                Console.Clear();
                Console.WriteLine("XML file is either corrupted or not found at this location, bummer!");
                NoFileFoundReturnToMain();
            }
        }

        Environment.Exit(0);
    }

    private static void JsonToXmlConversion()
    {
        Console.WriteLine("Please input the absolute path to your JSON file and press ENTER so I can automagically convert it:");
        filePath = Console.ReadLine();

        NoFilePathHandler();

        try
        {
            string importJsonDoc = File.ReadAllText(filePath);
            Console.Clear();
            Console.WriteLine("I found your JSON file! Beep boop...");

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string xmlFilePath = Path.Combine(baseDir, $@"..\..\..\..\console_app_demo\files\JsonToXmlResult.xml");
            XNode xmlDeserializedText = JsonConvert.DeserializeXNode(importJsonDoc, "Root");
            File.WriteAllText(xmlFilePath, xmlDeserializedText.ToString());

            SuccessMessage("XML");
        }
        catch (Exception exception)
        {
            if (exception is FileNotFoundException || exception is JsonException || Path.GetExtension(filePath) != ".json")
            Console.Clear();
            Console.WriteLine("JSON file is either corrupted or not found at this location, drag!");
            NoFileFoundReturnToMain();
        }

        Environment.Exit(0);
    }
    
    private static void WrongTurn()
    {
        Console.WriteLine("Forsooth, then be on your merry way!");
        Environment.Exit(0);
    }

    private static void NoFilePathHandler()
    {
        if (filePath == null || filePath == "")
        {
            Console.WriteLine("Oops, perhaps you got trigger happy with that Enter button?");
            Thread.Sleep(1000);
            Console.WriteLine("Returning to the Main Menu...");
            Thread.Sleep(2000);
            MainMenu();
        }
    }

    private static void NoOptionsSelected()
    {
        Console.WriteLine("That wasn't one of the menu options. Please select 1, 2 or 3 from the above menu.");
        Thread.Sleep(2000);
        Console.Clear();
        MainMenu();
    }
    private static void NoFileFoundReturnToMain()
    {
        Thread.Sleep(2000);
        Console.WriteLine("Pobody's nerfect, let's try this again...");
        Thread.Sleep(2000);
        MainMenu();
    }

    private static string SuccessMessage(string formatType)
    {
        Thread.Sleep(3000);
        Console.Clear();
        Console.WriteLine($"Your file has been successfully converted and preserved in {formatType} format.");
        Console.WriteLine("Please close this console and navigate to the files directory in the repo to retrieve your new file.");
        Console.WriteLine("Have a lovely day!");
        return string.Empty;
    }
}