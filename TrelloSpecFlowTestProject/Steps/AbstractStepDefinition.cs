using OpenQA.Selenium;
using TrelloSpecFlowTestProject.Drivers;
using TrelloSpecFlowTestProject.Utils;

namespace TrelloSpecFlowTestProject.Steps;

/// <summary>
/// Common actions for all StepDefinition classes.
/// </summary>
public abstract class AbstractStepDefinition
{
    protected AbstractStepDefinition()
    {
        WebDriver = WebDriverManager.CreateWebDriverInstance();
    }

    protected IWebDriver WebDriver { get; }

    protected string ParseProperty(string value)
    {
        if (!value.StartsWith("$")) return value;

        var key = value.Substring(1);
        var propValue = Properties.GetProperty(key);
        return propValue ?? value;
    }
}