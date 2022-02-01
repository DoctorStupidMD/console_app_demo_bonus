using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;
using MainMenuNamespace;

namespace AppMethodsNamespace;

public class AppMethods
{
    static string? filePath;

    public void XmlToJsonConversion()
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

    public void JsonToXmlConversion()
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
            if (xmlDeserializedText is not null)
            {
                File.WriteAllText(xmlFilePath, xmlDeserializedText.ToString());
            }

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

    public void NoFilePathHandler()
    {
        MainMenuClass mainMenuClass = new MainMenuClass();

        if (filePath == null || filePath == "")
        {
            Console.WriteLine("Oops, perhaps you got trigger happy with that Enter button?");
            Thread.Sleep(1000);
            Console.WriteLine("Returning to the Main Menu...");
            Thread.Sleep(2000);
            MainMenuClass.MainMenu();
        }
    }

    public void NoOptionsSelected()
    {
        Console.WriteLine("That wasn't one of the menu options. Please select 1, 2 or 3 from the above menu.");
        Thread.Sleep(2000);
        Console.Clear();
        MainMenuClass.MainMenu();
    }
    public void NoFileFoundReturnToMain()
    {
        Thread.Sleep(2000);
        Console.WriteLine("Pobody's nerfect, let's try this again...");
        Thread.Sleep(2000);
        MainMenuClass.MainMenu();
    }

    public string SuccessMessage(string formatType)
    {
        Thread.Sleep(3000);
        Console.Clear();
        Console.WriteLine($"Your file has been successfully converted and preserved in {formatType} format.");
        Console.WriteLine("Please close this console and navigate to the files directory in the repo to retrieve your new file.");
        Console.WriteLine("Have a lovely day!");
        return string.Empty;
    }
}