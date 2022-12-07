using System;
using Shouldly;
using TrelloSpecFlowTestProject.Pages;

namespace TrelloSpecFlowTestProject.Steps;

/// <summary>
/// Steps for creating a new board.
/// </summary>
[Binding]
public class CreateNewBoardStepDefinitions : AbstractStepDefinition
{
    private readonly TrelloHomePage _homePage;

    private readonly ScenarioContext _scenarioContext;
    private TrelloBoardPage _boardPage;

    public CreateNewBoardStepDefinitions(ScenarioContext scenarioContext)
    {
        _homePage = new TrelloHomePage(WebDriver);
        _scenarioContext = scenarioContext;
    }

    [When("User clicks on the 'Create' button in Boards page")]
    public void ClickOnTheCreateButtonInPageHeader()
    {
        _homePage.ClickCreateButton();
    }

    [When("User clicks on the 'Create Board' button in Creation menu in Boards page")]
    public void ClickOnCreateBoardButton()
    {
        _homePage.ClickCreateBoardButton();
    }

    [When("User inputs '(.*)' into the Board Title input in Boards page")]
    public void InputBoardTitle(string title)
    {
        _homePage.EnterBoardTitle(title);
    }

    [When("User selects '(.*)' visibility option in Boards page")]
    public void SelectVisibility(string visibilityOption)
    {
        _homePage.SelectBoardVisibility(visibilityOption);
    }

    [When("User fills Board Title input in Boards page")]
    public void InputBoardTitle()
    {
        var rnd = new Random();

        var boardTitle = "Test Board" + rnd.Next(100, 999);
        _scenarioContext["BoardTitle"] = boardTitle;

        _homePage.EnterBoardTitle(boardTitle);
    }

    [When("User clicks on the 'Create' button in Create Board menu in Boards page")]
    public void SubmitBoard()
    {
        _boardPage = _homePage.ClickSubmitButton();
    }

    [Then("Created board is opened")]
    public void CheckIfBoardIsOpened()
    {
        var expectedBoardName = _scenarioContext["BoardTitle"];
        var actualBoardName = _boardPage.GetCurrentBoardName();
        actualBoardName.ShouldBe(expectedBoardName);
    }

    [Then("The board was added to My Boards list")]
    public void CheckIfMyBoardsListContainsBoard()
    {
        var expectedBoardName = _scenarioContext["BoardTitle"];
        var myBoardsList = _boardPage.GetMyBoardsList();
        myBoardsList.ShouldContain(expectedBoardName);
    }

    [Then("The displayed Board Permission level is '(.*)'")]
    public void CheckBoardPermissionLevel(string expectedPermissionLevel)
    {
        var actualPermissionLevel = _boardPage.GetBoardPermissionLevel();
        actualPermissionLevel.ShouldBe(expectedPermissionLevel);
    }
}