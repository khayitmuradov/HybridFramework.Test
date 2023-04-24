using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace HybridFramework.Test.Pages;

public class LoginPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    private readonly string _pageUrl = "https://accounts.google.com/";

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    private IWebElement EmailInput => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[type='email']")));
    private IWebElement PasswordInput => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[type='password']")));
    private IWebElement NextButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#identifierNext")));
    private IWebElement SignInButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#passwordNext")));

    public void GoToPage()
    {
        _driver.Navigate().GoToUrl(_pageUrl);
    }

    public void EnterEmail_and_ClickNext(string email)
    {
        EmailInput.SendKeys(email);
        NextButton.Click();
    }

    public void EnterPassword_and_ClickNext(string password)
    {
        PasswordInput.SendKeys(password);
        SignInButton.Click();
    }
}
