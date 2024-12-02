using MobileAutomation.Tools;
using NSelene;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using System;
using System.Threading.Tasks;


namespace MobileAutomation.PageObjects
{
     class TransportListPage:BasePage
    {
        public TransportListPage(AppiumDriver<AppiumWebElement> driver) : base(driver) { }
        public SeleneElement TransportButton => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Transport Lists']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Transport List\"]"));
        public SeleneElement TransportListTitle => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Transport List']"), MobileBy.AccessibilityId("Transport List"));
        public SeleneElement NewListBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvActivateEvent"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"New List\"]"));
        public SeleneElement BackButton => GetPlatformSpecificElement(MobileBy.AccessibilityId("Navigate up"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Transport List\"]"));
       // public SeleneElement BackBtn => GetElementByAcccessibilityId("orange back arrow");
        public SeleneElement CalendarDate => GetPlatformSpecificElement(MobileBy.XPath($"//android.widget.CheckedTextView[@content-desc=\"{getDate()}\"]"), MobileBy.AccessibilityId(getDate()));
        public SeleneElement PastDate => GetPlatformSpecificElement(MobileBy.XPath($"//android.widget.CheckedTextView[@content-desc=\"{pastDate()}\"]"), MobileBy.AccessibilityId($"{pastDate()}"));
        public SeleneElement TransportDetail => GetPlatformSpecificElement(MobileBy.AccessibilityId("Transport Details"), MobileBy.AccessibilityId("Details"));
        public SeleneElement ChildAttending => GetPlatformSpecificElement(MobileBy.AccessibilityId("Children Attending"), MobileBy.AccessibilityId("Children"));
        public SeleneElement EventTimeline => GetPlatformSpecificElement(MobileBy.AccessibilityId("Event Timeline"), MobileBy.AccessibilityId("Events"));
        public SeleneElement DateOfTransport => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tpDateOfTransport"), MobileBy.AccessibilityId("Date of Transport"));
        public SeleneElement ListName => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/txtBorderedEditText"), MobileBy.AccessibilityId("List Name"));
        public SeleneElement TransportSaveBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnSaveTransportDetails"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Save\"]"));
        public SeleneElement TripTitle => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvTripTitle"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Morning\"]"));
        public SeleneElement PickUpFrom => GetPlatformSpecificElement(MobileBy.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/androidx.viewpager.widget.ViewPager/androidx.recyclerview.widget.RecyclerView/android.widget.FrameLayout/android.view.ViewGroup/android.widget.ScrollView/android.view.ViewGroup/android.widget.LinearLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup/android.view.ViewGroup/android.widget.EditText"), MobileBy.AccessibilityId("Pick Up From"));
        public SeleneElement PickUpTime => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Pick Up Time']"), MobileBy.AccessibilityId("Pick Up Time"));
        public SeleneElement DropOffAt => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Drop Off At']"), MobileBy.AccessibilityId("Drop Off At"));
        public SeleneElement DropOffTime => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Drop Off Time']"), MobileBy.AccessibilityId("Drop Off Time"));
        public SeleneElement NoThanks => GetElementByXPath("//android.widget.TextView[@text='NO, THANKS']");
        public SeleneElement DoneBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/mdtp_ok"), MobileBy.AccessibilityId("Done"));
        public SeleneElement CancelBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/mdtp_cancel"), MobileBy.AccessibilityId("Cancel"));
        public SeleneElement AddPickUpbtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnNewPickupLocation"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Add Pick Up\"]"));
        public SeleneElement AddDropOffbtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnNewPickupLocation"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Add Droff Off\"]"));
        public SeleneElement TypeOfTransport => GetPlatformSpecificElement(MobileBy.XPath("//androidx.viewpager.widget.ViewPager/androidx.recyclerview.widget.RecyclerView/android.widget.FrameLayout/android.view.ViewGroup/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup[3]/android.view.ViewGroup/android.view.ViewGroup/android.widget.EditText"), MobileBy.AccessibilityId("Type of Transport"));
        public SeleneElement ChidrenTab => GetPlatformSpecificElement(MobileBy.AccessibilityId("Children Attending"), MobileBy.AccessibilityId("Children"));
        public SeleneElement EventsTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.LinearLayout[@content-desc='Event Timeline']"), MobileBy.AccessibilityId("Events"));
        public SeleneElement SavedTransportDetails => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnSaveTransportDetails"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"Morning\"])[2]"));
        public SeleneElement SaveButton => GetPlatformSpecificElement(MobileBy.Id("android:id/button3"), MobileBy.AccessibilityId("Save"));
        public SeleneElement AddChild => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnAddChildren"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Add Children\"]"));
        public SeleneElement AddSomeChild => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEmptyMomentGalleryTitle"), MobileBy.AccessibilityId("Add some children"));
        public SeleneElement AddChildInfo => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEmptyMomentGalleryMessage"), MobileBy.AccessibilityId("Tap 'Add Children' on the bottom right to add children to the list."));
        public SeleneElement AllRoom=>GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvListRoomSelector"),MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"All Rooms\"]"));
        public SeleneElement AllGrades => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvListGradeSelector"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"All Grades\"]"));
        public SeleneElement AllClasses => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvListDefaultTLSelector"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"All Classes\"]"));
        public SeleneElement SelectAll => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnAddChildrenSelectAll"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Select All\"]"));
        public SeleneElement DeselectedAll => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnAddChildrenSelectAll"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Deselect All\"]"));
        public SeleneElement DefaultsList => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvListDefaultTLSelector"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Default Lists\"]"));
        public SeleneElement SelectedCheckBox => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnAddChild"), MobileBy.XPath("(//XCUIElementTypeButton[@name=\"btn addition\"])[1]"));
        public SeleneElement TotalSelectedChild => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvAddChildrenCount"), MobileBy.AccessibilityId("20 Children Selected"));
        public SeleneElement TotalDefaultSelectedChild => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvAddChildrenCount"), MobileBy.AccessibilityId("0 Children Selected"));
        public SeleneElement TotalOneSelectedChild => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvTLConfirmChildCount"), MobileBy.AccessibilityId("1 Child Selected"));
        public SeleneElement AddChildrenBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnAddChildren"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"Add Children\"])[2]"));
        public SeleneElement CloseBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tbTLConfirmationClose"), MobileBy.AccessibilityId("Close"));
        public SeleneElement CrossBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/ivRemoveChild"), MobileBy.AccessibilityId("circled cross"));
        public SeleneElement SaveBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnSaveTransportDetails"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Save\"]"));
        public SeleneElement PickupCheckbox => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/cbSelectChild"), MobileBy.AccessibilityId("circel blue"));
        public SeleneElement PickupBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnPickDrop"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Pick Up\"]"));
        public SeleneElement PickUpButton => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnTLConfirm"), MobileBy.XPath("//XCUIElementTypeButton[@name='Pick Up']"));
        public SeleneElement PickUpPage => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Pick Up']"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Pick Up\"]"));
        public SeleneElement NoOfPickUp => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvProgress"), MobileBy.AccessibilityId("1"));
        public SeleneElement PickupCancel => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnCancel"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Cancel\"]"));
        public SeleneElement SaveConfirm => GetPlatformSpecificElement(MobileBy.Id("android:id/button2"), MobileBy.XPath("Save"));
        public SeleneElement EducatorBtn => GetPlatformSpecificElement(MobileBy.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.view.ViewGroup"), MobileBy.AccessibilityId("Educator"));
        public SeleneElement ConfirmationCheckBox => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/chkConfirm"), MobileBy.AccessibilityId("circel blue"));
        public SeleneElement DropOffPage => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvTitle"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Picked Up - 1\"]"));
        public SeleneElement DropOffBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnPickDrop"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Drop Off\"]"));
        public SeleneElement DropOffTitle => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvTLToolbarTitle"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Drop Off\"]"));
        public SeleneElement DropOffButton => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnTLConfirm"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Drop Off\"]"));
        public SeleneElement DropOffCheckbox => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/cbSelectChild"), MobileBy.AccessibilityId("circel blue"));
        public SeleneElement EndOfTransport => GetPlatformSpecificElement(MobileBy.Id("android:id/button2"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"End Transport\"])[2]"));
        public SeleneElement EndOfTransportBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnTLConfirm"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"End Transport\"])[2]"));
        public SeleneElement CancelEndOfTransport => GetPlatformSpecificElement(MobileBy.Id("android:id/button3"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Cancel\"]"));
        public SeleneElement ReviewDetails => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvLabel1"), MobileBy.AccessibilityId("Review Details"));
        public SeleneElement Notes => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvBorderedEditTextTitle"), MobileBy.XPath("//XCUIElementTypeApplication[@name=\"Playground\"]/XCUIElementTypeWindow[1]/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeScrollView/XCUIElementTypeOther[1]/XCUIElementTypeOther[3]/XCUIElementTypeOther/XCUIElementTypeTextView"));
        public SeleneElement HeadCountBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btn_start_head_count"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Head Count\"]"));
        public SeleneElement DropOffTotalCount => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvProgress"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"1\"]"));
        public SeleneElement DropOffPopupTitle => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvTitle"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"Dropped Off - 1\"])"));
        public SeleneElement ChildName=>GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Babulal Sah child1']"), MobileBy.XPath("//XCUIElementTypeStaticText[contains(@name,'Babulal Sah')]"));
        public SeleneElement TimelineTab => GetPlatformSpecificElement(MobileBy.AccessibilityId("Timeline"), MobileBy.AccessibilityId("Timeline"));
        public SeleneElement HealthTab => GetPlatformSpecificElement(MobileBy.AccessibilityId("Medical"), MobileBy.AccessibilityId("Health"));
        public SeleneElement ContactsTab => GetPlatformSpecificElement(MobileBy.AccessibilityId("Contacts"), MobileBy.AccessibilityId("Contacts"));
        public SeleneElement SendReport => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnSendReport"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Send Report\"]"));
        public SeleneElement SendReportLbl => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvDialogTitle"), MobileBy.AccessibilityId("Send Report"));
        public SeleneElement EmailField => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/txtEditText"), MobileBy.IosClassChain("**/XCUIElementTypeTextField[`value == \"Email\"`]"));
        public SeleneElement CancelReport => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnActionLeft"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Cancel\"]"));
        public SeleneElement SendBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnActionRight"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Send\"]"));
        public SeleneElement EmailValidation => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/textinput_error"), MobileBy.XPath("//XCUIElementTypeStaticText[contains(@name,'Please enter your email')]"));
        public SeleneElement SendReportMsg => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvItemEventTitle"), MobileBy.XPath("//XCUIElementTypeStaticText[contains(@name,'Send Report')]"));

        public void ScrollToTransportList()
        {
            if (MobileDriver.IsAndroid)
            {
                this.ScrollToElement("Transport List");
            }
            else
            {
                //this.ScrollHalfOfTheScreen();
                this.ScrollToElement("Transport List");
            }
        }

        public void ClickOnTransportListBtn()
        {
            this.ClickElement(TransportButton);
        }

        public void ClickOnNewListBtn()
        {
            this.ClickElement(NewListBtn);
        }
        public void TypeListname(string listname)
        {
            this.EnterText(ListName, listname);
        }

        public void ClickOnDateOfTransport()
        {
            if (MobileDriver.IsIOS)
            {
                this.ClickElement(DateOfTransport);
            }
            else
            {
                this.ClickElement(ChidrenTab);
                this.ClickElement(SaveButton);
            }
        }

        public void ClickOnChildrenTab()
        {
            this.ClickElement(ChidrenTab);
        }

        public void ClickOnAddChild()
        {
            this.ClickElement(AddChild);
        }

        public void ClickOnChildCheckBox()
        {
            this.ClickElement(SelectedCheckBox);
        }
        public void ClickTransportListSaveBtn()
        {
            if (MobileDriver.IsIOS) { this.ClickElement(TransportSaveBtn); }
        }

        public void ClickOnAddChildrenBtn()
        {
            this.ClickElement(AddChildrenBtn);
        }

        public void ClickOnSaveBtn()
        {
            this.ClickElement(SaveBtn);
        }
        public void ClickOnSaveConfirmBtn()
        {
            if (MobileDriver.IsAndroid) { this.ClickElement(SaveConfirm); }
        }

        public void ClickOnPickCheckbox()
        {
            this.ClickElement(PickupCheckbox);
        }

        public void ClickOnPickupBtn()
        {
            this.WaitForElementToBeClickable();
            this.ClickElement(PickupBtn);
        }

        public void ClickOnEducatorBtn()
        {
            this.ClickElement(EducatorBtn);
        }

        public void ClickOnConfirmationCheckbox()
        {
            this.ClickElement(ConfirmationCheckBox);
        }

        public void ClickOnConfirmPickupBtn()
        {
            Task.Delay(5000).Wait();
            this.ClickElement(PickUpButton);
        }

        public void ClickOnDropOffCheckbox()
        {
            Task.Delay(5000).Wait();
            this.ClickElement(DropOffCheckbox);
        }

        public void ClickOnDropOffBtn()
        {
            Task.Delay(3000).Wait();
            this.ClickElement(DropOffBtn);
        }

        public void ClickOnConfirmationCheckBox()
        {
            this.ClickElement(ConfirmationCheckBox);
        }

        public void ClickOnDropOffButton()
        {
            this.ClickElement(DropOffButton);
        }

        public void ClickOnEndOfTransport()
        {
            this.ClickElement(EndOfTransport);
        }

        public void ClickOnEndOfTransportBtn()
        {
            this.ClickElement(EndOfTransportBtn);
        }

        public void ClickOnEventsTab()
        {
            if (MobileDriver.IsAndroid)
            {
                this.ClickElement(EventsTab);
            }
        }

        public void ClickOnSendReportBtn()
        {
            this.ClickElement(SendReport);
        }

        public void TypeEmail(string email)
        {
            this.EnterText(EmailField, email);
        }

        public void ClickOnSendBtn()
        {
            this.ClickElement(SendBtn);
        }

        public void ValidateTransportListEmailSendSuccessfully()
        {
            bool isEmailSent = this.ValidateElementIsDisplayed(SendReportMsg);
            if (isEmailSent)
            {
                Assert.IsTrue(true);
            }
            else 
            { 
                Assert.IsTrue(false); 
            }
        }

        public void ValidateChildrenIsDropOffSuccessfully()
        {
            this.WaitForElementToBeClickable();
            string actualDropoffTitle = GetElementText(DropOffPopupTitle);
            Assert.AreEqual(actualDropoffTitle, "Dropped Off - 1");
        }

        public bool isNewListBtnDisplayed
        {
            get
            {
                try
                {
                   bool isDisplayed= NewListBtn.Displayed;
                   return !isDisplayed;
                }
                catch(TimeoutException)
                {
                    return true;
                }
            }
        }
        public static string getDate()
        {
            DateTime currentDate = DateTime.Now;
            int day = currentDate.Day+1;
            string today_day= day.ToString();
            return today_day;            
        }

        public string CurrentDate()
        {
            DateTime currentDate = DateTime.Now;
            string CurrentEndDate = currentDate.ToString("dd MMMM yyyy");
            return CurrentEndDate;
        }

        public static string pastDate()
        {
			DateTime currentDate = DateTime.Now;
			int day = currentDate.Day - 1;
			string past_day = day.ToString();
			return past_day;
		}
    }

}
