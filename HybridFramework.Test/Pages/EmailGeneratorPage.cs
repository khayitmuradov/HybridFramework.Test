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
    private IWebElement TotalCost => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//h3)[2]")));

    public void GenerateEmail()
    {
        OpenNewTab();
        GoToPage(_pageUrl);
        EmailGenerateBtn.Click();
    }

    public string CopyEmail()
    {
        return Email.Text;
    }

    public void CheckEmailInbox_and_VerifyTotalCostIsStillSameOrNot()
    {
        _driver.SwitchTo().Window(_driver.WindowHandles[1]);
        EmailInbox.Click();
        RefreshPage();
        RefreshPage();
        _driver.SwitchTo().Frame(2);
    }

    public string GetTotalCost()
    {
        string copiedText = TotalCost.Text;
        string[] words = copiedText.Split(' ');
        string cost = words[1];

        return cost;
    }
}
