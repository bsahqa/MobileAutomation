using OpenQA.Selenium.Appium;
using NSelene;
using MobileAutomation.Tools;
using NUnit.Framework;
using System.Threading.Tasks;
using AventStack.ExtentReports;

namespace MobileAutomation.PageObjects
{
    class HomePage : BasePage
    {
        /// <summary>
        /// Initializes a new instance of the HomePage class.
        /// </summary>
        public HomePage(AppiumDriver<AppiumWebElement> driver) : base(driver) { }

        /// <summary>
        /// Selector for Dashboard.
        /// </summary>
        public SeleneElement Dashboard => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/detail_text_view"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='Automation_Service_1 ▾']"));

        /// <summary>
        /// Selector for Logout button.
        /// </summary>
        public SeleneElement Logout => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/md_button_positive"), MobileBy.AccessibilityId("Log out"));

        /// <summary>
        /// Selector for Login button.
        /// </summary>
        public SeleneElement Login => GetPlatformSpecificElement(MobileBy.ClassName("android.widget.ImageView"), MobileBy.ClassName(""));

        /// <summary>
        /// Selector for Room label.
        /// </summary>
        public SeleneElement RoomLabel => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Rooms']"), MobileBy.AccessibilityId("Rooms"));

        /// <summary>
        /// Selector for Messenger button.
        /// </summary>
        public SeleneElement MessengerButton => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Messenger']"), MobileBy.AccessibilityId("Messenger"));

        /// <summary>
        /// Selector for Transport Lists button.
        /// </summary>
        public SeleneElement TransportButton => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Transport Lists']"), MobileBy.AccessibilityId("Transport List"));

        /// <summary>
        /// Selector for Head Count button.
        /// </summary>
        public SeleneElement HeadcountButton => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Head Count']"), MobileBy.AccessibilityId("Head Count"));

        /// <summary>
        /// Selector for Incident Records button.
        /// </summary>
        public SeleneElement IncidentButton => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Incident Records']"), MobileBy.AccessibilityId("Incident Records"));

        /// <summary>
        /// Selector for Emergency List button.
        /// </summary>
        public SeleneElement EmergencyListButton => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Emergency List']"), MobileBy.AccessibilityId("Emergency List"));

        /// <summary>
        /// Selector for Help & Support button.
        /// </summary>
        public SeleneElement HelpSupportButton => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Help & Support']"), MobileBy.AccessibilityId("Help & Support"));

        /// <summary>
        /// Selector for Service Name.
        /// </summary>
        public SeleneElement ServiceName => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='AUTOMATION_SERVICE_1']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='Automation_Service_1 ▾']"));

        /// <summary>
        /// Selector for Refresh button.
        /// </summary>
        public SeleneElement RefreshButton => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/ivRefresh"), MobileBy.AccessibilityId("refresh arrow"));

        /// <summary>
        /// Selector for Automation Room label.
        /// </summary>
        public SeleneElement RoomAllDay => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Automation Room']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='Automation Room']"));

        /// <summary>
        /// Selector for number of bookings.
        /// </summary>
        public SeleneElement NoOfBookings => GetPlatformSpecificElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"out of 8 bookings\")"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"out of 8 bookings  2 educators required\"]"));

        /// <summary>
        /// Selector for number of educators required.
        /// </summary>
        public SeleneElement NoOfEducatorRequired => GetPlatformSpecificElement(MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"2 educator required\")"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"out of 8 bookings  2 educators required\"]"));

        /// <summary>
        /// Selector for number of signed-in users.
        /// </summary>
        public SeleneElement NoOfSignedIn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/room_occupancy_text_view"), MobileBy.AccessibilityId("room_occupancy_text_view"));

        /// <summary>
        /// Scrolls to and selects the Help & Support button.
        /// </summary>
        public SeleneElement elem => ScrollToElement("Help & Support");

        /// <summary>
        /// Checks if the Refresh button is displayed.
        /// </summary>
        public bool IsRefreshButtonDisplayed => RefreshButton.Displayed;

        /// <summary>
        /// Checks if the Service Name is displayed.
        /// </summary>
        public bool IsServiceNameDisplayed => ServiceName.Displayed;

        public void ServiceNameIsDisplayed()
        {
            string actualServiceName = GetElementText(ServiceName);
            if(MobileDriver.IsIOS)
            {
                Assert.That(actualServiceName, Is.EqualTo("Automation_Service_1 ▾"));
            }
            else
            {
                Assert.That(actualServiceName, Is.EqualTo("AUTOMATION_SERVICE_1"));
            }
        }

        /// <summary>
        /// Checks if the Room label is displayed.
        /// </summary>
        public void RoomLblIsDisplayed()
        {
            string actualRoomLbl = GetElementText(RoomLabel);
            Assert.That(actualRoomLbl, Is.EqualTo("Rooms"));
        }

        /// <summary>
        /// Checks if the Room Name is displayed.
        /// </summary>
        public void RoomNameIsDisplayed()
        {
            string actualRoomName = GetElementText(RoomAllDay);
            Assert.That(actualRoomName, Is.EqualTo("Automation Room"));
        }

        /// <summary>
        /// Checks if the Messenger button is displayed.
        /// </summary>
        public void MessengerIsDisplayed()
        {
            string actualRoomName = GetElementText(MessengerButton);
            Assert.That(actualRoomName, Is.EqualTo("Messenger"));
        }

        /// <summary>
        /// Checks if the Head count button is displayed.
        /// </summary>
        public void HeadcountIsDisplayed()
        {
            this.ScrollToElement("Head Count");
            string actualRoomName = GetElementText(HeadcountButton);
            Assert.That(actualRoomName, Is.EqualTo("Head Count"));
        }

        /// <summary>
        /// Checks if Incident button is displayed.
        /// </summary>
        public void IncidentIsDisplayed()
        {
            string actualRoomName = GetElementText(IncidentButton);
            Assert.That(actualRoomName, Is.EqualTo("Incident Records"));
        }

        /// Checks if Emergency List button is displayed.
        /// </summary>
        public void EmergencyListIsDisplayed()
        {
            string actualRoomName = GetElementText(EmergencyListButton);
            Assert.That(actualRoomName, Is.EqualTo("Emergency List"));
        }

        /// Checks if Emergency List button is displayed.
        /// </summary>
        public void HelpAndSupportIsDisplayed()
        {
            string actualRoomName = GetElementText(HelpSupportButton);
            Assert.That(actualRoomName, Is.EqualTo("Help & Support"));
        }

        /// <summary>
        /// Checks if Transport List is displayed.
        /// </summary>
        public void TransportListIsDisplayed()
        {
            string actualRoomName = GetElementText(TransportButton);
            if(MobileDriver.IsAndroid)
            {
                Assert.That(actualRoomName, Is.EqualTo("Transport Lists"));
            }
            else
            {
                Assert.That(actualRoomName, Is.EqualTo("Transport List"));
            }            
        }

        /// <summary>
        /// Clicks on the Service Name (Dashboard).
        /// </summary>
        public void ClickOnServiceName()
        {
            this.ClickElement(Dashboard);
        }

        /// <summary>
        /// Clicks on the Logout button.
        /// </summary>
        public void ClickOnLogoutButton()
        {
            this.ClickElement(Logout);
        }

        /// <summary>
        /// Clicks on Header Dashboard Title.
        /// </summary>
        public void ClickOnHeaderDashboardTitle()
        {
            this.ClickElement(Dashboard);
        }

        /// <summary>
        /// Checks if the Dashboard is displayed with a timeout.
        /// </summary>
        public bool IsDahboardDisplayed => Dashboard.With(timeout: 10).Displayed;


    }
}
