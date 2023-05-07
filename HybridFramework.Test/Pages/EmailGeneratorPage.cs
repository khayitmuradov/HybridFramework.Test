using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace HybridFramework.Test.Pages;

public class EmailGeneratorPage : BasePage
{
    private readonly string _pageUrl = "https://yopmail.com/";

    public EmailGeneratorPage(IWebDriver _driver) : base(_driver)
    {
    }

    private IWebElement EmailGenerateBtn => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a:nth-child(1) p")));
    private IWebElement Email => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='geny']")));
    private IWebElement EmailInbox => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".md:nth-child(3) > .material-icons-outlined")));
    private IWebElement RefreshPage => _wait.Until(ExpectedConditions.ElementExists(By.Id("refresh")));
    private IWebElement TotalCost => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='mail']/div/div/table/tbody/tr[2]/td/h2")));

    public void GoToPage()
    {
        _driver.SwitchTo().NewWindow(WindowType.Tab);
        _driver.Navigate().GoToUrl(_pageUrl);
    }

    public void GenerateEmail()
    {
        EmailGenerateBtn.Click();
    }

    public string CopyEmail()
    {
        return Email.Text;
    }

    public void ClickEmailInbox()
    {
        _driver.SwitchTo().Window(_driver.WindowHandles[1]);
        EmailInbox.Click();
    }

    public string GetTotalCost()
    {
        string copiedText = TotalCost.Text;
        string[] words = copiedText.Split(' ');
        string cost = words[4];

        return cost;
    }

    public void ClickRefresh()
    {
        RefreshPage.Click();
    }

    public void SwitchFrame()
    {
        _driver.SwitchTo().Frame(2);
    }
}
