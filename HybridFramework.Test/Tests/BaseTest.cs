﻿using HybridFramework.Test.Driver;
using HybridFramework.Test.Model;
using HybridFramework.Test.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
#nullable disable
namespace HybridFramework.Test.Tests;

public class BaseTest
{
    public IWebDriver _driver;
    public List<User> _credentialsList;
    public User _credentials;
    public TestDataReader _testDataReader;
    public WebDriverWait _wait;
    public WebDriverManager _driverManager;

    [SetUp]
    public void Initialize()
    {
        _driverManager = new WebDriverManager();
        _driver = _driverManager.CreateWebDriver("chrome");
        _driver.Manage().Window.Maximize();
        _testDataReader = new TestDataReader();
        _credentialsList = ConfigurationHelper.
            ReadJsonConfiguration<List<User>>("../../../TestData/credentials.json");
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    [TearDown]
    public void TearDown()
    {
        ErrorListener.TakeScreenshot();
        _driverManager.CloseWebDriver(_driver);
    }
}