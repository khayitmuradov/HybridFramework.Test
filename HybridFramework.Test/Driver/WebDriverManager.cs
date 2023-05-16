using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace HybridFramework.Test.Driver;

public class WebDriverManager
{
    public IWebDriver CreateWebDriver(string browserName)
    {
        IWebDriver driver;

        switch (browserName.ToLower())
        {
            case "chrome":
                driver = new ChromeDriver();
                break;
            case "firefox":
                driver = new FirefoxDriver();
                break;
            case "edge":
                driver = new EdgeDriver();
                break;
            default:
                throw new ArgumentException($"Browser '{browserName}' is not supported");
        }

        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        return driver;
    }

    public void CloseWebDriver(IWebDriver driver)
    {
        driver.Quit();
    }
}
