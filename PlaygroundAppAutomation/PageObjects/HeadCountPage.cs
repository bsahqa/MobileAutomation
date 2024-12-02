using MobileAutomation.Tools;
using NSelene;
using NUnit.Framework;
using OpenQA.Selenium.Appium;


namespace MobileAutomation.PageObjects
{
     class HeadCountPage:BasePage
     {
        public HeadCountPage(AppiumDriver<AppiumWebElement> driver) : base(driver) { }
        public SeleneElement HeadcountButton => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Head Count']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Head Count\"]"));
        public SeleneElement HeadBackBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/ivListBack"), MobileBy.AccessibilityId("Head Count"));
        public SeleneElement HeadCountLabel => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvListTitle"), MobileBy.AccessibilityId("Head Count"));
        public SeleneElement HeadCountSearch => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/ivListSearch"), MobileBy.AccessibilityId("Search"));
        public SeleneElement ChildName => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvItemEventListChildName"), MobileBy.AccessibilityId("Babulal Sah Child8"));
        public SeleneElement SearchInput => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/txtListSearch"), MobileBy.AccessibilityId("Search Children"));
        public SeleneElement AllRoom => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvListRoomSelector"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"All Rooms\"]"));
        public SeleneElement AutomationRoomFilter => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvListRoomSelector"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Automation Room\"]"));
        public SeleneElement SelectRoomPopup => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/md_text_title"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Rooms\"]"));
        public SeleneElement RoomRadioBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/md_title"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"checkmark\"]"));
        public SeleneElement AutomationRoom => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Automation Room']"), MobileBy.AccessibilityId("Automation Room"));
        public SeleneElement AllRoomLbl => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='All Rooms']"), MobileBy.AccessibilityId("All Rooms"));
        public SeleneElement RoomOKBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/md_button_positive"), MobileBy.AccessibilityId("Done"));
        public SeleneElement RoomCancelBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/md_button_negative"), MobileBy.AccessibilityId("Cancel"));
        public SeleneElement NewHeadCountBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvActivateEvent"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"New Head Count\"]"));
        public SeleneElement EducatorLogin => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvSigninLocalEducatorTitle"), MobileBy.AccessibilityId("Choose your profile"));
        public SeleneElement SkipBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvSignInLocalEducatorsCancel"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Skip\"]"));
        public SeleneElement CheckBoxBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/switchEventListObserved"), MobileBy.XPath("(//XCUIElementTypeButton)[5]"));
        public SeleneElement BackBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/ivListBack"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Head Count\"]"));
        public SeleneElement DiscardBtn => GetPlatformSpecificElement(MobileBy.Id("android:id/button1"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"CHANGE ROOM\"]"));
        public SeleneElement ExistingEducator => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvSigninLocalEducatorName"), MobileBy.AccessibilityId("Babulal Shah"));
        public SeleneElement Pin7 => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvPin7"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"7 PQRS\"]"));
        public SeleneElement Pin3 => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvPin3"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"3 DEF\"]"));
        public SeleneElement Pin9 => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvPin9"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"9 WXYZ\"]"));
        public SeleneElement Pin0 => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvPin0"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"0  \"]"));
        public SeleneElement CancelEduLoginBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvSignInDialogFooterLeftAction"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Cancel\"]"));
        public SeleneElement CancelNewEduLoginBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvSignInNewEducatorCancel"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Cancel\"]"));
        public SeleneElement ContinueBtn => GetPlatformSpecificElement(MobileBy.Id("android:id/button2"), MobileBy.AccessibilityId("Continue"));
        public SeleneElement NewEventScreen => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvActionConfirmTitle"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"by Babulal Shah\"]"));
        public SeleneElement CloseNewEvent => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/ivActionConfirmClose"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Cancel\"]"));
        public SeleneElement NewEventSaveBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/submitBtn"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Save\"]"));
        public SeleneElement ChildProfilePhoto => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/ivActionConfirmChildProfilePic"), MobileBy.XPath("//XCUIElementTypeImage[@name=\"BS\"]"));
        public SeleneElement ChildFullName => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvActionConfirmChildName"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Babulal Sah Child3\"]"));
        public SeleneElement NewEventTime => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvActionConfirmTime"), MobileBy.XPath("//XCUIElementTypeApplication[@name=\"Playground\"]/XCUIElementTypeWindow[1]/XCUIElementTypeOther/XCUIElementTypeOther[2]/XCUIElementTypeOther/XCUIElementTypeTable/XCUIElementTypeCell[1]/XCUIElementTypeTextField"));
        public SeleneElement Signin=> GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvActionConfirmActionName"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Sign In\"]"));
        public SeleneElement EducatorName => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvActionConfirmEducatorLabel"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"by Babulal Shah\"]"));
        public SeleneElement PublicNotes => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/txtActionConfirmNotes"), MobileBy.AccessibilityId("event-notes"));
        public SeleneElement ChildSignedIn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvItemEventStatus"), MobileBy.AccessibilityId("Signed In"));
        public SeleneElement ChildBackBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/ivEvacDetailsBack"), MobileBy.AccessibilityId("green back arrow"));
        public SeleneElement Email => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvMail"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"EMAIL\"]"));
        public SeleneElement GmailApp => GetPlatformSpecificElement(MobileBy.Id("com.google.android.gm:id/welcome_tour_title"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"EMAIL\"]"));
        public SeleneElement Counted_0 => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvProgress"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"0\"]"));
        public SeleneElement Counted_1 => GetElementByXPath("//XCUIElementTypeStaticText[@name=\"1\"]");
        public SeleneElement SubmitBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/submitBtn"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Submit\"]"));
        public SeleneElement ChildDetail => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEvaDetailsChildName"), MobileBy.AccessibilityId("Babulal Sah Child8"));
        public SeleneElement SaveBtn=> GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvActionConfirmSave"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Save\"]"));
        public void ClickOnHeadcountBtn()
        {
            this.ClickElement(HeadcountButton);
        }
        public void ClickOnNewHeadCountBtn()
        {
           this.ClickElement(NewHeadCountBtn);
        }

        public void SelectChildren()
        {
            this.WaitForElementToBeVisible(CheckBoxBtn);
            this.ClickElement(CheckBoxBtn);
        }

        public void ClickOnSaveBtn()
        {
            this.ClickElement(SaveBtn);
        }
        public void ClickOnSubmitBtn()
        {
            this.ClickElement(SubmitBtn);
        }

        public void ClickOnBackBtn()
        {
            this.WaitForElementToBeVisible(BackBtn);
            this.ClickElement(BackBtn);
        }

        public void ClickOnContinueBtn()
        {
            this.ClickElement(ContinueBtn);
        }

        public void ValidateHeadCountCreatedSuccessfully()
        {
            this.WaitForElementToBeClickable();
            string actualTxt = GetElementText(ChildSignedIn);
            string expectedTxt = "Signed In";
            Assert.AreEqual(expectedTxt, actualTxt);
        }
        
     }
}
