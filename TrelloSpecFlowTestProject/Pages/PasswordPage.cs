using NLog;
using OpenQA.Selenium;

namespace TrelloSpecFlowTestProject.Pages;

/// <summary>
/// Password page.
/// </summary>
public class PasswordPage
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private readonly IWebDriver _driver;


    private readonly By _passwordLocator = By.Name("password");

    /// <summary>
    /// Constructor for PasswordPage class.
    /// </summary>
    /// <param name="driver"> Current web driver instance. </param>
    public PasswordPage(IWebDriver driver)
    {
        _driver = driver;
    }

    private IWebElement _submitButton => _driver.FindElement(By.Id("login-submit"));

    /// <summary>
    /// Enter password and click 'Login' button.
    /// (Here we have to try to enter password several times, because of page reloading several times).
    /// </summary>
    /// <param name="password"></param>
    /// <returns> TrelloHomePage </returns>
    public TrelloHomePage EnterPassword(string password)
    {
        var attempts = 1;
        while (attempts <= 3)
        {
            try
            {
                var passwordInput = _driver.FindElement(_passwordLocator);
                Logger.Info("Input {0} into 'Password' field", password);
                passwordInput.SendKeys(password);
                break;
            }
            catch (StaleElementReferenceException e)
            {
                if (attempts == 3)
                {
                    Logger.Error(e, "Failed to enter password.");
                    throw;
                }

                Logger.Warn(
                    "StaleElementReferenceException while trying to interact with input password field. Attempt {0} from 3.",
                    attempts);
            }

            attempts++;
        }

        _submitButton.Click();
        Logger.Info("Click on 'Log In' button");

        return new TrelloHomePage(_driver);
    }
}