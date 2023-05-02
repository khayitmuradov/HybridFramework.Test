using HybridFramework.Test.Pages;
namespace HybridFramework.Test.Tests;
#nullable disable
public class GoogleCloudPricingCalcTests : BasePage
{
    [OneTimeSetUp]
    public void SetUp()
    {
        Initialize();
    }

    [Test]
    public void GoogleCloudPricingCalcTest()
    {
        _CREDENTIALS = _CREDENTIALSLIST[4];
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

    [OneTimeTearDown]
    public void CloseDriver()
    {
        TearDown();
    }
}
