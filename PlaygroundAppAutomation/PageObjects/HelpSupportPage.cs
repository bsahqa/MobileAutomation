using NSelene;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Security.Permissions;
using System.Threading.Tasks;


namespace MobileAutomation.PageObjects
{
    class HelpSupportPage:BasePage
    {
        public HelpSupportPage(AppiumDriver<AppiumWebElement> driver) : base(driver) { }
        public SeleneElement HelpSupportButton => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Help & Support']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Help & Support\"]"));
        public SeleneElement Url => GetPlatformSpecificElement(MobileBy.Id("com.android.chrome:id/url_bar"), MobileBy.XPath("//XCUIElementTypeOther[@name=\"URL\"]"));
        public SeleneElement HomeLbl => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='We are here to help at Xplor!']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"We are here to help at Xplor!\"]"));
        public SeleneElement AccountBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Account']"), MobileBy.AccessibilityId("TabBarIcons/account-inactive"));
        public SeleneElement HelpAndSupport => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Help & Support']"), MobileBy.AccessibilityId("Help & Support"));
        public SeleneElement HelpURL => GetPlatformSpecificElement(MobileBy.Id("com.sec.android.app.sbrowser:id/location_bar_edit_text"), MobileBy.XPath("//XCUIElementTypeOther[@name=\"URL\"]"));
        public SeleneElement DoneBtn => GetElementByXPath("//XCUIElementTypeButton[@name=\"Done\"]");

        public void ClickOnHelpAndSupportBtn()
        {
            this.ClickElement(HelpSupportButton);
        }
        public void ValidateHelpAndSupportPageOpenedSuccessfully()
        {
            Task.Delay(35000).Wait();
            bool IsPageOpened = IsElementDisplayed(HomeLbl);
            if(IsPageOpened)
            {
                Assert.IsTrue(true, "Help & Support page is opened successfully");
            }
            else
            {
                Assert.IsTrue(false, "Help & Support page is not opened successfully");
            }
        }  
    }
}
