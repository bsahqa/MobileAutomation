using HomeAppAutomations.PageObjects;
using OpenQA.Selenium.Appium;
using NSelene;
using NUnit.Framework;
namespace HomeAppAutomation.PageObjects.CommonPages
{
    class HomePage : BasePage
    {
        public HomePage(AppiumDriver<AppiumWebElement> driver) : base(driver){ }
        public SeleneElement Dashboard => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvAttendanceSignIn"), MobileBy.AccessibilityId("Sign In & Out"));
        public SeleneElement BookingsTab => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/menuItemBookings"), MobileBy.AccessibilityId("bookings-tab-inactive"));
        public SeleneElement BookingsLbl => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Bookings']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Bookings\"]"));
        public SeleneElement CareLbl => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Care Events']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Care Events\"]"));
        public SeleneElement CareTab => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/menuItemCare"), MobileBy.AccessibilityId("learning-tab-inactive"));
        public SeleneElement FinanceTab => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/menuItemFinance"), MobileBy.AccessibilityId("finance-tab-inactive"));
        public SeleneElement FinanceLbl => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Finance']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Finance\"]"));
        public SeleneElement AccountTab => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/menuItemAccount"), MobileBy.AccessibilityId("account-tab-inactive"));
        public SeleneElement AccountLbl => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Settings']"), MobileBy.AccessibilityId("Settings"));
        public SeleneElement SignInOutTab => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/menuItemAttendance"), MobileBy.AccessibilityId("Sign In & Out"));
        public SeleneElement SignInOutLbl => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Sign In & Out']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Sign In & Out\"]"));
        public void ValidateParentSingedInSuccessfully()
        {
            this.WaitForElementToBeClickable();
            string actualSignInOutLbl= GetElementText(SignInOutLbl);
            string expectedSignInOutLbl = "Sign In & Out";
            Assert.AreEqual(expectedSignInOutLbl, actualSignInOutLbl, "Parent is not signed in successfully");
        }
    }
    public class DashboardStrings
    {
        public DashboardStrings() { }
        public const string BookingTab = "Bookings";
        public const string CareTab = "Care Events";
        public const string FinanceTab = "Finance";
        public const string SettingsTab = "Settings";
    }
}

