using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;

namespace TrelloSpecFlowTestProject.Pages;

/// <summary>
/// Trello Board page. Displays created board.
/// </summary>
public class TrelloBoardPage
{
    private readonly IWebDriver _driver;
    
    /// <summary>
    /// Constructor for TrelloBoardPage class.
    /// </summary>
    /// <param name="driver"> Current web driver instance. </param>
    public TrelloBoardPage(IWebDriver driver)
    {
        _driver = driver;
    }

    private IWebElement _boardTitle => _driver.FindElement(By.XPath(".//div[contains(@class, 'mod-board-name')]/h1"));

    private ReadOnlyCollection<IWebElement> _myBoardsList => _driver
        .FindElements(
            By.XPath(
                ".//div[@data-testid='collapsible-list']/div[./h2[contains(text(), 'Your boards')]]/following-sibling::ul/div/li"));

    private IWebElement boardPermissionLevelLink => _driver.FindElement(By.Id("permission-level"));

    /// <summary>
    /// Get name of opened board.
    /// </summary>
    /// <returns> Board name. </returns>
    public string GetCurrentBoardName()
    {
        return _boardTitle.Text;
    }

    /// <summary>
    /// Get names of all created boards for current user.
    /// </summary>
    /// <returns> List of board names. </returns>
    public List<string> GetMyBoardsList()
    {
        return _myBoardsList.Select(x => x.Text).ToList();
    }

    /// <summary>
    /// Get board permission level (Private/Public/Workplace visible).
    /// </summary>
    /// <returns> Board permission level name. </returns>
    public string GetBoardPermissionLevel()
    {
        return boardPermissionLevelLink.Text;
    }
}