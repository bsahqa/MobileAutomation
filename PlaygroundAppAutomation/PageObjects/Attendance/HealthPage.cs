using MobileAutomation.Tools;
using NSelene;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAutomation.PageObjects.Attendance
{
    class HealthPage : BasePage
    {
        public HealthPage(AppiumDriver<AppiumWebElement> driver) : base(driver) { }

        public SeleneElement HealthBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/room_bottom_nav_health"), MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == \"Health\"`]"));
        public SeleneElement HealthTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Nappies']"), MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == \"Health\"`]"));
        
        // Nappies section elements
        public SeleneElement NappiesIcon => GetPlatformSpecificElement(MobileBy.XPath("//*[@content-desc='Nappies']"), MobileBy.AccessibilityId("SmarListSegment/segment_nappies_icon"));
        public SeleneElement CheckedRecently => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Checked Recently']"), MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == \"btn addition\"`]"));
        public SeleneElement NappiesAddPlusBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnAddAction"), MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == \"btn addition\"`]"));
        public SeleneElement DryButton => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Dry']"), MobileBy.AccessibilityId("Dry"));
        public SeleneElement SaveButton => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvActionConfirmSave"), MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == \"Save\"`]"));
        public SeleneElement NappyDueCheckSuccess => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/snackbar_text"), MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == \"Checked \"`][1]"));
        
        // Sleep section elements
        public SeleneElement SleepTab => GetPlatformSpecificElement(MobileBy.XPath("//*[@content-desc='Sleep']"), MobileBy.AccessibilityId("SmarListSegment/segment_sleep_icon"));
        public SeleneElement AwakeSection => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tv_action_name"), MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == \"Awake\"`][2]"));
        public SeleneElement AwakePlusBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnAddAction"), MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == \"btn addition\"`]"));
        public SeleneElement SleepingBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Sleeping']"), MobileBy.AccessibilityId("Sleeping"));
        public SeleneElement RestingBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Resting']"), MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == \"Resting\"`]"));
        public SeleneElement SleepSaveBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvActionConfirmSave"), MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == \"Save\"`]"));
        public SeleneElement SleepCheckBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Sleep Check']"), MobileBy.AccessibilityId("Sleep Check"));
        public SeleneElement AwakeBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Awake']"), MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == \"Awake\"`]"));
        public SeleneElement RestCheckBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Rest Checked']"), MobileBy.AccessibilityId("Rest Check"));
        public SeleneElement SuccessMessage => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/ivActionIcon"), MobileBy.XPath("//XCUIElementTypeButton[@name = \"btn addition\"]"));

        // Sunscreen section elements
        public SeleneElement SunscreenTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.LinearLayout[@content-desc='Sunscreen']"), MobileBy.AccessibilityId("SmarListSegment/segment_sunscreen_icon"));
        public SeleneElement AddActionBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnAddAction"), MobileBy.AccessibilityId("btn addition"));
        public SeleneElement ApplySunscreen => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvActionConfirmActionName"), MobileBy.AccessibilityId("Apply Sunscreen"));
        public SeleneElement SunscreenSaveButton => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvActionConfirmSave"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Save\"]"));
        public SeleneElement SuccessMsg => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/snackbar_text"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Sunscreen Applied\"]"));
        
        // Nutrition section elements

        public SeleneElement NutritionTab => GetPlatformSpecificElement(MobileBy.XPath("//*[@content-desc='Nutrition']"), MobileBy.AccessibilityId("SmarListSegment/segment_nutrition_icon"));
        public SeleneElement AddPlusActionBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnAddAction"), MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == \"btn addition\"`]"));
        public SeleneElement AppleFood => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Apple']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Apple\"]"));
        public SeleneElement SaveBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvNutritionItemAction"), MobileBy.AccessibilityId("Save"));
        public SeleneElement SuccessIcon => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/ivActionIcon"), MobileBy.AccessibilityId("Image View"));


        // Incident Record section elements
        public SeleneElement MedicalTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.LinearLayout[@content-desc='Medical']"), MobileBy.AccessibilityId("Test"));
        public SeleneElement AddIncidentPlusBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnAddAction"), MobileBy.AccessibilityId("Test"));
        public SeleneElement IncidentRecordBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Incident Record']"), MobileBy.AccessibilityId("Test"));
        public SeleneElement LocationInputField => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/etLocation"), MobileBy.AccessibilityId("Test"));
        public SeleneElement NextBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/bNextButton"), MobileBy.AccessibilityId("Test"));
        public SeleneElement SelectDiseaseType => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvItemInjurySearchName"), MobileBy.AccessibilityId("Test"));
        public SeleneElement TapBodyPart => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/ivInjurySelection"), MobileBy.AccessibilityId("Test"));
        public SeleneElement FrontBodyTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='FRONT']"), MobileBy.AccessibilityId("Test"));
        public SeleneElement IncidentActivityDetails => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvIncidentActivityDetails"), MobileBy.AccessibilityId("Test"));
        public SeleneElement IncidentCause => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvIncidentCause"), MobileBy.AccessibilityId("Test"));
        public SeleneElement IncidentCircumtances => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvIncidentCircumstances"), MobileBy.AccessibilityId("Test"));
        public SeleneElement IncidentTaken => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvIncidentActionsTaken"), MobileBy.AccessibilityId("Test"));
        public SeleneElement IncidentFutureSteps => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvIncidentActionsFutureSteps"), MobileBy.AccessibilityId("Test"));
        public SeleneElement Fullname => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/etName"), MobileBy.AccessibilityId("Test"));
        public SeleneElement Time => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvTime"), MobileBy.AccessibilityId("Test"));
        public SeleneElement TimeOKBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/mdtp_ok"), MobileBy.AccessibilityId("Test"));
        public SeleneElement AddAuthorSignatureBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvItemIncidentSummarySignature"), MobileBy.AccessibilityId("Test"));
        public SeleneElement AddAuthorSignatureAlertOKBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/md_button_positive"), MobileBy.AccessibilityId("Test"));
        public SeleneElement Role => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/txtSignatureRole"), MobileBy.AccessibilityId("Test"));
        public SeleneElement AddSignature => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvSignatureAction"), MobileBy.AccessibilityId("Test"));
        public SeleneElement WriteSignature => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Write your signature']"), MobileBy.AccessibilityId("Test"));
        public SeleneElement SignatureDoneBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/saveSignature"), MobileBy.AccessibilityId("Test"));
        public SeleneElement IncidentSuccessIcon => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/ivActionIcon"), MobileBy.AccessibilityId("Test"));

        public void ClickOnNutritionTab()
        {
            this.ClickElement(NutritionTab);
        }
        public void ClickOnNutriationPlusBtn()
        {
            this.ClickElement(AddPlusActionBtn);
        }

        public void ClickOnAppleFood()
        {
            this.ClickElement(AppleFood);
        }
        public void ClickOnSaveBtn()
        {
            this.ClickElement(SaveBtn);
        }
        public void ValidateNutritionEventCreatedSuccessfully()
        {
            bool isElementDisplayed = this.ValidateElementIsDisplayed(SuccessIcon);
            if (isElementDisplayed)
            {
                Assert.IsTrue(true, "Nutrition event is created successfully");
            }
            else
            {
                Assert.IsTrue(false, "Nutrition is not created.");
            }
        }



        public void ClickOnHealthTab()
        {
            this.ClickElement(HealthBtn);
        }
        public void ClickOnNappiedAddPlusBtn()
        {
            this.ClickElement(NappiesAddPlusBtn);
        }

        public void ClickOnDryButton()
        {
            this.ClickElement(DryButton);
        }

        public void ClickOnSaveButton()
        {
            this.ClickElement(SaveButton);
        }   

        public void ValidateNappyDueCheckSuccess()
        {
            bool isElementDisplayed= this.ValidateElementIsDisplayed(NappyDueCheckSuccess);
            if(isElementDisplayed)
            {
                Assert.IsTrue(true, "Nappy Due Check Success message is displayed");
            }
            else
            {
                Assert.IsTrue(false, "Nappy Due Check Success message is not displayed");
            }
        }

        public void ClickOnSleepTab()
        {
            this.ClickElement(SleepTab);
        }

        public void ClickOnAwakePlusBtn()
        {
            this.ClickElement(AwakePlusBtn);
        }

        public void ClickOnSleepingBtn()
        {
            this.ClickElement(SleepingBtn);
        }

        public void ClickOnRestingBtn()
        {
            this.ClickElement(RestingBtn);
        }

        public void ClickOnSleepSaveBtn()
        {
            this.ClickElement(SleepSaveBtn);
        }

        public void ClickOnSleepCheckBtn()
        {
            this.ClickElement(SleepCheckBtn);
        }

        public void ValidateSleepCheckSuccess()
        {
            bool isElementDisplayed = this.ValidateElementIsDisplayed(SuccessMessage);
            if (isElementDisplayed)
            {
                Assert.IsTrue(true, "Sleep Check Success message is displayed");
            }
            else
            {
                Assert.IsTrue(false, "Sleep Check Success message is not displayed");
            }
        } 
        
        public bool IsAwakeDisplayed()
        {
            return this.ValidateElementIsDisplayed(AwakeBtn);
        }

        public void ClickOnAwakeBtn()
        {
            this.ClickElement(AwakeBtn);
        }

        public void ClickOnSunscreenTab()
        {
            this.ClickElement(SunscreenTab);
        }

        public void ClickOnAddActionBtn()
        {
            this.ClickElement(AddActionBtn);
        }

        public void ClickOnApplySunscreen()
        {
            this.ClickElement(ApplySunscreen);
        }

        public void ClickOnSunscreenSaveButton()
        {
            this.ClickElement(SunscreenSaveButton);
        }

        public void ValidateSunscreenAppliedSuccess()
        {
            this.WaitForElementToBeClickable();
            bool isElementDisplayed = this.ValidateElementIsDisplayed(SuccessMsg);
            if (isElementDisplayed)
            {
                Assert.IsTrue(true, "Sunscreen Applied Success message is displayed");
            }
            else
            {
                Assert.IsTrue(false, "Sunscreen Applied Success message is not displayed");
            }
        }

        public void ClickOnMedicalTab()
        {
            this.ClickElement(MedicalTab);
        }

        public void ClickOnAddIncidentPlusBtn()
        {
            this.ClickElement(AddIncidentPlusBtn);
        }

        public void ClickOnIncidentRecordBtn()
        {
            this.ClickElement(IncidentRecordBtn);
        }

        public void TypeLocation(string location)
        {
            this.EnterText(LocationInputField, location);
        }

        public void ClickOnNextBtn()
        {
            this.ClickElement(NextBtn);
        }

        public void ClickOnSelectDiseaseType()
        {
            this.ClickElement(SelectDiseaseType);
        }

        public void ClickOnTapBodyPart()
        {
           // var imageElement = TapBodyPart;
            // Get the element's location and size
            var location = TapBodyPart.Location;
            var size = TapBodyPart.Size;

            // Calculate the center point of the image
            int centerX = location.X + (size.Width / 2);
            int centerY = location.Y + (size.Height / 2);

            // Perform the tap action at the center of the image
            new TouchAction(MobileDriver.Driver)
                .Tap(centerX, centerY)
                .Perform();
            //this.ClickElement(TapBodyPart);
        }

        public void ClickOnFrontBodyTab()
        {
            this.ClickElement(FrontBodyTab);
        }

        public void TypeIncidentActivityDetails(string activityDetails)
        {
            this.EnterText(IncidentActivityDetails, activityDetails);
        }

        public void TypeIncidentCause(string cause)
        {
            this.EnterText(IncidentCause, cause);
        }

        public void TypeIncidentCircumtances(string circumtances)
        {
            this.EnterText(IncidentCircumtances, circumtances);
        }

        public void TypeIncidentTaken(string incidentTaken)
        {
            this.EnterText(IncidentTaken, incidentTaken);
        }

        public void TypeIncidentFutureSteps(string futureSteps)
        {
            this.EnterText(IncidentFutureSteps, futureSteps);
        }

        public void TypeFullname(string fullname)
        {
            this.EnterText(Fullname, fullname);
        }

        public void ClickOnTime()
        {
            this.ClickElement(Time);
        }

        public void ClickOnTimeOKBtn()
        {
            this.ClickElement(TimeOKBtn);
        }

        public void ClickOnAddAuthorSignatureBtn()
        {
           this.ScrollToElements("Add Author Signature");                  
           this.ClickElement(AddAuthorSignatureBtn);
        }
        public void ClickOnAddAuthorSignatureAlertOKBtn()
        {
            this.ClickElement(AddAuthorSignatureAlertOKBtn);
        }

        public void TypeRole(string role)
        {
            this.EnterText(Role, role);
        }

        public void ClickOnAddSignature()
        {
            this.ClickElement(AddSignature);
        }

        public void AddSignatur()
        {
            this.ClickElement(WriteSignature);
        }

        public void ClickOnSignatureDoneBtn()
        {
            this.ClickElement(SignatureDoneBtn);
        }

        public void ClickOnIncidentSuccessIcon()
        {
            bool isIncidentCreated= this.ValidateElementIsDisplayed(IncidentSuccessIcon);
            if(isIncidentCreated)
            {
                Assert.IsTrue(true, "Incident Record created successfully");
            }
            else
            {
                Assert.IsTrue(false, "Incident Record not created successfully");
            }
        }

    }
}
