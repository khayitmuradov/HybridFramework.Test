using HybridFramework.Test.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HybridFramework.Test.Pages;

public class BasePage
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
            ReadJsonConfiguration<List<User>>("../../../credentials.json");
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

    }

    [TearDown]
    public void TearDown()
    {
        WebDriverManager.TakeScreenshot();
        _driver.Quit();
    }
}
