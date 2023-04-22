using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace HybridFramework.Test.Pages;

public class GoogleCloudPricingCalcPage
{
    private readonly WebDriverWait _wait;

    public GoogleCloudPricingCalcPage(IWebDriver driver)
    {
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


    public void ClickComputEngineButton()
    {
        ComputeEngineButton.Click();
    }

    public void ClickInstances()
    {
        Instances.Click();
    }

    public void InputInstance()
    {
        InstancesInput.SendKeys("4");
    }

    public void ClickOperatingSys()
    {
        OperatingSys.Click();
    }

    public void SelectOS()
    {
        OperatingSysSelection.Click();
    }

    public void ClickProvisioningModel()
    {
        ProvisioningModel.Click();
    }

    public void SelectProvisioningModel()
    {
        ProvisioningModelSelection.Click();
    }

    public void ClickSeries()
    {
        Series.Click();
    }

    public void SelectSeries()
    {
        SeriesSelection.Click();
    }

    public void ClickMachineType()
    {
        MachineType.Click();
    }

    public void SelectMachineType()
    {
        MachineTypeSelection.Click();
    }

    public void AddGPU()
    {
        AddGPUCheckbox.Click();
    }

    public void ClickGPUType()
    {
        GPUType.Click();
    }

    public void SelectGPUType()
    {
        GPUTypeSelection.Click();
    }

    public void ClickNumberOfGPUs()
    {
        NumberOfGPUs.Click();
    }

    public void SelectNumberOfGPUs()
    {
        NumberOfGPUsSelection.Click();
    }

    public void ClickLocalSSD()
    {
        LocalSSD.Click();
    }

    public void SelectLocalSSD()
    {
        LocalSSDSelection.Click();
    }

    public void ClickDataCenterLocation()
    {
        DatacenterLocation.Click();
    }

    public void SelectDataCenterLocation()
    {
        DatacenterLocationSelection.Click();
    }

    public void ClickCommitedUsage()
    {
        CommitedUsage.Click();
    }

    public void SelectCommitedUsage()
    {
        CommitedUsageSelection.Click();
    }

    public void ClickAddToEstimate()
    {
        GetIntoMainForm.Click();
        AddToEstimateBtn.Click();
    }
}
