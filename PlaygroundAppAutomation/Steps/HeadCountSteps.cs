using MobileAutomation.PageObjects;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAutomation.Steps
{
    class HeadCountSteps : BaseSteps
    {
        private AppiumDriver<AppiumWebElement> _driver;
        private HeadCountPage headcountPage;
        private EducatorSteps educatorStep;

        /// <summary>
        /// Initializes a new instance of the HomeSteps class.
        /// </summary>
        public HeadCountSteps(AppiumDriver<AppiumWebElement> driver)
        {
            _driver = driver;
            headcountPage = new HeadCountPage(_driver);
            educatorStep= new EducatorSteps(_driver);
        }

        public void CreateNewHeadCount()
        {
            headcountPage.ClickOnNewHeadCountBtn();
            headcountPage.SelectChildren();
            headcountPage.ClickOnSaveBtn();
            headcountPage.ClickOnSubmitBtn();           
        }

        public void CreateHeadCountSignedIn()
        {
            headcountPage.ScrollToElement("Head Count");
            headcountPage.ClickOnHeadcountBtn();
            headcountPage.ClickOnNewHeadCountBtn();
            educatorStep.VerifyEducatorLogin();
            headcountPage.SelectChildren();
            headcountPage.ClickOnSaveBtn();
            headcountPage.ClickOnSubmitBtn();
            headcountPage.ValidateHeadCountCreatedSuccessfully();
        }

        public void ClickBackButton()
        {
            headcountPage.ClickOnBackBtn();
        }
    }
}
