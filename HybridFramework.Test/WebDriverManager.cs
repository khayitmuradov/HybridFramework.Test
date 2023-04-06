using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
#nullable disable

namespace HybridFramework.Test;

public class WebDriverManager
{
    private static IWebDriver _driver;

    public static IWebDriver Driver
    {
        get
        {
            if (_driver == null)
            {
                _driver = new ChromeDriver();
            }
            return _driver;
        }
    }

    public static void QuitDriver()
    {
        _driver.Quit();
        _driver = null;
    }

    public static void TakeScreenshot(string testName)
    {
        string screenshotPath = Path.Combine("Screenshots", testName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png");
        Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
        screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
    }

    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            TakeScreenshot(TestContext.CurrentContext.Test.Name);
        }
        QuitDriver();
    }

}
