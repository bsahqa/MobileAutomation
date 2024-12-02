using HomeAppAutomations.PageObjects;
using NSelene;
using NUnit.Framework;
using OpenQA.Selenium.Appium;

namespace HomeAppAutomation.PageObjects
{
    class AccountPage : BasePage
    {
        public AccountPage(AppiumDriver<AppiumWebElement> driver) : base(driver)
        { }

        public SeleneElement AccountTab => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/menuItemAccount"), MobileBy.AccessibilityId("Account"));
        public SeleneElement InboxBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Inbox']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Inbox\"]"));
        public SeleneElement ComposeMessageBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/menuItemComposeMessage"), MobileBy.AccessibilityId("pencil edit"));
        public SeleneElement MessageTitle => GetPlatformSpecificElement(MobileBy.XPath("//android.view.View/android.view.View[2]/android.widget.EditText[1]"), MobileBy.AccessibilityId("Message Title..."));
        public SeleneElement MessageBody => GetPlatformSpecificElement(MobileBy.XPath("//android.view.View/android.view.View[2]/android.widget.EditText[2]"), MobileBy.AccessibilityId("Write a message..."));
        public SeleneElement SendBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.Button[@content-desc=\"Send\"]"), MobileBy.AccessibilityId("Send"));
        public SeleneElement MessageTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Messages']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Messages\"]"));
        public SeleneElement AdminPostTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Admin Posts']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Admin Posts\"]"));
        public SeleneElement NotificationTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Notifications']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Notifications\"]"));
        public SeleneElement AdminPostTitle => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvItemMessageTitle"), MobileBy.AccessibilityId("Holiday Notification"));
        public SeleneElement AdminPostDetailViewPostTitle => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tlMessageTitle"), MobileBy.XPath("(//XCUIElementTypeStaticText[@name='Holiday Notification'])[1]"));
        public SeleneElement NotificationTitle => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvItemNotificationTitle"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='Educator Test']"));
        public void ValidateAdminPostIsDisplayed()
        {
            string actualAdminPostTitle = GetElementText(AdminPostTitle);
            string expectedAdminPostTitle = "Holiday Notification";
            Assert.AreEqual(expectedAdminPostTitle, actualAdminPostTitle, "Admin post is not displayed");
        }
        public void ValidateAdminPostDetailViewIsDisplayed()
        {
            string actualAdminPostDetailViewPostTitle = GetElementText(AdminPostDetailViewPostTitle);
            string expectedAdminPostDetailViewPostTitle = "Holiday Notification";
            Assert.AreEqual(expectedAdminPostDetailViewPostTitle, actualAdminPostDetailViewPostTitle, "Admin post detail view is not displayed");
        }
        public void ValidateNotificationIsDisplayed()
        {
            string actualNotificationTitle = GetElementText(NotificationTitle);
            string expectedNotificationTitle = "Educator Test";
            Assert.AreEqual(expectedNotificationTitle, actualNotificationTitle, "Notification is not displayed");
        }
        public void ClickOnAdminPostTitle()
        {
            this.ClickElement(AdminPostTitle);
        }
        public void ClickOnAccountTab()
        {
            this.ClickElement(AccountTab);
        }
        public void ClickOnInboxBtn()
        {
            this.ClickElement(InboxBtn);
        }
        public void ClickOnComposeMessageBtn()
        {
            this.ClickElement(ComposeMessageBtn);
        }
        public void EnterMessageTitle(string messageTitle)
        {
            this.EnterText(MessageTitle, messageTitle);
        }
        public void EnterMessageBody(string messageBody)
        {
            this.EnterText(MessageBody, messageBody);
        }
        public void ClickOnSendBtn()
        {
            this.ClickElement(SendBtn);
        }
        public void ClickOnMessageTab()
        {
            this.ClickElement(MessageTab);
        }
        public void ClickOnAdminPostTab()
        {
            this.ClickElement(AdminPostTab);
        }
        public void ClickOnNotificationTab()
        {
            this.ClickElement(NotificationTab);
        }
        public void ValidateMessageIsCreatedAndSent()
        {
            string actualMessage=GetElementText(MessageTab);
            string expectedMessage = "Messages";
            Assert.AreEqual(expectedMessage, actualMessage, "Message is not sent");
        }

    }
}
