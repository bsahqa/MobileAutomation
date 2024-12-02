using NUnit.Framework;
using HomeAppAutomations.Tools;
using OpenQA.Selenium.Appium;
using AventStack.ExtentReports;
using log4net.Config;
using log4net;
using System.IO;

namespace HomeAppAutomations.Tests
{
    [SetUpFixture]
    public abstract class BaseTest
    {
        public AppiumDriver<AppiumWebElement> _driver;
        public ExtentTest _test;

        [OneTimeSetUp]
        protected void SuiteSetup()
        {
            // Setup the Extent Report once before all tests
            ReportsGenerator.SetupExtentReport();
            XmlConfigurator.Configure(new FileInfo(MobileDriver.ProjectDirectory + "/log4net.config"));
        }

        [SetUp]
        protected void Setup()
        {
            MobileDriver.StartDriver(MobileDriver.SingleSessionOptions[MobileDriver.TestingOS]);
            _driver = MobileDriver.Driver;
            _test = ReportsGenerator.InitializeExtentReport();
        }

        [TearDown]
        public void AfterTest()
        {
            if (MobileDriver.IsRemoteRun)
            {
                MobileDriver.SetStatusOnBrowserStack();
            }
            // Do not flush or publish the report after each test
            MobileDriver.DisposeDriver();
        }

        [OneTimeTearDown]
        protected void SuiteTearDown()
        {
            // Flush and publish the Extent Report once after all tests
            ReportsGenerator.PublishExtentReport();
            ReportsGenerator.FlushExtentReport();
            _driver.Quit();
        }
    }
}
