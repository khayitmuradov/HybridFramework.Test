using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
#pragma warning disable

namespace HybridFramework.Test;

public class WebDriverManager
{
    private static IWebDriver _driver;

    public static void TakeScreenshot()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            var screenshotPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, $"screenshots/{TestContext.CurrentContext.Test.Name}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.png");
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(screenshotPath, "Screenshot of failed test");
        }
    }
}
