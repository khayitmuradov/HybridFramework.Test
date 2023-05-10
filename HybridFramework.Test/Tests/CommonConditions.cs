using HybridFramework.Test.Model;
using HybridFramework.Test.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HybridFramework.Test.Tests;

public class CommonConditions
{
    public IWebDriver _driver;
    public List<User> _CREDENTIALSLIST;
    public User? _CREDENTIALS;
    public WebDriverWait _wait;

    [SetUp]
    public void Initialize()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _CREDENTIALSLIST = ConfigurationHelper.
            ReadJsonConfiguration<List<User>>("../../../TestData/credentials.json");
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

    }

    [TearDown]
    public void TearDown()
    {
        ErrorListener.TakeScreenshot();
        _driver.Quit();
    }
}
