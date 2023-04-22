using HybridFramework.Test.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HybridFramework.Test.Tests;

public class GoogleCloudPricingCalcTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    [Test]
    public void TestIt()
    {
        LoginPage loginPage = new LoginPage(_driver);
        loginPage.GoToPage();
        loginPage.EnterEmail("fakeepamacc@gmail.com");
        loginPage.ClickNext();
        loginPage.EnterPassword("s944257242S@");
        loginPage.ClickSignIn();


        _driver.Navigate().GoToUrl("https://cloud.google.com/products/calculator");
        _driver.SwitchTo().Frame(0);
        _driver.SwitchTo().Frame(0);
        GoogleCloudPricingCalcPage googleCloudPricingCalcPage = new GoogleCloudPricingCalcPage(_driver);
        googleCloudPricingCalcPage.ClickComputEngineButton();
        googleCloudPricingCalcPage.ClickInstances();
        googleCloudPricingCalcPage.InputInstance();
        googleCloudPricingCalcPage.ClickOperatingSys();
        googleCloudPricingCalcPage.SelectOS();
        googleCloudPricingCalcPage.ClickProvisioningModel();
        googleCloudPricingCalcPage.SelectProvisioningModel();
        googleCloudPricingCalcPage.ClickSeries();
        googleCloudPricingCalcPage.SelectSeries();
        googleCloudPricingCalcPage.ClickMachineType();
        googleCloudPricingCalcPage.SelectMachineType();
        googleCloudPricingCalcPage.AddGPU();
        googleCloudPricingCalcPage.ClickGPUType();
        googleCloudPricingCalcPage.SelectGPUType();
        googleCloudPricingCalcPage.ClickNumberOfGPUs();
        googleCloudPricingCalcPage.SelectNumberOfGPUs();
        googleCloudPricingCalcPage.ClickLocalSSD();
        googleCloudPricingCalcPage.SelectLocalSSD();
        googleCloudPricingCalcPage.ClickDataCenterLocation();
        googleCloudPricingCalcPage.SelectDataCenterLocation();
        googleCloudPricingCalcPage.ClickCommitedUsage();
        googleCloudPricingCalcPage.SelectCommitedUsage();
        googleCloudPricingCalcPage.ClickAddToEstimate();

        Thread.Sleep(10000);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
