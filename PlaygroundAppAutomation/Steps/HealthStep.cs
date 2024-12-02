using MobileAutomation.PageObjects;
using MobileAutomation.PageObjects.Attendance;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAutomation.Steps
{
    class HealthStep : BaseSteps
    {
        private AppiumDriver<AppiumWebElement> _driver;
        private HealthPage healthPage;
        private AttendacePage attendancePage;
        private AttendanceStep attendanceStep;
        private TestData testData;
        private UserContent content;
        /// <summary>
        /// Initializes a new instance of the HomeSteps class.
        /// </summary>
        public HealthStep(AppiumDriver<AppiumWebElement> driver)
        {
            _driver = driver;
            healthPage = new HealthPage(_driver);
            attendanceStep = new AttendanceStep(_driver);
        }

        public void CreateDryNappiesEventUnderHealth()
        {
            try
            {
                if (attendanceStep.IsChildrenIsAlreadySignedIn())
                {
                    healthPage.ClickOnHealthTab();
                    healthPage.ClickOnNappiedAddPlusBtn();
                    healthPage.ClickOnDryButton();
                    healthPage.ClickOnSaveButton();
                    healthPage.ValidateNappyDueCheckSuccess();
                }
            }
            catch(TimeoutException)
            {
                attendanceStep.ValidateChildrenSignedIn();
                healthPage.ClickOnHealthTab();
                healthPage.ClickOnNappiedAddPlusBtn();
                healthPage.ClickOnDryButton();
                healthPage.ClickOnSaveButton();
                healthPage.ValidateNappyDueCheckSuccess();
            }
            
        }

        public void CreateNutritionEventWithAppleUnderHealth()
        {
            try
            {
                if (attendanceStep.IsChildrenIsAlreadySignedIn())
                {
                    healthPage.ClickOnHealthTab();
                    healthPage.ClickOnNutritionTab();
                    healthPage.ClickOnNutriationPlusBtn();
                    healthPage.ClickOnAppleFood();
                    healthPage.ClickOnSaveBtn();
                    healthPage.ClickOnNextBtn();
                    healthPage.ClickOnNextBtn();
                    healthPage.ClickOnNextBtn();
                    healthPage.ValidateNutritionEventCreatedSuccessfully();

                }
            }
            catch (TimeoutException)
            {
                attendanceStep.ValidateChildrenSignedIn();
                healthPage.ClickOnHealthTab();
                healthPage.ClickOnNutritionTab();
                healthPage.ClickOnNutriationPlusBtn();
                healthPage.ClickOnAppleFood();
                healthPage.ClickOnSaveBtn();
                healthPage.ClickOnNextBtn();
                healthPage.ClickOnNextBtn();
                healthPage.ClickOnNextBtn();
                healthPage.ValidateNutritionEventCreatedSuccessfully();
            }
        }

        public void ValidateCreateAwakeEventUnderHealth()
        {
            Task.Delay(5000).Wait();
            try
            {
                if (attendanceStep.IsChildrenIsAlreadySignedIn())
                {
                    healthPage.ClickOnHealthTab();
                    healthPage.ClickOnSleepTab();
                    healthPage.ClickOnAwakePlusBtn();
                    if (MobileDriver.IsAndroid)
                    {
                        healthPage.ClickOnSleepingBtn();
                    }
                    else
                    {
                        if (healthPage.IsAwakeDisplayed())
                        {
                            healthPage.ClickOnAwakeBtn();
                        }
                        else
                        {
                            healthPage.ClickOnRestingBtn();
                        }
                    }
                }
            }
            catch(TimeoutException)
            {
                attendanceStep.ValidateChildrenSignedIn();
                healthPage.ClickOnHealthTab();
                healthPage.ClickOnSleepTab();
                healthPage.ClickOnAwakePlusBtn();
                if (MobileDriver.IsAndroid)
                {
                    healthPage.ClickOnSleepingBtn();
                }
                else
                {
                    if (healthPage.IsAwakeDisplayed())
                    {
                        healthPage.ClickOnAwakeBtn();
                    }
                    else
                    {
                        healthPage.ClickOnRestingBtn();
                    }
                }
            }          
            
            healthPage.ClickOnSleepSaveBtn();
            healthPage.ValidateSleepCheckSuccess();
        }

        public void ValidateCreateSunscreenEventUnderHealth()
        {
            try
            {
                if (attendanceStep.IsChildrenIsAlreadySignedIn())
                {
                    healthPage.ClickOnHealthTab();
                    healthPage.ClickOnSunscreenTab();
                    healthPage.ClickOnAddActionBtn();
                    healthPage.ClickOnApplySunscreen();
                    healthPage.ClickOnSunscreenSaveButton();
                    healthPage.ValidateSunscreenAppliedSuccess();
                }
            }
            catch (TimeoutException)
            {
                attendanceStep.ValidateChildrenSignedIn();
                healthPage.ClickOnHealthTab();
                healthPage.ClickOnSunscreenTab();
                healthPage.ClickOnAddActionBtn();
                healthPage.ClickOnApplySunscreen();
                healthPage.ClickOnSunscreenSaveButton();
                healthPage.ValidateSunscreenAppliedSuccess();
            }            
        }        

        public void VerifyIncidentCreate()
        {
            testData = JsonUtil.GetTestData();
            var content = testData.UserContent[0];

            try
            {
                
                healthPage.ClickOnHealthTab();
                healthPage.ClickOnMedicalTab();
                healthPage.ClickOnAddIncidentPlusBtn();
                healthPage.ClickOnIncidentRecordBtn();
                healthPage.TypeLocation(content.Location);
                MobileDriver.Driver.HideKeyboard();
                healthPage.ClickOnNextBtn();
                healthPage.ClickOnSelectDiseaseType();
                healthPage.ClickOnNextBtn();
                healthPage.ClickOnTapBodyPart();
                healthPage.ClickOnFrontBodyTab();
                healthPage.ClickOnTapBodyPart();
                healthPage.ClickOnNextBtn();
                healthPage.TypeIncidentActivityDetails(content.IncidentActivityDrtails);
                healthPage.TypeIncidentCause(content.IncidentCause);
                MobileDriver.Driver.HideKeyboard();
                healthPage.TypeIncidentCircumtances(content.IncidentCircumtance);
                MobileDriver.Driver.HideKeyboard();
                healthPage.ClickOnNextBtn();
                MobileDriver.Driver.HideKeyboard();
                healthPage.TypeIncidentTaken(content.IncidentTaken);
                MobileDriver.Driver.HideKeyboard();
                healthPage.TypeIncidentFutureSteps(content.IncidentFutureSteps);
                MobileDriver.Driver.HideKeyboard();
                healthPage.ClickOnNextBtn();
                MobileDriver.Driver.HideKeyboard();
                healthPage.TypeFullname(content.Fullname);
                MobileDriver.Driver.HideKeyboard();
                healthPage.ClickOnTime();
                healthPage.ClickOnTimeOKBtn();
                healthPage.ClickOnNextBtn();
                healthPage.ClickOnAddAuthorSignatureBtn();
                healthPage.ClickOnAddAuthorSignatureAlertOKBtn();
                healthPage.TypeRole(content.Role);
                MobileDriver.Driver.HideKeyboard();
                healthPage.ClickOnAddSignature();
                healthPage.AddSignatur();
                healthPage.ClickOnSignatureDoneBtn();
                healthPage.ClickOnIncidentSuccessIcon();
            }
            catch(TimeoutException)
            {
                attendanceStep.ValidateChildrenSignedIn();
                healthPage.ClickOnHealthTab();
                healthPage.ClickOnMedicalTab();
                healthPage.ClickOnAddIncidentPlusBtn();
                healthPage.ClickOnIncidentRecordBtn();
                healthPage.TypeLocation(content.Location);
                MobileDriver.Driver.HideKeyboard();
                healthPage.ClickOnNextBtn();
                healthPage.ClickOnSelectDiseaseType();
                healthPage.ClickOnNextBtn();
                healthPage.ClickOnTapBodyPart();
                healthPage.ClickOnFrontBodyTab();
                healthPage.ClickOnTapBodyPart();
                healthPage.ClickOnNextBtn();
                healthPage.TypeIncidentActivityDetails(content.IncidentActivityDrtails);
                healthPage.TypeIncidentCause(content.IncidentCause);
                MobileDriver.Driver.HideKeyboard();
                healthPage.TypeIncidentCircumtances(content.IncidentCircumtance);
                MobileDriver.Driver.HideKeyboard();
                healthPage.ClickOnNextBtn();
                MobileDriver.Driver.HideKeyboard();
                healthPage.TypeIncidentTaken(content.IncidentTaken);
                MobileDriver.Driver.HideKeyboard();
                healthPage.TypeIncidentFutureSteps(content.IncidentFutureSteps);
                MobileDriver.Driver.HideKeyboard();
                healthPage.ClickOnNextBtn();
                MobileDriver.Driver.HideKeyboard();
                healthPage.TypeFullname(content.Fullname);
                MobileDriver.Driver.HideKeyboard();
                healthPage.ClickOnTime();
                healthPage.ClickOnTimeOKBtn();
                healthPage.ClickOnNextBtn();
                healthPage.ClickOnAddAuthorSignatureBtn();
                healthPage.ClickOnAddAuthorSignatureAlertOKBtn();
                healthPage.TypeRole(content.Role);
                MobileDriver.Driver.HideKeyboard();
                healthPage.ClickOnAddSignature();
                healthPage.AddSignatur();
                healthPage.ClickOnSignatureDoneBtn();
                healthPage.ClickOnIncidentSuccessIcon();
            }
           
        }
    }
}
