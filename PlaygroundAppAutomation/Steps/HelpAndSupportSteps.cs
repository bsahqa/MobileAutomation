using MobileAutomation.PageObjects;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAutomation.Steps
{
    class HelpAndSupportSteps
    {
        private AppiumDriver<AppiumWebElement> _driver;
        private HelpSupportPage HelpAndSupportPage;

        /// <summary>
        /// Initializes a new instance of the HelpAndSupportSteps class.
        /// </summary>
        public HelpAndSupportSteps(AppiumDriver<AppiumWebElement> driver)
        {
            _driver = driver;
            HelpAndSupportPage = new HelpSupportPage(_driver);
        }

        public void ValidateHelpAndSupportPageOpened()
        {
            HelpAndSupportPage.ScrollToElement("Office");
            HelpAndSupportPage.ClickOnHelpAndSupportBtn();
            HelpAndSupportPage.WaitForElementToBeClickable();
            HelpAndSupportPage.ValidateHelpAndSupportPageOpenedSuccessfully();
        }
    }
}
