using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridFramework.Test.Pages;

public class LoginPage
{
    private readonly IWebDriver _driver;

    private IWebElement UsernameField => _driver.FindElement(By.Id("username"));
    private IWebElement PasswordField => _driver.FindElement(By.Id("password"));
    private IWebElement SubmitButton => _driver.FindElement(By.Id("submit"));

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void Login(string username, string password)
    {
        UsernameField.SendKeys(username);
        PasswordField.SendKeys(password);
        SubmitButton.Click();
    }
}
