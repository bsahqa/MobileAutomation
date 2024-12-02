using MobileAutomation.PageObjects;
using MobileAutomation.Tools;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MobileAutomation.Steps
{
    class IncidentRecordSteps
    {
        private AppiumDriver<AppiumWebElement> _driver;
        private IncidentRecordPage incidentRecordPage;
        private EducatorSteps educatorStep;

        public IncidentRecordSteps(AppiumDriver<AppiumWebElement> driver)
        {
            _driver = driver;
            incidentRecordPage = new IncidentRecordPage(_driver);
            educatorStep = new EducatorSteps(_driver);
        }

        public void ValidateIncidentRecordPageOpen()
        {
            incidentRecordPage.ScrollToElement("Incident Records");
            incidentRecordPage.ClickOnIncidentRecordBtn();
            educatorStep.VerifyEducatorLogin();
            incidentRecordPage.ValidateIncidentRecordPageOpenedSuccessfully();
        }
    }
}
