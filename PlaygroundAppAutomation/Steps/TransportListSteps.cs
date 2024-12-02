using MobileAutomation.PageObjects;
using MobileAutomation.Tools;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MobileAutomation.Steps
{
     class TransportListSteps : BaseSteps
    {
        private AppiumDriver<AppiumWebElement> _driver;
        private TransportListPage transportListPage;
        private EducatorSteps educatorStep;
        private TestData testData;
        private UserContent content;

        public TransportListSteps(AppiumDriver<AppiumWebElement> driver)
        {
            _driver = driver;
            transportListPage = new TransportListPage(_driver);
            educatorStep = new EducatorSteps(_driver);         

        }
        public void ValidateTransportListFunctionality()
		{
            testData = JsonUtil.GetTestData();
            var content = testData.UserContent[0];
            transportListPage.ScrollToTransportList();
            transportListPage.ClickOnTransportListBtn();
            transportListPage.ClickOnNewListBtn();
			transportListPage.TypeListname(content.Name);
			transportListPage.ClickOnDateOfTransport();
			transportListPage.ClickTransportListSaveBtn();
            transportListPage.ClickOnChildrenTab();
            transportListPage.ClickOnAddChild();
            transportListPage.ClickOnChildCheckBox();
            transportListPage.ClickOnAddChildrenBtn();
            transportListPage.ClickOnSaveBtn();
			transportListPage.ClickOnSaveConfirmBtn();
            transportListPage.ClickOnPickCheckbox();
            transportListPage.ClickOnPickupBtn();
            transportListPage.ClickOnEducatorBtn();
			educatorStep.VerifyEducatorLogin();
            transportListPage.ClickOnConfirmationCheckbox();
            transportListPage.ClickOnConfirmPickupBtn();
            transportListPage.ClickOnDropOffCheckbox();
            transportListPage.ClickOnDropOffBtn();
            transportListPage.ClickOnEducatorBtn();
            educatorStep.VerifyEducatorLogin();
            transportListPage.ClickOnConfirmationCheckBox();
            transportListPage.ClickOnDropOffButton();
            transportListPage.ClickOnEndOfTransport();
            transportListPage.ClickOnEducatorBtn();
            educatorStep.VerifyEducatorLogin();
            transportListPage.ClickOnConfirmationCheckBox();
            transportListPage.ClickOnEndOfTransportBtn();
            transportListPage.ValidateChildrenIsDropOffSuccessfully();
            transportListPage.ClickOnEventsTab();
            transportListPage.ClickOnSendReportBtn();
            transportListPage.TypeEmail(content.Email);
            transportListPage.ClickOnSendBtn();
            transportListPage.ValidateTransportListEmailSendSuccessfully();
        }

		public string CurrentDate()
        {
            DateTime currentDate = DateTime.Now;
            string CurrentEndDate = currentDate.ToString("dd MMM yyyy");
            return CurrentEndDate;
        }
    }

   
}
