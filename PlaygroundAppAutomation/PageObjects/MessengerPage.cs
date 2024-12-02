using MobileAutomation.Tools;
using NSelene;
using NUnit.Framework;
using OpenQA.Selenium.Appium;

namespace MobileAutomation.PageObjects
{
    class MessengerPage:BasePage
    {
        public MessengerPage(AppiumDriver<AppiumWebElement> driver) : base(driver) { }

        public SeleneElement MessengerButton => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Messenger']"), MobileBy.AccessibilityId("Messenger"));
        public SeleneElement MessagesPageTitle => GetPlatformSpecificElement(MobileBy.AccessibilityId("Messages"), MobileBy.AccessibilityId("Messages"));
        public SeleneElement CreateBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.ImageView[@NAF='true']"), MobileBy.AccessibilityId("Nill"));
        public SeleneElement NextBtn => GetPlatformSpecificElement(MobileBy.XPath("//*[@content-desc='Next']"), MobileBy.AccessibilityId("Nill"));
        public SeleneElement MessageTitle => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.EditText[@index='0']"), MobileBy.AccessibilityId("Nill"));
        public SeleneElement MessageDescription => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.EditText[@index='0']"), MobileBy.AccessibilityId("Nill"));
        public SeleneElement SendBtn => GetPlatformSpecificElement(MobileBy.XPath("//*[@content-desc='Send']"), MobileBy.AccessibilityId("Nill"));

        public void ClickOnMessengerBtn()
        {
            this.ClickElement(MessengerButton);
        }

        public void ValidateMessengerPageOpened()
        {
            this.WaitForElementToBeClickable();
            bool IsMessagesOpened = this.ValidateElementIsDisplayed(MessagesPageTitle);
            Assert.IsTrue(IsMessagesOpened, "Messenger page is not opened successfully");
        }
        public void ClickOnCreateBtn()
        {
            this.ClickElement(CreateBtn);
        }
        public void ClickOnNextBtn() 
        {
            this.ClickElement(NextBtn);
        }

        public void TypeMessageTitle(string title)
        {
            this.EnterText(MessageTitle, title);
        }
        public void TypeMessageDescription(string description) 
        {
            this.EnterText(MessageDescription, description);
        }
        public void ClickOnSendBtn() 
        {
            this.ClickElement(SendBtn);
        }
    }
}
