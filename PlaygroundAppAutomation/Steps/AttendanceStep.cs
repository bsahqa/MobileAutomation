using MobileAutomation.PageObjects;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAutomation.Steps
{
    class AttendanceStep : BaseSteps
    {
        private AppiumDriver<AppiumWebElement> _driver;
        private AttendacePage attendancePage;
        private HeadCountSteps headCountStep;
        private TestData testData;
        private UserContent user;

        /// <summary>
        /// Initializes a new instance of the HomeSteps class.
        /// </summary>
        public AttendanceStep(AppiumDriver<AppiumWebElement> driver)
        {
            _driver = driver;
            attendancePage = new AttendacePage(_driver); 
            headCountStep = new HeadCountSteps(_driver);
        }

        public void ValidateChildrenSignIn()
        {
            this.ValidateChildrenSignedIn();
            this.ValidateChildrenSignedOut();
        }

        public void ValidateChildrenSignedIn()
        {
            try
            {
                Task.Delay(5000).Wait();
                if (this.IsChildrenIsAlreadySignedIn())
                {
                    this.ValidateChildrenSignedOut();
                    attendancePage.WaitForElementToBeClickable();
                    attendancePage.ClickOnSignInPlusBtn();
                    attendancePage.ClickOnSignInBtn();
                    attendancePage.ClickOnConfirmSignInBtn();
                    attendancePage.ValidateChildrenSignedInSuccessfully();
                }
            }
            catch (TimeoutException)
            {
                attendancePage.WaitForElementToBeClickable();
                attendancePage.ClickOnSignInPlusBtn();
                attendancePage.ClickOnSignInBtn();
                attendancePage.ClickOnConfirmSignInBtn();
                attendancePage.ValidateChildrenSignedInSuccessfully();
            }           
        }

        public bool IsChildrenIsAlreadySignedIn()
        {
           return attendancePage.IsChildrenSignedIn;
        }

        public void ValidateChildrenSignedOut()
        {
            attendancePage.WaitForElementToBeClickable();
            if(MobileDriver.IsIOS)
            {
                attendancePage.ClickOnSelectAllBookingBtn();
            }
            else
            {
                attendancePage.ClickOnSignInPlusBtn();
            }            
            attendancePage.WaitForElementToBeClickable();
            attendancePage.ClickOnSignOutBtn();
            attendancePage.ClickOnConfirmSignOutBtn();  
            attendancePage.ValidateChildrenSignedOutSuccessfully();
        }

        public void SignedOutChildren()
        {
            attendancePage.WaitForElementToBeClickable();
            if (MobileDriver.IsIOS)
            {
                attendancePage.ClickOnSelectAllBookingBtn();
            }
            else
            {
                attendancePage.ClickOnSignInPlusBtn();
            }
            attendancePage.WaitForElementToBeClickable();
            attendancePage.ClickOnSignOutBtn();
            attendancePage.ClickOnConfirmSignOutBtn();            
        }

        public void ValidateChildrenAbsence()
        {
            try
            {
                Task.Delay(5000).Wait();
                if (this.IsChildrenIsAlreadySignedIn())
                {
                    this.SignedOutChildren();
                    attendancePage.ScrollDownHalfScreen();
                    attendancePage.ClickOnSignInPlusBtn();
                    attendancePage.ClickOnAbsentBtn();
                    attendancePage.ClickOnMarkAbsentBtn();
                    attendancePage.ValidateChildrenMarkedAsAbsentSuccessfully();
                }
            }
            catch (TimeoutException)
            {
                attendancePage.ScrollDownHalfScreen();
                attendancePage.ClickOnSignInPlusBtn();
                attendancePage.ClickOnAbsentBtn();
                attendancePage.ClickOnMarkAbsentBtn();
                attendancePage.ValidateChildrenMarkedAsAbsentSuccessfully();
            }

        }

        public void ValidateSelectAllAndDeselectAllFunctionality()
        {
            attendancePage.ClickOnSelectAllBookingBtn();
            attendancePage.ValidateDeselectAllIsPresent();
            attendancePage.ClickOnDeselectAllBookingBtn();
            attendancePage.ValidateSelectAllIsPresent();
        }

        public void ValidateSearchChildrenFunctionality()
        {
            Task.Delay(5000).Wait();
            testData = JsonUtil.GetTestData();
            var user = testData.UserContent[0];
            attendancePage.ClickOnSearch();
            attendancePage.EnterSearchText(user.ChildName);
            attendancePage.ValidateSearchResultIsDisplaying(user.ChildName);
        }

        public void ValidateSignedInAndSignedOutFromHeadCount()
        {
            attendancePage.ClickOnHeadCountBtn();
            headCountStep.CreateNewHeadCount();
            headCountStep.ClickBackButton();
            attendancePage.ValidateChildrenSignedInSuccessfully();
            attendancePage.ClickOnSelectAllSignedInBtn();                  
            attendancePage.ClickOnSignOutBtn();
            attendancePage.ClickOnConfirmSignOutBtn();
            attendancePage.ValidateChildrenSignedOutSuccessfully();
        }       
    }
}
