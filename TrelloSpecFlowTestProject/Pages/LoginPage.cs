using NLog;
using OpenQA.Selenium;

namespace TrelloSpecFlowTestProject.Pages;

/// <summary>
/// Trello login page.
/// </summary>
public class LoginPage
{
    private const string LoginUrl = "https://trello.com/login";

    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private readonly IWebDriver _driver;

    /// <summary>
    /// Constructor for LoginPage class.
    /// </summary>
    /// <param name="driver"> Current web driver instance. </param>
    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
    }

    private IWebElement _emailInput => _driver.FindElement(By.Name("user"));
    private IWebElement _submitButton => _driver.FindElement(By.Id("login"));

    /// <summary>
    /// Open Trello Login page.
    /// </summary>
    public LoginPage OpenPage()
    {
        _driver.Navigate().GoToUrl(LoginUrl);
        return this;
    }

    /// <summary>
    /// Enter email and click Continue button.
    /// </summary>
    /// <param name="email"> User email address. </param>
    /// <returns> PasswordPageObject. </returns>
    public PasswordPage EnterEmail(string email)
    {
        _emailInput.SendKeys(email);
        Logger.Info("Input {0} into 'Email' field", email);
        _submitButton.Click();
        Logger.Info("Click 'Continue' button");

        return new PasswordPage(_driver);
    }
}