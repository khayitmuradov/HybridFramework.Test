using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridFramework.Test.Pages;

public class LoginPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    private IWebElement EmailInput => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[type='email']")));
    private IWebElement PasswordInput => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[type='password']")));
    private IWebElement NextButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#identifierNext")));
    private IWebElement SignInButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#passwordNext")));

    public void EnterEmail(string email)
    {
        EmailInput.SendKeys(email);
    }

    public void EnterPassword(string password)
    {
        PasswordInput.SendKeys(password);
    }

    public void ClickNext()
    {
        NextButton.Click();
    }

    public void ClickSignIn()
    {
        SignInButton.Click();
    }
}
