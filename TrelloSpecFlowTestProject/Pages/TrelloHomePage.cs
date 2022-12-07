using System;
using System.Linq;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TrelloSpecFlowTestProject.Pages;

/// <summary>
/// Trello Home page. Here we can create board and look at all created boards.
/// </summary>
public class TrelloHomePage
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private readonly IWebDriver _driver;

    private readonly By _createButtonFinder = By.XPath(".//button[@data-testid='header-create-menu-button']");

    private readonly By _createMenuPopupFinder = By.XPath(".//*[@data-testid='header-create-menu-popover']");

    private readonly By _visibilityOptionsMenuXpath = By.XPath(".//div[contains(@id, 'react-select')]");

    /// <summary>
    /// Constructor for TrelloHomePage class.
    /// </summary>
    /// <param name="driver"> Current web driver instance. </param>
    public TrelloHomePage(IWebDriver driver)
    {
        _driver = driver;
    }

    private IWebElement _boardTitleInput =>
        _driver.FindElement(By.XPath(".//*[@data-testid='create-board-title-input']"));

    private IWebElement _createBoardButton =>
        _driver.FindElement(By.XPath(".//button[@data-testid='header-create-board-button']"));

    private IWebElement _createBoardSubmitButton =>
        _driver.FindElement(By.XPath(".//button[@data-testid='create-board-submit-button']"));

    private IWebElement _createBoardTitle => _driver.FindElement(By.XPath(".//*[@title='Create board']"));

    private IWebElement _visibilitySelector =>
        _driver.FindElement(By.XPath(".//div[contains(@id, 'create-board-select-visibility')]"));
    
    /// <summary>
    /// Click on Create button in the top of the page and check, that Create Menu appears.
    /// </summary>
    /// <returns> TrelloHomePage. </returns>
    public TrelloHomePage ClickCreateButton()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        var createButton =
            wait.Until(ExpectedConditions.ElementIsVisible(_createButtonFinder));
        createButton.Click();
        Logger.Info("Click 'Create' button on page top.");
        var createMenuPopupFinder =
            wait.Until(ExpectedConditions.ElementIsVisible(_createMenuPopupFinder));
        //Sometimes page started reloading and clicking on the creation button does nothing; in this case we need to try second time.
        if (!createMenuPopupFinder.Displayed)
        {
            Logger.Info("Second attempt");
            createButton =
                wait.Until(ExpectedConditions.ElementExists(_createButtonFinder));
            createButton.Click();
        }

        return this;
    }

    /// <summary>
    /// Select 'Create Board' on Create Menu.
    /// </summary>
    /// <returns> TrelloHomePage. </returns>
    public TrelloHomePage ClickCreateBoardButton()
    {
        _createBoardButton.Click();
        Logger.Info("Click on 'Create Board' button.");
        return this;
    }

    /// <summary>
    /// Input board title.
    /// </summary>
    /// <param name="title"></param>
    /// <returns> TrelloHomePage. </returns>
    public TrelloHomePage EnterBoardTitle(string title)
    {
        _boardTitleInput.SendKeys(title);
        Logger.Info("Input {0} into 'Board title' field.", title);
        return this;
    }

    /// <summary>
    /// Select board visibility.
    /// </summary>
    /// <param name="visibilityOption"></param>
    /// <returns> TrelloHomePage. </returns>
    public TrelloHomePage SelectBoardVisibility(string visibilityOption)
    {
        _visibilitySelector.Click();
        Logger.Info("Click on 'Visibility' selector.");

        var visibilityOptionsList = _driver.FindElements(_visibilityOptionsMenuXpath);
        var visibilityOptionItem = visibilityOptionsList.FirstOrDefault(x => x.Text.StartsWith(visibilityOption));

        visibilityOptionItem.Click();

        return this;
    }

    /// <summary>
    /// Click Submit button to proceed new board creation.
    /// </summary>
    /// <returns> TrelloBoardPage. </returns>
    public TrelloBoardPage ClickSubmitButton()
    {
        _createBoardSubmitButton.Click();
        return new TrelloBoardPage(_driver);
    }
}