using MobileAutomation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using System;

namespace MobileAutomation.Steps
{
    class HomeSteps : BaseSteps
    {
        private AppiumDriver<AppiumWebElement> _driver;
        private HomePage homePage;

        /// <summary>
        /// Initializes a new instance of the HomeSteps class.
        /// </summary>
        public HomeSteps(AppiumDriver<AppiumWebElement> driver)
        {
            _driver = driver;
            homePage = new HomePage(_driver);
        }

        /// <summary>
        /// Validate all button is available on HomePage
        /// </summary>
        public void ValidateAllButtonIsPresentOnHomePage()
        {
            homePage.ServiceNameIsDisplayed();
            homePage.RoomLblIsDisplayed();
            homePage.RoomNameIsDisplayed();
            //homePage.MessengerIsDisplayed();
            //homePage.TransportListIsDisplayed();
            homePage.HeadcountIsDisplayed();
            homePage.IncidentIsDisplayed();
            homePage.EmergencyListIsDisplayed();
            homePage.HelpAndSupportIsDisplayed();
        }

        /// <summary>
        /// Verifies if the Dashboard is displayed.
        /// </summary>
        public void VerifyDashboardDisplayed()
        {
            if (homePage.IsDahboardDisplayed)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

    }
}
