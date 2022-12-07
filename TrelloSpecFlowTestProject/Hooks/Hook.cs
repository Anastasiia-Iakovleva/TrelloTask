using NLog;
using TrelloSpecFlowTestProject.Drivers;
using TrelloSpecFlowTestProject.Utils;

namespace TrelloSpecFlowTestProject.Hooks;

/// <summary>
/// Before and After actions for test scenarios.
/// </summary>
[Binding]
public class Hooks
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    [BeforeTestRun]
    public static void LoadTestProperties()
    {
        Logger.Info("Reading properties from test.properties file...");
        PropertiesReader.ReadTestPropertiesFromFile();
    }

    [AfterScenario]
    public static void CloseWebDriver()
    {
        Logger.Info("Closing WebDriver...");
        WebDriverManager.QuitWebDriver();
    }
}