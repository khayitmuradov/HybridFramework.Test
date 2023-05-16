using HybridFramework.Test.Pages;

namespace HybridFramework.Test.Tests;
#nullable disable
[TestFixture]
public class GoogleCloudPricingCalcTests : BaseTest
{
    [OneTimeSetUp]
    public void SetUp()
    {
        Initialize();
    }

    [Test]
    public void GoogleCloudPricingCalcTest()
    {
        _credentials = _credentialsList[4];
        LoginPage loginPage = new LoginPage(_driver);
        GoogleCloudPricingCalcPage googleCloudPricingCalcPage = new GoogleCloudPricingCalcPage(_driver);
        EmailGeneratorPage emailGeneratorPage = new EmailGeneratorPage(_driver);
        loginPage.GoToPage();
        loginPage.Login(_credentials.Email, _credentials.Password);


        googleCloudPricingCalcPage.ClickComputEngineButton();
        googleCloudPricingCalcPage.FillTheForm();
        string estimatedCost = googleCloudPricingCalcPage.CopyEstimatedCost();

        emailGeneratorPage.GenerateEmail();
        string email = emailGeneratorPage.CopyEmail();

        googleCloudPricingCalcPage.PopUpEmailWindow();
        googleCloudPricingCalcPage.Click_and_TypeEmail(email);
        googleCloudPricingCalcPage.ClickSendEmailBtn();

        emailGeneratorPage.CheckEmailInbox_and_VerifyTotalCostIsStillSameOrNot();
        string totalCost = emailGeneratorPage.GetTotalCost();

        Assert.That(totalCost, Is.EqualTo(estimatedCost));
    }

    [OneTimeTearDown]
    public void CloseDriver()
    {
        TearDown();
    }
}
