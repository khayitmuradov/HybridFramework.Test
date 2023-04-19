using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace HybridFramework.Test.Pages;

public class GoogleCloudPricingCalcPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public GoogleCloudPricingCalcPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public IWebElement PricingButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//a[@class='devsite-tabs-content gc-analytics-event '])[4]")));
    public IWebElement PricingCalculatorButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//a[@href='https://cloud.google.com/products/calculator'])[1]")));
    public IWebElement ComputeEngineButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//a[@href='https://cloud.google.com/products/calculator'])[1]")));
    public IWebElement NumberOfInstancesInput => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='input_712']")));
    public IWebElement OSDropdown => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='input_712']")));
    public IWebElement OSSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@class='md-text'])[1]")));
    public IWebElement ProvisingModel => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-select-value[@id='select_value_label_705']")));
    public IWebElement ProvisingModelSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option[@id='select_option_727']")));
    public IWebElement SeriesDropdown => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-select-value[@id='select_value_label_90']")));
    public IWebElement SeriesDropdownSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-option[@id='select_option_211']")));
    public IWebElement AddGPUCheckbox => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@class='md-container md-ink-ripple'])[3]")));
    public IWebElement GPUTypeSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//md-select[@class='ng-pristine ng-valid ng-empty ng-touched']")));
    public IWebElement GPUSelection => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@class='md-text ng-binding'])[30]")));
}
