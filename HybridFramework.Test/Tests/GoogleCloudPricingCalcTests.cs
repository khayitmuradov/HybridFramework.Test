using HybridFramework.Test.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
        Thread.Sleep(1000);


        _driver.SwitchTo().NewWindow(WindowType.Tab);
        _driver.Navigate().GoToUrl("https://yopmail.com/");

        EmailGeneratorPage emailGeneratorPage = new EmailGeneratorPage(_driver);
        emailGeneratorPage.GenerateEmail();
        string email = emailGeneratorPage.CopyEmail();
        Thread.Sleep(500);

        _driver.SwitchTo().Window(_driver.WindowHandles[0]);
        Thread.Sleep(500);

        _driver.SwitchTo().Frame(0);
        _driver.SwitchTo().Frame(0);
        googleCloudPricingCalcPage.PopUpEmailWindow();
        googleCloudPricingCalcPage.ClickInputEmail();
        googleCloudPricingCalcPage.InputEmail(email);
        googleCloudPricingCalcPage.ClickSendEmailBtn();


        _driver.SwitchTo().Window(_driver.WindowHandles[1]);
        Thread.Sleep(1000);
        emailGeneratorPage.ClickEmailInbox();
        emailGeneratorPage.ClickRefresh();
        _driver.SwitchTo().Frame(2);
        string totalCost = emailGeneratorPage.GetTotalCost();
        

        Assert.That(totalCost, Is.EqualTo("Estimated Monthly Cost: USD 12,854.64"));
        Thread.Sleep(1000);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
