using HybridFramework.Test.Models;
using HybridFramework.Test.Pages;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HybridFramework.Test.Tests;
#nullable disable
public class GoogleCloudPricingCalcTests
{
    private IWebDriver _driver;
    private List<User> _CREDENTIALSLIST;
    private User _CREDENTIALS;
    private WebDriverWait _wait;

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _CREDENTIALSLIST = ConfigurationHelper.
            ReadJsonConfiguration<List<User>>("credentials/credentials.json");
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        
    }

    [Test]
    public void GoogleCloudPricingCalcTest()
    {
        _CREDENTIALS = _CREDENTIALSLIST[0];
        LoginPage loginPage = new LoginPage(_driver);
        loginPage.GoToPage();
        loginPage.Login(_CREDENTIALS.Email, _CREDENTIALS.Password);

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
        WebDriverManager.TakeScreenshot();
        _driver.Quit();
    }
}
