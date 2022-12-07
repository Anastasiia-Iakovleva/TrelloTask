using System;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TrelloSpecFlowTestProject.Drivers;

/// <summary>
/// Class for managing WebDriver instance.
/// </summary>
public class WebDriverManager
{
    private static IWebDriver _webDriver;
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    private WebDriverManager()
    {
    }
    /// <summary>
    /// Creates new webdriver instance or returns existing one.
    /// </summary>
    /// <returns> WebDriver instance. </returns>
    public static IWebDriver CreateWebDriverInstance()
    {
        if (_webDriver != null) return _webDriver;
        Logger.Info("WebDriver initizalization.");
        _webDriver = new ChromeDriver();
        _webDriver.Manage().Window.Maximize();
        _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

        return _webDriver;
    }

    /// <summary>
    /// Close WebDriver.
    /// </summary>
    public static void QuitWebDriver()
    {
        if (_webDriver == null) return;
        _webDriver.Quit();
        _webDriver = null;
        Logger.Info("WebDriver was closed.");
    }
}