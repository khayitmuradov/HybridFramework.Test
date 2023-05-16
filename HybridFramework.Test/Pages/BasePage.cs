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

    public void GoToPage(string url)
    {
        _driver.Navigate().GoToUrl(url);
    }

    public void OpenNewTab()
    {
        _driver.SwitchTo().NewWindow(WindowType.Tab);
    }

    public void SwitchFrames()
    {
        _driver.SwitchTo().Frame(2);
    }

    public void RefreshPage() 
    { 
        _driver.Navigate().Refresh();
    }
}
