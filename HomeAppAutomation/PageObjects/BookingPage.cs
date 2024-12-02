using HomeAppAutomations;
using HomeAppAutomations.PageObjects;
using NSelene;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAppAutomation.PageObjects
{
    class BookingPage : BasePage
    {
        public BookingPage(AppiumDriver<AppiumWebElement> driver) : base(driver)
        { }
        public SeleneElement BookingsTab => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/menuItemBookings"), MobileBy.AccessibilityId("Bookings"));
        public SeleneElement NewBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/btnCreateNewBooking"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"New\"]"));
        public SeleneElement NewPopup => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvSheetTitle"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"New\"])[2]"));
        public SeleneElement NewBooking => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/menuItemBooking"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Booking\"]"));
        public SeleneElement AbsenseHoliday => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/menuItemHoliday"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Absence or Holiday\"]"));
        public SeleneElement RequestSpace => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tv1"), MobileBy.AccessibilityId("Request a space"));
        public SeleneElement AbsenceBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/btnAbsence"), MobileBy.AccessibilityId("Absence"));
        public SeleneElement AbsenceConfirmationLbl=> GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvBookingCardTitle"), MobileBy.AccessibilityId("Absence"));
        public SeleneElement HolidayConfirmationLbl => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvBookingCardTitle"), MobileBy.AccessibilityId("Holiday"));
        public SeleneElement HolidayBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/btnHoliday"), MobileBy.AccessibilityId("Holiday"));
        public SeleneElement RequestBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/btnFooterSend"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Request\"]"));
        public SeleneElement StartTimee => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.EditText[@text='Start']"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"Start\"])[2]"));
        public SeleneElement EndTime => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.EditText[@text='End']"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"End\"])[2]"));
        public SeleneElement OKBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/mdtp_ok"), MobileBy.AccessibilityId("OK"));
        public SeleneElement AnyTimeRadioBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/cbAllDayAnyTime"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Any time/ All day\"]"));
        public SeleneElement SaveBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/btnFooterSend"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Save\"]"));
        public SeleneElement SpaceRequested => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvItemSuggestionRoom"), MobileBy.AccessibilityId("Request space"));
        public SeleneElement MyCartIcon => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/ivMenuBookingSuggestions"), MobileBy.XPath("//XCUIElementTypeNavigationBar[@name=\"Select Bookings\"]/XCUIElementTypeButton[2]"));
        public SeleneElement BookingConfirmedLbl => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvBookingReceiptTitle"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Confirmed\"]"));
       
        // New Booking Object
        public SeleneElement BookingBtn=> GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/menuItemBooking"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='Booking']"));
        //public SeleneElement CancellationBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/menuItemHoliday"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='Cancellation']"));
        public SeleneElement NewBookingLbl => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvTitle"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='New Booking']"));
        public SeleneElement BookingTitle => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvSheetTitle"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='Booking']"));
        public SeleneElement SelectChild => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Select child']"), MobileBy.AccessibilityId("Select Child"));
        public SeleneElement SelectSession => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Select session']"), MobileBy.AccessibilityId("Select session"));
        public SeleneElement SelectRoom => GetPlatformSpecificElement(MobileBy.Id("Select Room"), MobileBy.AccessibilityId("Select Room"));
        public SeleneElement Children => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvChildSelectionItemTitle"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='Rahul Tiwari']"));
        public SeleneElement Session => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Default Fee']"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name='Default Fee'])[1]"));
        public SeleneElement Casual => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/rbCheck"), MobileBy.XPath("(//XCUIElementTypeImage[@name=\"radio-unchecked\"])[1]"));
        public SeleneElement Recuring => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.widget.RadioButton"), MobileBy.XPath("(//XCUIElementTypeImage[@name='radio-unchecked'])[2]"));
        public SeleneElement SelectDate => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Select date(s)']"), MobileBy.AccessibilityId("Select date(s)"));
        //public SeleneElement Date => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.CheckedTextView[@text='17']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='17']"));
        public SeleneElement SaveDateBtn=> GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/btnFooterSend"), MobileBy.XPath("//XCUIElementTypeButton[@name='Save']"));
        public SeleneElement ReviewBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/btnFooterSend"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='Review']"));
        public SeleneElement ReviwBooking => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvTitle"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='Review Booking']"));
        public SeleneElement ConfirmBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/btnFooterSend"), MobileBy.XPath("//XCUIElementTypeButton[@name='Confirm']"));
        public SeleneElement ConfirmBooking => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvTitle"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='Booking confirmed']"));
        public SeleneElement StartDate => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvPlaceHolder"), MobileBy.XPath("//XCUIElementTypeTable/XCUIElementTypeOther[1]/XCUIElementTypeOther[1]/XCUIElementTypeOther/XCUIElementTypeOther"));
        public SeleneElement DateOKBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/mdtp_ok"), MobileBy.AccessibilityId("Done"));
        public SeleneElement AllDayCheckbox => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/cbCheck"), MobileBy.AccessibilityId("All days"));
        public SeleneElement EndDate => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.ScrollView/android.view.ViewGroup/android.widget.LinearLayout[2]/android.widget.LinearLayout/android.view.ViewGroup/android.widget.TextView"), MobileBy.XPath("//XCUIElementTypeTable/XCUIElementTypeOther[1]/XCUIElementTypeOther[2]/XCUIElementTypeOther/XCUIElementTypeOther"));

        // Cancel booking
        public SeleneElement CancellationBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/menuItemHoliday"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='Cancellation']"));
        public SeleneElement CancelStartDate => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.ScrollView/android.view.ViewGroup/android.widget.LinearLayout[2]/android.widget.LinearLayout/android.view.ViewGroup/android.widget.TextView"), MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == \"Date\"`][1]"));
        public SeleneElement CancelEndDate => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.ScrollView/android.view.ViewGroup/android.widget.LinearLayout[3]/android.widget.LinearLayout/android.view.ViewGroup/android.widget.TextView"), MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == \"Date\"`]"));
        public SeleneElement SelectSessions => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Select session(s)']"), MobileBy.AccessibilityId("Select session(s)"));
        public SeleneElement ChildName => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tlItemTitleMain"), MobileBy.AccessibilityId("Test Room"));
        public SeleneElement CancelBooking => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/btnBookingCancelations"), MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == \"Cancel booking\"`]"));
        public SeleneElement ReviewCancel => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvBookingCardTitle"), MobileBy.AccessibilityId("Cancel"));
        public SeleneElement CancelConfirmLbl => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvBookingCardTitle"), MobileBy.AccessibilityId("Cancelled"));
       
        public void ClickOnChildName()
        {
            this.WaitForElementToBeClickable();
            this.ClickElement(ChildName);
        }
        public void ClickOnCancelBooking()
        {
            this.ClickElement(CancelBooking);
        }
        public void ClickOnReviewCancel()
        {
            this.ClickElement(ReviewCancel);
        }

        public void ValidateCancelBookingPopupDisplayed()
        {
            this.WaitForElementToBeClickable();
            bool isCancelPopupVisible = IsElementDisplayed(CancelConfirmLbl);
            if (isCancelPopupVisible)
            {
                Assert.IsTrue(true, "Booking is cancelled");
            }
            else
            {
                Assert.IsTrue(false, "Booking is not cancelled");
            }
        }


        public void ClickOnCancelStartDate()
        {
            this.WaitForElementToBeClickable();
            this.ClickElement(CancelStartDate);
            this.ClickElement(DateOKBtn);
        }

        public void ClickOnCancelEndDate()
        {
            this.WaitForElementToBeClickable();
            this.ClickElement(CancelEndDate);
            this.ClickElement(DateOKBtn);
        }


        public void SelectStartDate()
        {
            this.WaitForElementToBeClickable();
            this.ClickElement(StartDate);
            this.ClickElement(DateOKBtn);
        }

        public void SelectEndDate()
        {
            this.WaitForElementToBeClickable();
            this.ClickElement(EndDate);
            this.ClickElement(DateOKBtn);
        }

        public void SelectAllDays()
        {
            this.ClickElement(AllDayCheckbox);
        }
        public SeleneElement Date
        {
            get
            {
                // Get today's day as a string
                string todayDate = DateTime.Now.Day.ToString();

                // Use today's date in the XPath for both Android and iOS
                return GetPlatformSpecificElement(
                    MobileBy.XPath($"(//android.widget.CheckedTextView[@content-desc='{todayDate}'])[2]"),
                    MobileBy.IosClassChain($"**/XCUIElementTypeStaticText[`label == '{todayDate}'`][2]")
                );
            }
        }

        public void ClickOnBookingBtn()
        {
            this.ClickElement(BookingBtn);
        }
        public void ClickOnCancellationBtn()
        {
            this.ClickElement(CancellationBtn);
        }
        public void ClickOnSelectChild()
        {
            this.WaitForElementToBeClickable();
            this.ClickElement(SelectChild);
        }
        public void ClickOnChildren()
        {
            this.ClickElement(Children);
        }
        public void ClickOnSelectSession()
        {
            this.ClickElement(SelectSession);
        }

        public void SelectAvailableSessions()
        {
            this.ClickElement(SelectSessions);
        }

        public void ClickOnSession()
        {
            this.WaitForElementToBeClickable();
            this.ClickElement(Session);
        }
        public void ClickOnSelectRoom()
        {
            this.WaitForElementToBeClickable();
            this.ClickElement(SelectRoom);
        }
        public void ClickOnCasual()
        {
            this.WaitForElementToBeClickable();
            this.ClickElement(Casual);
        }
        public void ClickOnRecurring()
        {
            this.WaitForElementToBeClickable();
            this.ClickElement(Recuring);
        }
        public void ClickOnSelectDate()
        {
            this.WaitForElementToBeClickable();
            this.ClickElement(SelectDate);
        }
        public void ClickOnDate()
        {
            this.WaitForObjectToBeVisible(Date);
            this.ClickElement(Date);
        }
        public void ClickOnSaveDateBtn()
        {
            this.WaitForElementToBeClickable();
            this.ClickElement(SaveDateBtn);
        }
        public void ClickOnReviewBtn()
        {
            this.ScrollDownHalfScreen();
            this.WaitForElementToBeClickable();
            this.ClickElement(ReviewBtn);
        }
        public void ClickOnConfirmBtn()
        {
            this.WaitForElementToBeClickable();
            if (MobileDriver.IsAndroid)
            {
                this.ScrollDownHalfScreen();
            }            
            this.ClickElement(ConfirmBtn);
        }
        public void ValidateNewBookingPopupDisplayed()
        {
            this.WaitForElementToBeClickable();
            bool isNewPopupVisible = IsElementDisplayed(ConfirmBooking);
            if (isNewPopupVisible)
            {
                Assert.IsTrue(true, "Booking is confirmed");
            }
            else
            {
                Assert.IsTrue(false, "Booking is not confirmed");
            }
        }        


        public void ValidateChildrenIsMarkedAsAbsent()
        {
            this.WaitForElementToBeClickable();
            string actualAbsenceConfirmationLbl = GetElementText(AbsenceConfirmationLbl);
            string expectedAbsenceConfirmationLbl = "Absence";
            Assert.AreEqual(expectedAbsenceConfirmationLbl, actualAbsenceConfirmationLbl, "Absence is not confirmed");
        }
        public void ValidateChildrenIsMarkedAsHoliday()
        {
            this.WaitForElementToBeClickable();
            string actualHolidayConfirmationLbl = GetElementText(HolidayConfirmationLbl);
            string expectedHolidayConfirmationLbl = "Holiday";
            Assert.AreEqual(expectedHolidayConfirmationLbl, actualHolidayConfirmationLbl, "Holiday is not confirmed");
        }

        public void ClickOnAnyTimeRadioBtn()
        {
            this.ClickElement(AnyTimeRadioBtn);
        }
        public void ClickOnSaveBtn()
        {
            this.ClickElement(SaveBtn);
        }

        public void ValidateSpaceRequestedDisplayed()
        {
            this.WaitForElementToBeClickable();
            bool isSpaceRequestedVisible = IsElementDisplayed(SpaceRequested);
            if (isSpaceRequestedVisible)
            {
                Assert.IsTrue(true,"Space Requested is visible");
            }
            else
            {
                Assert.IsTrue(false, "Space Requested is not visible");
            }
        }
        public void ClickOnMyCartIcon() {
            this.ClickElement(MyCartIcon);
        }
        public void ValidateBookingIsConfirmed()
        {
            string actualBookingConfirmedLbl = GetElementText(BookingConfirmedLbl);
            string expectedBookingConfirmedLbl = "Confirmed";
            Assert.AreEqual(expectedBookingConfirmedLbl, actualBookingConfirmedLbl, "Booking is not confirmed");
        }
        public void ClickOnStartTime()
        {
            this.ClickElement(StartTimee);
        }
        public void ClickOnEndTime()
        {
            this.ClickElement(EndTime);
        }
        public void ClickOnOKBtn()
        {
            this.ClickElement(OKBtn);
        }

        public void SelectBookingTime()
        {
            if(MobileDriver.IsAndroid)
            {
                this.ClickOnStartTime();
                this.ClickOnOKBtn();
                this.ClickOnEndTime();
                this.ClickOnOKBtn();
            }           
        }
            
        public void ClickOnBookingsTab()
        {
            this.ClickElement(BookingsTab);
        }

        public void ClickOnNewBtn()
        {
           this.ClickElement(NewBtn);
        }   

        public void ClickOnNewBooking()
        {
            this.ClickElement(NewBooking);            
        }   

        public void ClickOnAbsenseHoliday()
        {
            this.ClickElement(AbsenseHoliday);            
        }

        public void ClickOnRequestSpace()
        {
            this.ClickElement(RequestSpace);            
        }

        public void ClickOnAbsenceBtn()
        {
            this.ClickElement(AbsenceBtn);            
        }

        public void ClickOnHolidayBtn()
        {
            this.ClickElement(HolidayBtn);           
        }   

        public void ClickOnRequestBtn()
        {
            this.ClickElement(RequestBtn);            
        }
    }
}
