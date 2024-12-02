using MobileAutomation.Tools;
using NSelene;
using NUnit.Framework;
using OpenQA.Selenium.Appium;


namespace MobileAutomation.PageObjects
{
     class EmergencyListPage:BasePage
    {
        public EmergencyListPage(AppiumDriver<AppiumWebElement> driver) : base(driver) { }
        public SeleneElement EmergencyListButton => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Emergency List']"), MobileBy.AccessibilityId("Emergency List"));
        public SeleneElement SearchBtn => GetPlatformSpecificElement(MobileBy.Id("android:id/search_button"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Search\"]"));
        public SeleneElement SearchInput => GetPlatformSpecificElement(MobileBy.Id("android:id/search_src_text"), MobileBy.XPath("//XCUIElementTypeSearchField[@name=\"Search Children\"]"));
        public SeleneElement RoomDropdown => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEvacListRoomSelector"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"All Rooms\"]"));
        public SeleneElement ChildrenTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Children']"), MobileBy.AccessibilityId("Children"));
        public SeleneElement StaffTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Staff']"), MobileBy.AccessibilityId("Staff"));
        public SeleneElement VisitorTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Visitors']"), MobileBy.AccessibilityId("Visitors"));
        public SeleneElement SignedInTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Signed in']"), MobileBy.AccessibilityId("Signed in"));
        public SeleneElement BookedInTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Booked in']"), MobileBy.AccessibilityId("Booked in"));
        public SeleneElement AbsenceTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Absence']"), MobileBy.AccessibilityId("Absence"));
        public SeleneElement AllTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='All']"), MobileBy.AccessibilityId("All"));
        public SeleneElement StartEmergency => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvActivateEvent"), MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == \"Start Emergency\"`]"));
        public SeleneElement SelectEmergencyType => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEventSelectionTitle"), MobileBy.AccessibilityId("Select Emergency Type"));
        public SeleneElement EvacuationDrill => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.RadioButton[@text='Evacuation Drill']"), MobileBy.AccessibilityId("Evacuation Drill"));
        public SeleneElement LockdownDrill => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.RadioButton[@text='Lockdown Drill']"), MobileBy.AccessibilityId("Lockdown Drill"));
        public SeleneElement Evacuation => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.RadioButton[@text='Evacuation']"), MobileBy.AccessibilityId("Evacuation"));
        public SeleneElement Lockdown => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.RadioButton[@text='Lockdown']"), MobileBy.AccessibilityId("Lockdown"));
        public SeleneElement SafeCheckBox => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/switchEventListObserved"), MobileBy.XPath("//XCUIElementTypeApplication[@name=\"Playground\"]/XCUIElementTypeWindow[1]/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeTable/XCUIElementTypeCell[1]/XCUIElementTypeButton"));
        public SeleneElement EndEmergencyBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvActivateEvent"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"End Emergency\"]"));
        public SeleneElement EducatorName => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEvacConfirmEducatorName"), MobileBy.IosClassChain("**/XCUIElementTypeTextField[`value == \"Required\"`]"));
        public SeleneElement SubmitBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnEvacConfirmSubmit"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Submit the report\"]"));
        public SeleneElement EndEmergencySuccessMsg => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEvacSuccessMessage"), MobileBy.AccessibilityId("Report submitted successfully"));
        public SeleneElement PressEnterKey => GetElementByXPath("//XCUIElementTypeButton[@name=\"Return\"]");
        public SeleneElement BackButton => GetPlatformSpecificElement(MobileBy.AccessibilityId("Navigate up"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Emergency List\"]"));
        public SeleneElement SearchClear => GetPlatformSpecificElement(MobileBy.Id("android:id/search_close_btn"), MobileBy.AccessibilityId("Clear text"));
        public SeleneElement SearchCancel => GetPlatformSpecificElement(MobileBy.Id("android:id/search_close_btn"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Cancel\"]"));
        public SeleneElement ChildName => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvItemEventListChildName"), MobileBy.XPath("//XCUIElementTypeStaticText[contains(@name, \"Babulal\")]"));
		public SeleneElement StaffName => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Babulal Shah']"), MobileBy.XPath("//XCUIElementTypeStaticText[contains(@name, \"Babulal\")]"));
		public SeleneElement NoChildFound => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvNoContactsTitle"), MobileBy.AccessibilityId("No children found"));
        public SeleneElement NoStaffFound => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvNoContactsTitle"), MobileBy.AccessibilityId("No staff found"));
        public SeleneElement NoVisitorFound => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvNoContactsTitle"), MobileBy.AccessibilityId("No visitor found"));
        public SeleneElement NoChildFoundIcon => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/ivIcon"), MobileBy.AccessibilityId("No children found"));
        public SeleneElement NoStaffIconFound => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/ivIcon"), MobileBy.AccessibilityId("No children found"));
        public SeleneElement TryAgainSearch => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvNoContactsMessage"), MobileBy.AccessibilityId("Please check and try again"));
        public SeleneElement AutomationRoom => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Automation Room']"), MobileBy.AccessibilityId("Automation Room"));
        public SeleneElement SelectRoomOk => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/md_button_positive"), MobileBy.AccessibilityId("Automation Room"));
        public SeleneElement ChildCount => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvRoleSwitcherCount"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"0\"])[1]"));
		public SeleneElement ChildSignedIn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvRoleSwitcherSubtitle"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"signed in\"])[1]"));
		public SeleneElement StaffCount => GetPlatformSpecificElement(MobileBy.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout/android.widget.LinearLayout/android.view.ViewGroup/android.view.ViewGroup[3]/android.view.ViewGroup/android.widget.LinearLayout/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.widget.TextView[2]"), 
            MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"0\"])[2]"));
		public SeleneElement StaffRosteredLbl => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='rostered today']"), MobileBy.AccessibilityId("rostered today"));
        public SeleneElement StaffRosteredTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Rostered today']"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"Rostered today\"])[1]"));
        public SeleneElement VisitorCount => GetPlatformSpecificElement(MobileBy.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout/android.widget.LinearLayout/android.view.ViewGroup/android.view.ViewGroup[3]/android.view.ViewGroup/android.widget.LinearLayout/android.view.ViewGroup/android.view.ViewGroup[3]/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.widget.TextView[2]"),
			MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"0\"]"));
		public SeleneElement VisitorSignedIn => GetPlatformSpecificElement(MobileBy.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout/android.widget.LinearLayout/android.view.ViewGroup/android.view.ViewGroup[3]/android.view.ViewGroup/android.widget.LinearLayout/android.view.ViewGroup/android.view.ViewGroup[3]/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/android.widget.TextView[3]"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"signed in\"])[2]"));
        //public SeleneElement StaffAll => GetElementByAcccessibilityId("All");
        public SeleneElement AddPeopleBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvAddOthers"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Add people\"]"));
		public SeleneElement AddPeopleCount => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvAddOthers"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"(0)\"]"));
		public SeleneElement AddedPeopleCount => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvAddOthers"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"(1)\"]"));
		public SeleneElement AddPeople => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnPeople"), MobileBy.XPath("(//XCUIElementTypeButton[@name=\"Add people\"])[2]"));
		public SeleneElement Name => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/edtName"), MobileBy.AccessibilityId("add-edit-others-name"));
		public SeleneElement PhoneNumber => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/edtPhoneNumber"), MobileBy.AccessibilityId("add-edit-others-contact-number"));
		public SeleneElement Note => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/edtNote"), MobileBy.AccessibilityId("add-edit-others-note"));
		public SeleneElement Submit => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnSubmit"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Mark as safe\"]"));
		public SeleneElement PeopleAdded => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/clEventListItem"), MobileBy.XPath("//XCUIElementTypeApplication[@name=\"Playground\"]/XCUIElementTypeWindow[1]/XCUIElementTypeOther[3]/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeTable/XCUIElementTypeCell/XCUIElementTypeOther[1]/XCUIElementTypeOther"));
		public SeleneElement NavigateBack => GetPlatformSpecificElement(MobileBy.AccessibilityId("Navigate up"), MobileBy.XPath("(//XCUIElementTypeButton[@name=\"Add people\"])[1]"));
		public SeleneElement SearchIcon => GetPlatformSpecificElement(MobileBy.Id("android:id/search_button"), MobileBy.AccessibilityId("Search"));
		public SeleneElement NoOtherPeopleFound => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvNoPeople"), MobileBy.AccessibilityId("No other people found"));
		public SeleneElement StartToAdd => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvNoPeopleMessage"), MobileBy.AccessibilityId("Start to add someone and mark as safe"));
        public SeleneElement AddPeopleSearchInbox => GetPlatformSpecificElement(MobileBy.Id("android:id/search_src_text"), MobileBy.AccessibilityId("Search Others"));
        public SeleneElement AddPeopleDiglog => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvDialogTitle"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name=\"Add people\"])[3]"));
        public SeleneElement CloseAddPeoplePopup => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnClose"), MobileBy.AccessibilityId("x dismiss"));
        public SeleneElement AddPeopleNameLbl => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvName"), MobileBy.AccessibilityId("Name"));
		public SeleneElement AddPeoplePhoneLbl => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvPhoneNumber"), MobileBy.AccessibilityId("Phone number"));
		public SeleneElement AddPeopleNoteLbl => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvNote"), MobileBy.AccessibilityId("Note"));
		public SeleneElement AddPeopleMarkSafeLbl => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnSubmit"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Mark as safe\"]"));
        public SeleneElement AddPeopleSuccessMsg => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvTitle"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Person added successfully\"]"));
		public SeleneElement SafeLbl => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvSafe"), MobileBy.AccessibilityId("Safe?"));
		public SeleneElement NameInitials => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/ivItemEventAvatar"), MobileBy.XPath("//XCUIElementTypeApplication[@name=\"Playground\"]/XCUIElementTypeWindow[1]/XCUIElementTypeOther[3]/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeTable/XCUIElementTypeCell/XCUIElementTypeImage"));
		public SeleneElement FullName => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvItemEventListChildName"), MobileBy.AccessibilityId("Babulal Sah"));
		public SeleneElement CheckBoxFofSafe => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/imgEventListObserved"), MobileBy.XPath("//XCUIElementTypeApplication[@name=\"Playground\"]/XCUIElementTypeWindow[1]/XCUIElementTypeOther[3]/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeTable/XCUIElementTypeCell/XCUIElementTypeButton"));
		public SeleneElement PeopleDetailBackBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/ivEvacDetailsBack"), MobileBy.AccessibilityId("green back arrow"));
		public SeleneElement PeopleDetailsInitials => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/ivEvacDetailsChildImage"), MobileBy.XPath("//XCUIElementTypeApplication[@name=\"Playground\"]/XCUIElementTypeWindow[1]/XCUIElementTypeOther[3]/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther[1]/XCUIElementTypeImage"));
		public SeleneElement PeopleDetailName => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEvaDetailsChildName"), MobileBy.AccessibilityId("Babulal Sah"));
		public SeleneElement PeopleDetailPhone => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/lblPhone"), MobileBy.AccessibilityId("CONTACT NUMBER"));
		public SeleneElement PeopleDetailNote => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/lblNote"), MobileBy.AccessibilityId("NOTE"));
        public SeleneElement SubmitEmergencyListScreen => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEvacConfirmTitle"), MobileBy.AccessibilityId("Submit Emergency List"));
        public SeleneElement SubmitCloseBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/imgEvacConfirmCancel"), MobileBy.AccessibilityId("crossIcon"));
		public SeleneElement SubmitConfirmMsg => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEvacConfirmMessage"), MobileBy.AccessibilityId("Deactivating the emergency list will allow you to send any record information to your service administrator."));
		public SeleneElement EducatorNameLbl => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEducatorLabel"), MobileBy.AccessibilityId("Educator Name"));
		public SeleneElement TotalTime => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEvacConfirmTotalTimeTitle"), MobileBy.AccessibilityId("Total time"));
		public SeleneElement StartTime => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEvacConfirmStartTimeTitle"), MobileBy.AccessibilityId("Started"));
		public SeleneElement EndTime => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEvacConfirmEndTimeTitle"), MobileBy.AccessibilityId("Ended"));
		public SeleneElement BriefLbl => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEvacBrief"), MobileBy.AccessibilityId("Brief"));
		public SeleneElement ChildAccounted => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvChildrenCount"), MobileBy.AccessibilityId("1/20 children accounted for"));
		public SeleneElement StaffAccounted => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEducatorCount"), MobileBy.AccessibilityId("0/2 staff accounted for"));
		public SeleneElement VisitorAccounted => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvVisitorCount"), MobileBy.AccessibilityId("0/0 visitors accounted for"));
		public SeleneElement PeopleAddedCount => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvOtherCount"), MobileBy.AccessibilityId("0 other people added, 0/0 of them accounted for"));
		public SeleneElement EndEmergencyDoneBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnEvacSuccess"), MobileBy.AccessibilityId("Done"));
		public SeleneElement TotalTimeEL => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEvacConfirmTotalTime"), MobileBy.XPath("//XCUIElementTypeApplication[@name=\"Playground\"]/XCUIElementTypeWindow[1]/XCUIElementTypeOther[3]/XCUIElementTypeOther[2]/XCUIElementTypeOther/XCUIElementTypeTable/XCUIElementTypeCell[2]/XCUIElementTypeStaticText[1]"));
		public SeleneElement StartedTime => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEvacConfirmStartTime"), MobileBy.XPath("//XCUIElementTypeApplication[@name=\"Playground\"]/XCUIElementTypeWindow[1]/XCUIElementTypeOther[3]/XCUIElementTypeOther[2]/XCUIElementTypeOther/XCUIElementTypeTable/XCUIElementTypeCell[3]/XCUIElementTypeStaticText[1]"));
		public SeleneElement EndedTime => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEvacConfirmEndTime"), MobileBy.XPath("//XCUIElementTypeApplication[@name=\"Playground\"]/XCUIElementTypeWindow[1]/XCUIElementTypeOther[3]/XCUIElementTypeOther[2]/XCUIElementTypeOther/XCUIElementTypeTable/XCUIElementTypeCell[4]/XCUIElementTypeStaticText[1]"));
		public SeleneElement EndEmergencyLbl => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEndSuccessTitle"), MobileBy.AccessibilityId("End Emergency"));
		public SeleneElement ReportSuccessMsg => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvEvacSuccessMessage"), MobileBy.AccessibilityId("Report submitted successfully"));   

        public void ClickOnEmergencyListButton()
        {
            this.ClickElement(EmergencyListButton);
        }
        public void ClickOnStartEmergency()
        {
            this.ClickElement(StartEmergency);
        }
        public void ClickOnEvacuationDrill()
        {
            this.ClickElement(EvacuationDrill);
        }
        public void ClickOnLockdownDrill()
        {
            this.ClickElement(LockdownDrill);
        }
        public void ClickOnAllTab()
        {
            this.ClickElement(AllTab);
        }
        public void ClickOnSafeCheckBox()
        {
            this.ClickElement(SafeCheckBox);
        }
        public void ClickOnEndEmergencyBtn()
        {
            this.ClickElement(EndEmergencyBtn);
        }
        public void TypeEducatorName(string educatorNam)
        {
            this.EnterText(EducatorName, educatorNam);
        }
        public void HideiOSKeyboard()
        {
            this.ClickElement(PressEnterKey);
        }
        public void ClickOnSubmitBtn()
        {
            this.ClickElement(SubmitBtn);
        }

        public void ValidateEmergencyListStartedAndEndedSuccessfully()
        {
            string actualMessage = GetElementText(EndEmergencySuccessMsg);
            string expectedMessage = "Report submitted successfully";
            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}
