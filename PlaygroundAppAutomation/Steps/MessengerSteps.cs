using MobileAutomation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using System.Security.Permissions;
using System.Threading;

namespace MobileAutomation.Steps
{
     class MessengerSteps:BaseSteps
    {
        private AppiumDriver<AppiumWebElement> _driver;
        private MessengerPage messengerPage;
        private EducatorSteps educatorStep;

        public MessengerSteps(AppiumDriver<AppiumWebElement> driver)
        {
            _driver = driver;
            messengerPage = new MessengerPage(_driver);
            educatorStep = new EducatorSteps(_driver);
        }  
        
        public void ValidateMessengerFunctionality()
        {
            messengerPage.ClickOnMessengerBtn();
            educatorStep.VerifyEducatorLogin();
            messengerPage.ValidateMessengerPageOpened();
        }
    }
}
