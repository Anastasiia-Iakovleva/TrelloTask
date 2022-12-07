using System.IO;
using System.Linq;
using System.Reflection;

namespace TrelloSpecFlowTestProject.Utils;

/// <summary>
/// Properties file reader.
/// </summary>
public static class PropertiesReader
{
    private const string PropertiesFileLocation = "test.properties";

    /// <summary>
    /// Read properties from test.properties file and add them to the storage.
    /// </summary>
    public static void ReadTestPropertiesFromFile()
    {
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            PropertiesFileLocation);
        File.ReadAllLines(path).ToList().ForEach(s => Properties.AddProperty(s.Split('=')[0], s.Split('=')[1]));
    }
}