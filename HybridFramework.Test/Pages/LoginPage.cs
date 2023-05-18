using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
#nullable disable
namespace HybridFramework.Test.Pages;

public class LoginPage : BasePage
{
    private readonly string _pageUrl = "https://accounts.google.com/";

    public LoginPage(IWebDriver _driver) : base(_driver) { }

    private IWebElement EmailInput => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[type='email']")));
    private IWebElement PasswordInput => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[type='password']")));
    private IWebElement NextButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#identifierNext")));
    private IWebElement SignInButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#passwordNext")));

    public void Login(string email, string password)
    {
        GoToPage(_pageUrl);
        EmailInput.SendKeys(email);
        NextButton.Click();
        PasswordInput.SendKeys(password);
        SignInButton.Click();
        WebDriverWait loginWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
        loginWait.Until(ExpectedConditions.TitleContains("Google"));
    }
}
