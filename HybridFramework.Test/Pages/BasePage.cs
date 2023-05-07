using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HybridFramework.Test.Pages;

public abstract class BasePage
{
    public IWebDriver _driver;
    public WebDriverWait _wait;

    public BasePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
    }
}
