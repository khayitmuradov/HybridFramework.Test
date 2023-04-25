using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace HybridFramework.Test.Pages;

public class GoogleCloudPricingCalcPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    private readonly string _pageUrl = "https://cloud.google.com/products/calculator";

    public GoogleCloudPricingCalcPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
    }

    private IWebElement ComputeEngineButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#tab-item-1 .hexagon-in2")));
    private IWebElement Instances => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("input_95")));
    private IWebElement InstancesInput => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("input_95")));
    private IWebElement OperatingSys => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_value_label_87 .md-text")));
    private IWebElement OperatingSysSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_option_97 > .md-text")));
    private IWebElement ProvisioningModel => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("select_value_label_88")));
    private IWebElement ProvisioningModelSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_option_110 > .md-text")));
    private IWebElement Series => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_value_label_90 > span:nth-child(1)")));
    private IWebElement SeriesSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("select_option_211")));
    private IWebElement MachineType => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_value_label_91 .md-text")));
    private IWebElement MachineTypeSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_option_450 > .md-text")));
    private IWebElement AddGPUCheckbox => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".layout-row:nth-child(15) .md-container")));
    private IWebElement GPUType => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("select_486")));
    private IWebElement GPUTypeSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_option_491 > .md-text")));
    private IWebElement NumberOfGPUs => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_value_label_485 > span:nth-child(1)")));
    private IWebElement NumberOfGPUsSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("select_option_498")));
    private IWebElement LocalSSD => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_value_label_444 > span:nth-child(1)")));
    private IWebElement LocalSSDSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_option_471 > .md-text")));
    private IWebElement DatacenterLocation => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_value_label_93 .md-text")));
    private IWebElement DatacenterLocationSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("select_option_252")));
    private IWebElement CommitedUsage => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#select_value_label_94 .md-text")));
    private IWebElement CommitedUsageSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("select_option_133")));
    private IWebElement GetIntoMainForm => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("mainForm")));
    private IWebElement AddToEstimateBtn => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".layout-align-end-start:nth-child(22) > .md-raised")));
    private IWebElement CopyTotalEstimatedCost => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='cpc-cart-total']")));

    private IWebElement EmailPopUp => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//button[@class='md-fab md-primary md-mini md-button md-ink-ripple'])[2]")));
    private IWebElement EmailInput => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("input_563")));
    private IWebElement SendEmailBtn => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".md-raised:nth-child(2)")));

    public void GoToPage()
    {
        _driver.Navigate().GoToUrl(_pageUrl);
    }

    public void ClickComputEngineButton()
    {
        Thread.Sleep(1000);
        _driver.SwitchTo().Frame(0);
        Thread.Sleep(1000);
        _driver.SwitchTo().Frame(0);
        ComputeEngineButton.Click();
    }

    public void Click_and_InputInstances()
    {
        Instances.Click();
        InstancesInput.SendKeys("4");
    }

    public void Click_and_SelectOperatingSys()
    {
        OperatingSys.Click();
        OperatingSysSelection.Click();
    }

    public void Click_and_SelectProvisioningModel()
    {
        ProvisioningModel.Click();
        ProvisioningModelSelection.Click();
    }

    public void Click_and_SelectSeries()
    {
        Series.Click();
        SeriesSelection.Click();
    }

    public void Click_and_SelectMachineType()
    {
        MachineType.Click();
        MachineTypeSelection.Click();
    }

    public void AddGPU()
    {
        AddGPUCheckbox.Click();
        GPUType.Click();
        GPUTypeSelection.Click();
        NumberOfGPUs.Click();
        NumberOfGPUsSelection.Click();
    }

    public void Click_and_SelectLocalSSD()
    {
        LocalSSD.Click();
        LocalSSDSelection.Click();
    }

    public void Click_and_SelectDataCenterLocation()
    {
        DatacenterLocation.Click();
        DatacenterLocationSelection.Click();
    }

    public void Click_and_SelectCommitedUsage()
    {
        CommitedUsage.Click();
        CommitedUsageSelection.Click();
    }

    public void ClickAddToEstimate()
    {
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
