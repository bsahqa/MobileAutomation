using Mailosaur;
using Mailosaur.Models;
using MobileAutomation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using System.Threading.Tasks;

namespace MobileAutomation.Steps
{
    class EmergencyListSteps : BaseSteps
    {
        private AppiumDriver<AppiumWebElement> _driver;
        private EmergencyListPage emergencyListPage;
        private TestData testData;
        
        /// <summary>
        /// Initializes a new instance of the HomeSteps class.
        /// </summary>
        public EmergencyListSteps(AppiumDriver<AppiumWebElement> driver)
        {
            _driver = driver;
            emergencyListPage = new EmergencyListPage(_driver);
        }

        public void CreateEmergencyListAsEvacuationDrill()
        {
            emergencyListPage.ScrollToElement("Head Count");
            emergencyListPage.ClickOnEmergencyListButton();
            emergencyListPage.ClickOnStartEmergency();
            emergencyListPage.ClickOnEvacuationDrill();
            emergencyListPage.ClickOnStartEmergency();
            emergencyListPage.ClickOnAllTab();
            emergencyListPage.ClickOnSafeCheckBox();
            emergencyListPage.ClickOnEndEmergencyBtn();
            emergencyListPage.TypeEducatorName("Babulal");
            if (MobileDriver.IsIOS)
            {
                emergencyListPage.HideiOSKeyboard();
            }
            else
            {
                MobileDriver.Driver.HideKeyboard();
            }
            emergencyListPage.ClickOnSubmitBtn();
            emergencyListPage.ValidateEmergencyListStartedAndEndedSuccessfully();
        }

        public void CreateEmergencyListAsLockdown()
        {
            emergencyListPage.ScrollToElement("Head Count");
            emergencyListPage.ClickOnEmergencyListButton();
            emergencyListPage.ClickOnStartEmergency();
            emergencyListPage.ClickOnLockdownDrill();
            emergencyListPage.ClickOnStartEmergency();
            emergencyListPage.ClickOnAllTab();
            emergencyListPage.ClickOnSafeCheckBox();
            emergencyListPage.ClickOnEndEmergencyBtn();
            emergencyListPage.TypeEducatorName("Babulal");
            if (MobileDriver.IsIOS)
            {
                emergencyListPage.HideiOSKeyboard();
            }
            else
            {
                MobileDriver.Driver.HideKeyboard();
            }
            emergencyListPage.ClickOnSubmitBtn();
            emergencyListPage.ValidateEmergencyListStartedAndEndedSuccessfully();
        }
    }   
}
