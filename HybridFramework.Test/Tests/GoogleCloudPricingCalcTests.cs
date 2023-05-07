using HybridFramework.Test.Pages;

namespace HybridFramework.Test.Tests;
#nullable disable
public class GoogleCloudPricingCalcTests : CommonConditions
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
        GoogleCloudPricingCalcPage googleCloudPricingCalcPage = new GoogleCloudPricingCalcPage(_driver);
        EmailGeneratorPage emailGeneratorPage = new EmailGeneratorPage(_driver);
        loginPage.GoToPage();
        loginPage.Login(_CREDENTIALS.Email, _CREDENTIALS.Password);

        googleCloudPricingCalcPage.GoToPage();
        googleCloudPricingCalcPage.ClickComputEngineButton();
        googleCloudPricingCalcPage.FillTheForm();
        string estimatedCost = googleCloudPricingCalcPage.CopyEstimatedCost();

        emailGeneratorPage.GoToPage();
        emailGeneratorPage.GenerateEmail();
        string email = emailGeneratorPage.CopyEmail();

        googleCloudPricingCalcPage.PopUpEmailWindow();
        googleCloudPricingCalcPage.Click_and_TypeEmail(email);
        googleCloudPricingCalcPage.ClickSendEmailBtn();

        emailGeneratorPage.ClickEmailInbox();
        emailGeneratorPage.ClickRefresh();
        emailGeneratorPage.ClickRefresh();
        emailGeneratorPage.SwitchFrame();
        string totalCost = emailGeneratorPage.GetTotalCost();

        Assert.That(totalCost, Is.EqualTo(estimatedCost));
    }

    [OneTimeTearDown]
    public void CloseDriver()
    {
        TearDown();
    }
}
