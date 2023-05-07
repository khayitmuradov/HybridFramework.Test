using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
#nullable disable
namespace HybridFramework.Test.Pages;

public class GoogleCloudPricingCalcPage : BasePage
{
    private readonly string _pageUrl = "https://cloud.google.com/products/calculator";

    public GoogleCloudPricingCalcPage(IWebDriver _driver) : base(_driver)
    {
    }

    private IWebElement ComputeEngineButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#tab-item-1 .hexagon-in2")));
    private IWebElement Instances => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("input_96")));
    private IWebElement InstancesInput => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("input_96")));
    private IWebElement OperatingSys => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_value_label_88 .md-text")));
    private IWebElement OperatingSysSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_option_98 > .md-text")));
    private IWebElement OperatingSysSelection2 => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_value_label_89 > span:nth-child(1)")));
    private IWebElement ProvisioningModel => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("select_option_111")));
    private IWebElement ProvisioningModelSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("select_value_label_91")));
    private IWebElement Series => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("select_option_212")));
    private IWebElement SeriesSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_value_label_92 .md-text")));
    private IWebElement MachineType => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_option_451 > .md-text")));
    private IWebElement MachineTypeSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".layout-row:nth-child(15) .md-container")));
    private IWebElement AddGPUCheckbox => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("select_487")));
    private IWebElement GPUType => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_option_492 > .md-text")));
    private IWebElement GPUTypeSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("select_value_label_486")));
    private IWebElement NumberOfGPUs => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("select_option_499")));
    private IWebElement NumberOfGPUsSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_value_label_445 > span:nth-child(1)")));
    private IWebElement LocalSSD => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("select_option_472")));
    private IWebElement LocalSSDSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_value_label_94 .md-text")));
    private IWebElement DatacenterLocationSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_option_253 > .md-text")));
    private IWebElement CommitedUsage => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_value_label_95 > span:nth-child(1)")));
    private IWebElement CommitedUsageSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("select_option_134")));
    private IWebElement GetIntoMainForm => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("mainForm")));
    private IWebElement AddToEstimateBtn => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".layout-align-end-start:nth-child(22) > .md-raised")));
    private IWebElement CopyTotalEstimatedCost => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='cpc-cart-total']")));

    private IWebElement EmailPopUp => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//button[@class='md-fab md-primary md-mini md-button md-ink-ripple'])[2]")));
    private IWebElement EmailInput => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("input_564")));
    private IWebElement SendEmailBtn => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".md-raised:nth-child(2)")));

    private IWebDriver firstFrame => _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[@src='https://cloud.google.com/frame/products/calculator/index_d6a98ba38837346d20babc06ff2153b68c2990fa24322fe52c5f83ec3a78c6a0.frame']")));
    private IWebDriver SecondFrame => _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[@id='myFrame']")));

    public void GoToPage()
    {
        _driver.Navigate().GoToUrl(_pageUrl);
    }

    public void ClickComputEngineButton()
    {
        Thread.Sleep(5000);
        _driver.SwitchTo().Frame(0);
        Thread.Sleep(500);
        _driver.SwitchTo().Frame(0);
        ComputeEngineButton.Click();
    }

    public void FillTheForm()
    {
        Instances.Click();
        InstancesInput.SendKeys("4");
        OperatingSys.Click();
        OperatingSysSelection.Click();
        OperatingSysSelection2.Click();
        ProvisioningModel.Click();
        ProvisioningModelSelection.Click();
        Series.Click();
        SeriesSelection.Click();
        MachineType.Click();
        MachineTypeSelection.Click();
        AddGPUCheckbox.Click();
        GPUType.Click();
        GPUTypeSelection.Click();
        NumberOfGPUs.Click();
        NumberOfGPUsSelection.Click();
        LocalSSD.Click();
        LocalSSDSelection.Click();
        DatacenterLocationSelection.Click();
        CommitedUsage.Click();
        CommitedUsageSelection.Click();
        GetIntoMainForm.Click();
        AddToEstimateBtn.Click();
    }

    public string CopyEstimatedCost()
    {
        string copiedText = CopyTotalEstimatedCost.Text;
        string[] words = copiedText.Split(' ');
        string desiredWord = words[4];
        return desiredWord;
    }

    public void PopUpEmailWindow()
    {
        _driver.SwitchTo().Window(_driver.WindowHandles[0]);
        _driver.SwitchTo().Frame(0);
        _driver.SwitchTo().Frame(0);
        EmailPopUp.Click();
    }

    public void Click_and_TypeEmail(string email)
    {
        EmailInput.Click();
        EmailInput.SendKeys(email);
    }

    public void ClickSendEmailBtn()
    {
        SendEmailBtn.Click();
    }
}
