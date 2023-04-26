using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
#nullable disable

namespace HybridFramework.Test;

public class WebDriverManager
{
    //public static void TakeScreenshot(string testName)
    //{
    //    if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
    //    {
    //        var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
    //        var screenshotPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, $"{TestContext.CurrentContext.Test.Name}_screenshot.png");
    //        screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
    //        TestContext.AddTestAttachment(screenshotPath, "Screenshot of failed test");
    //    }
    //}
}
