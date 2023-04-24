using HybridFramework.Test.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HybridFramework.Test.Tests;

public class GoogleCloudPricingCalcTests
{
    private IWebDriver _driver;

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
    }

    [Test]
    public void TestIt()
    {
        LoginPage loginPage = new LoginPage(_driver);
        loginPage.GoToPage();
        loginPage.EnterEmail_and_ClickNext("fakeepamacc@gmail.com");
        loginPage.EnterPassword_and_ClickNext("s944257242S@");

        GoogleCloudPricingCalcPage googleCloudPricingCalcPage = new GoogleCloudPricingCalcPage(_driver);
        googleCloudPricingCalcPage.GoToPage();
        googleCloudPricingCalcPage.ClickComputEngineButton();
        googleCloudPricingCalcPage.Click_and_InputInstances();
        googleCloudPricingCalcPage.Click_and_SelectOperatingSys();
        googleCloudPricingCalcPage.Click_and_SelectProvisioningModel();
        googleCloudPricingCalcPage.Click_and_SelectSeries();
        googleCloudPricingCalcPage.Click_and_SelectMachineType();
        googleCloudPricingCalcPage.AddGPU();
        googleCloudPricingCalcPage.Click_and_SelectLocalSSD();
        googleCloudPricingCalcPage.Click_and_SelectDataCenterLocation();
        googleCloudPricingCalcPage.Click_and_SelectCommitedUsage();
        googleCloudPricingCalcPage.ClickAddToEstimate();
        string estimatedCost = googleCloudPricingCalcPage.CopyEstimatedCost();

        EmailGeneratorPage emailGeneratorPage = new EmailGeneratorPage(_driver);
        emailGeneratorPage.GoToPage();
        emailGeneratorPage.GenerateEmail();
        string email = emailGeneratorPage.CopyEmail();

        googleCloudPricingCalcPage.PopUpEmailWindow();
        googleCloudPricingCalcPage.Click_and_TypeEmail(email);
        googleCloudPricingCalcPage.ClickSendEmailBtn();

        emailGeneratorPage.ClickEmailInbox();
        emailGeneratorPage.ClickRefresh();
        string totalCost = emailGeneratorPage.GetTotalCost();

        Assert.That(totalCost, Is.EqualTo(estimatedCost));
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
