using TrelloSpecFlowTestProject.Pages;

namespace TrelloSpecFlowTestProject.Steps;

/// <summary>
/// Steps for logging into Trello.
/// </summary>
[Binding]
public class LoginStepDefinitions : AbstractStepDefinition
{
    [Given("User logged into Trello using username '(.*)' and password '(.*)'")]
    public void Authorize(string username, string password)
    {
        var loginPage = new LoginPage(WebDriver);
        loginPage.OpenPage();

        var usernameValue = ParseProperty(username);
        var passwordValue = ParseProperty(password);

        var passwordPage = loginPage.EnterEmail(usernameValue);
        passwordPage.EnterPassword(passwordValue);
    }
}