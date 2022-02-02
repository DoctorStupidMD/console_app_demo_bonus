using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;
using AppMethodsNamespace;

namespace ConversionMethodsNamespace;

class ConversionMethodsClass
{
    public static string? filePath;

    public static void XmlToJsonConversion()
    {
        Console.WriteLine("Please input the absolute path to your XML file and press ENTER so I can automagically convert it:");
        filePath = Console.ReadLine();

        AppMethodsClass.NoFilePathHandler();

        XmlDocument importXmlDoc = new();

        try
        {
            if (filePath is not null)
            {
                importXmlDoc.Load(filePath);
            }
            Console.Clear();
            Console.WriteLine("I found your XML file! Beep boop...");

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = Path.Combine(baseDir, $@"..\..\..\..\console_app_demo\files\XmlToJsonResult.json");
            string jsonFormattedText = JsonConvert.SerializeXmlNode(importXmlDoc, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFilePath, jsonFormattedText);

            AppMethodsClass.SuccessMessage("JSON");
        }
        catch (Exception exception)
        {
            if (exception is FileNotFoundException || exception is XmlException || Path.GetExtension(filePath) != ".xml")
            {
                Console.Clear();
                Console.WriteLine("XML file is either corrupted or not found at this location, bummer!");
                AppMethodsClass.NoFileFoundReturnToMain();
            }
        }

        Environment.Exit(0);
    }

    public static void JsonToXmlConversion()
    {
        Console.WriteLine("Please input the absolute path to your JSON file and press ENTER so I can automagically convert it:");
        filePath = Console.ReadLine();

        AppMethodsClass.NoFilePathHandler();

        try
        {
            if (filePath is not null) 
            {
                string importJsonDoc = File.ReadAllText(filePath);
                Console.Clear();
                Console.WriteLine("I found your JSON file! Beep boop...");

                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string xmlFilePath = Path.Combine(baseDir, $@"..\..\..\..\console_app_demo\files\JsonToXmlResult.xml");
                XNode? xmlDeserializedText = JsonConvert.DeserializeXNode(importJsonDoc, "Root");

                if (xmlDeserializedText is not null)
                {
                    File.WriteAllText(xmlFilePath, xmlDeserializedText.ToString());
                }
            }
            
            AppMethodsClass.SuccessMessage("XML");
        }
        catch (Exception exception)
        {
            if (exception is FileNotFoundException || exception is JsonException || Path.GetExtension(filePath) != ".json")
                Console.Clear();
            Console.WriteLine("JSON file is either corrupted or not found at this location, drag!");
            AppMethodsClass.NoFileFoundReturnToMain();
        }

        Environment.Exit(0);
    }
}