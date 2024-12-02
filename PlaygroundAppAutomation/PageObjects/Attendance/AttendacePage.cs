using MobileAutomation.Tools;
using NSelene;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using System;
using System.Threading.Tasks;


namespace MobileAutomation.PageObjects
{
    class AttendacePage:BasePage
    {
        public AttendacePage(AppiumDriver<AppiumWebElement> driver) : base(driver) { }
        public SeleneElement AttendButton => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/room_bottom_nav_attendance"), MobileBy.AccessibilityId("Attendance"));
        public SeleneElement NoOfBookings => GetPlatformSpecificElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"10 Children Today\")"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"10 Children Today\"])[2]"));
        public SeleneElement NoOfSignedIn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='00']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='00']"));
        public SeleneElement NoOfChildSignedIn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='0']"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"0\"])[2]"));
        public SeleneElement NoOfRequiredEducator => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='2']"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"2\"])[2]"));
        public SeleneElement SignInPlusBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnAddAction"), MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == \"btn addition\"`][1]"));
        public SeleneElement AbsentBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Absent']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Absent\"]"));
        public SeleneElement SignInBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Sign In']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Sign In\"]"));
        public SeleneElement SelectAllBookingBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tbSubSectionAction"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Select All\"]"));
        public SeleneElement SelectAllSignedInBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tbSubSectionAction"), MobileBy.XPath("(//XCUIElementTypeButton[@name=\"Select All\"])[1]"));
        public SeleneElement DeselectAllBookingBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tbSubSectionAction"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Deselect All\"]"));
        public SeleneElement ConfirmSignInBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/bNextButton"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Sign In\"]"));
        public SeleneElement SignInConfirmation => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Signed In']"), MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == \"Signed In\"`]"));
        public SeleneElement SignOutBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Sign Out']"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Sign Out\"]"));
        public SeleneElement ConfirmSignOutBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/bNextButton"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Sign Out\"]"));
        public SeleneElement NoOfChildSelected => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='1 Child Selected']"), MobileBy.AccessibilityId("1 Child Selected"));
        public SeleneElement MarkAbsentBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/bNextButton"), MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == \"Mark Absent\"`]"));
        public SeleneElement OtherBooking => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Other']"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"Others\"])[2]"));
        public SeleneElement ExpandAndUnexpandBookingArrow => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/ivExpandSection"), MobileBy.IosClassChain("**/XCUIElementTypeOther[`name == \"AUTOMATION ROOM\"`]"));
        public SeleneElement TimePickerHours => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/mdtp_hours"), MobileBy.AccessibilityId("Hours"));
        public SeleneElement TimePickerMinute => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/mdtp_minutes"), MobileBy.AccessibilityId("Minutes"));
        public SeleneElement TimePickerAM => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/mdtp_am_label"), MobileBy.AccessibilityId("AM"));
        public SeleneElement TimePickerPM => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/mdtp_pm_label"), MobileBy.AccessibilityId("PM"));
        public SeleneElement TimePickerWatchArea => GetPlatformSpecificElement(MobileBy.ClassName("android.view.View"), MobileBy.AccessibilityId("WatchArea"));
        public SeleneElement TimePickerOKBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/mdtp_ok"), MobileBy.AccessibilityId("OK"));
        public SeleneElement TimeField => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvDatePickerDateDisplay"), MobileBy.AccessibilityId("Time"));
        public SeleneElement Children => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/llChildActionList"), MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == \"Babulal\"`][1]"));
        public SeleneElement TimeLineAddEventBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnTimelineAddEvent"), MobileBy.AccessibilityId("Sign In"));
        public SeleneElement SigningInBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvActionConfirmActionName"), MobileBy.AccessibilityId("Sign In"));
        public SeleneElement SaveBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvActionConfirmSave"), MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == \"Save\"`]"));
        public SeleneElement SignInConfirmLLabel => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Signed In']"), MobileBy.AccessibilityId("Signed In"));
        public SeleneElement SignedOutBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnTimelineAddEvent"), MobileBy.AccessibilityId("Sign Out"));
        public SeleneElement SignedOutConfirmLLabel => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Signed Out']"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"Signed Out\"])[2]"));
        public SeleneElement BookedInLabel => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Booked In']"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"Booked In\"])[2]"));
        public SeleneElement SearchBtn=> GetPlatformSpecificElement(MobileBy.Id("android:id/search_button"), MobileBy.AccessibilityId("Search"));
        public SeleneElement SearchInputField => GetPlatformSpecificElement(MobileBy.Id("android:id/search_src_text"), MobileBy.AccessibilityId("Search All Children"));
        string childname= JsonUtil.GetTestData().UserContent[0].ChildName;
        public SeleneElement SearchResult => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvFooterTitle"), MobileBy.XPath($"(//XCUIElementTypeStaticText[@name=\"{childname}\"])[1]"));
        public SeleneElement HeadCountBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btn_start_head_count"), MobileBy.XPath("(//XCUIElementTypeButton[@name=\"Head Count\"])[2]"));
        
        public void ClickOnHeadCountBtn()
        {
            this.ClickElement(HeadCountBtn);
        }
        public void ClickOnSearch()
        {
           this.ClickElement(SearchBtn);
        }

        public void EnterSearchText(string searchText)
        {
            this.EnterText(SearchInputField, searchText);
        }

        public void ValidateSearchResultIsDisplaying(string expectedChildName)
        {
            string actualSearchResult = GetElementText(SearchResult);
            string actualChildName = actualSearchResult.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)[0];
            Assert.AreEqual(expectedChildName, actualChildName);
        }

        public void ClickOnAttendanceBtn()
        {
            this.ClickElement(AttendButton);
        }
        public void ScrollToSignInPlusBtn()
        {
            this.ScrollDownHalfScreen();
        }

        public void ClickOnSignInPlusBtn()
        {
            this.ClickElement(SignInPlusBtn);
        }

        public void ClickOnAbsentBtn()
        {
            this.ClickElement(AbsentBtn);
        }

        public void ClickOnSignInBtn()
        {
            this.ClickElement(SignInBtn);
        }

        public void ClickOnSelectAllBookingBtn()
        {
            this.ClickElement(SelectAllBookingBtn);
        }

        public void ClickOnSelectAllSignedInBtn()
        {
            this.ClickElement(SelectAllSignedInBtn);
        }

        public void ClickOnDeselectAllBookingBtn()
        {
            this.ClickElement(DeselectAllBookingBtn);
        }

        public void ValidateSelectAllIsPresent()
        {
            string actualSelectAllLbl=GetElementText(SelectAllBookingBtn);
            if(MobileDriver.IsAndroid)
            {
                Assert.AreEqual("Select all", actualSelectAllLbl);
            }
            else
            {
                Assert.AreEqual("Select All", actualSelectAllLbl);
            }            
        }

        public void ValidateDeselectAllIsPresent()
        {
            string actualDeselectAllLbl = GetElementText(DeselectAllBookingBtn);
            if (MobileDriver.IsAndroid)
            {
                Assert.AreEqual("Deselect all", actualDeselectAllLbl);
            }
            else
            {
                Assert.AreEqual("Deselect All", actualDeselectAllLbl);
            }            
        }

        public void ClickOnConfirmSignInBtn()
        {
            this.ClickElement(ConfirmSignInBtn);
        }

        public void ClickOnSignOutBtn()
        {
            this.ClickElement(SignOutBtn);
        }

        public void ClickOnConfirmSignOutBtn()
        {
            this.ClickElement(ConfirmSignOutBtn);
        }

        public void ClickOnMarkAbsentBtn()
        {
            this.ClickElement(MarkAbsentBtn);
        }

        public void ClickOnOtherBooking()
        {
            this.ClickElement(OtherBooking);
        }

        public void ClickOnExpandAndUnexpandBookingArrow()
        {
            this.ClickElement(ExpandAndUnexpandBookingArrow);
        }

        public void ValidateChildrenSignedInSuccessfully()
        {
            string actualSignedIn = GetElementText(SignInConfirmation);
            Assert.AreEqual("Signed In", actualSignedIn);
        }

        public bool IsChildrenSignedIn => SignInConfirmation.Enabled;
        public void ValidateChildrenSignedOutSuccessfully()
        {
            string actualSignedOut = GetElementText(BookedInLabel);
            Assert.AreEqual("Booked In", actualSignedOut);
        }

        public void ValidateChildrenMarkedAsAbsentSuccessfully()
        {
            string actualSignedOut = GetElementText(BookedInLabel);
            Assert.AreEqual("Booked In", actualSignedOut);
        }

        public bool IsAbsentBtnDisplayed => AbsentBtn.Displayed;
        public bool IsSignInBtnDisplayed=>SignInBtn.Displayed;
        public bool IsOtherBookingDisplayed => OtherBooking.Displayed;
        public bool IsSignInConfirmLabelDisplayed => SignInConfirmLLabel.Displayed;
        public bool IsSignedOutConfirmLabelDisplayed => SignedOutConfirmLLabel.Displayed;
	

	}
	public class AttendanceStrings
	{
		#region Strings
		public AttendanceStrings() { }

		public const string NumberOfRequiredEducator = "2";
        public const string NumberOfBookings = "10";


		#endregion

	}
}
