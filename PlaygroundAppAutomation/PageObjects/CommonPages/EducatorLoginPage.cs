using OpenQA.Selenium.Appium;
using NSelene;
using MobileAutomation.Tools;
using NUnit.Framework;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using OpenQA.Selenium;


namespace MobileAutomation.PageObjects
{
    class EducatorLoginPage : BasePage
    {
        public EducatorLoginPage(AppiumDriver<AppiumWebElement> driver) : base(driver) { }

        /// <summary>
        /// Selector for the first room labeled 'Automation Room'.
        /// </summary>
        public SeleneElement RoomFirst => GetPlatformSpecificElement(
            MobileBy.XPath("//android.widget.TextView[@text='Automation Room']"),
            MobileBy.XPath("//XCUIElementTypeStaticText[@name='Automation Room']"));

        /// <summary>
        /// Selector for the second room labeled 'Automation Room 2'.
        /// </summary>
        public SeleneElement RoomSecond => GetPlatformSpecificElement(
            MobileBy.XPath("//android.widget.TextView[@text='Automation Room 2']"),
            MobileBy.AccessibilityId("Automation Room 2"));

        /// <summary>
        /// Selector for the 'Add Educator' button.
        /// </summary>
        public SeleneElement AddEducator => GetPlatformSpecificElement(
            MobileBy.Id($"{DataContext.AndroidAppPackage}:id/ivSigninLocalEducatorsAddAccount"),
            MobileBy.AccessibilityId("Sign In Another Account"));

        /// <summary>
        /// Selector for the input field where the educator enters their phone number or email.
        /// </summary>
        public SeleneElement EducatorPhoneOrEmail => GetPlatformSpecificElement(
            MobileBy.Id($"{DataContext.AndroidAppPackage}:id/txtSignInNewEducatorEmail"),
            MobileBy.AccessibilityId("educator-username"));

        /// <summary>
        /// Selector for the input field where the educator enters their password or PIN.
        /// </summary>
        public SeleneElement EducatorPassOrPin => GetPlatformSpecificElement(
            MobileBy.Id($"{DataContext.AndroidAppPackage}:id/txtSignInNewEducatorPassword"),
            MobileBy.AccessibilityId("educator-password"));

        /// <summary>
        /// Selector for the 'Log in' button.
        /// </summary>
        public SeleneElement EducatorLoginBtn => GetPlatformSpecificElement(
            MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnSignInNewEducatorAction"),
            MobileBy.XPath("//XCUIElementTypeButton[@name=\"Log in\"]"));

        /// <summary>
        /// Selector for the 'Continue' button on the welcome popup.
        /// </summary>
        public SeleneElement CancelWelcomePopup => GetElementByXPath("//XCUIElementTypeStaticText[@name='Continue']");

        /// <summary>
        /// Selector for the 'Attendance' page element.
        /// </summary>
        public SeleneElement AttendancePage => GetPlatformSpecificElement(
            MobileBy.XPath("//android.widget.TextView[@text='Attendance']"),
            MobileBy.XPath("//XCUIElementTypeStaticText[@name='Attendance']"));

        /// <summary>
        /// Selector for the back button on the 'Attendance' page.
        /// </summary>
        public SeleneElement AttendanceBack => GetPlatformSpecificElement(
            MobileBy.AccessibilityId("Navigate up"),
            MobileBy.AccessibilityId("Dashboard"));

        /// <summary>
        /// Selector for the 'Forgot Password' link.
        /// </summary>
        public SeleneElement ForgotPassword => GetPlatformSpecificElement(
            MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvSignInNewEducatorForgotPassword"),
            MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Forgot Password?\"]"));

        /// <summary>
        /// Selector for the 'Reset' button in the password reset flow.
        /// </summary>
        public SeleneElement ResetBtn => GetPlatformSpecificElement(
            MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnInfoActionRight"),
            MobileBy.AccessibilityId("Reset"));

        /// <summary>
        /// Selector for the email input field in the password reset flow.
        /// </summary>
        public SeleneElement EmailField => GetPlatformSpecificElement(
            MobileBy.Id($"{DataContext.AndroidAppPackage}:id/txtInfoEmail"),
            MobileBy.XPath("(//XCUIElementTypeOther[@name=\"Horizontal scroll bar, 1 page\"])[2]"));

        /// <summary>
        /// Selector for the 'Send' button in the password reset flow.
        /// </summary>
        public SeleneElement SendBtn => GetPlatformSpecificElement(
            MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnInfoActionRight"),
            MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Reset Now\"]"));

        /// <summary>
        /// Selector for the 'Close' button on the login screen.
        /// </summary>
        public SeleneElement CloseBtn => GetPlatformSpecificElement(
            MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvSignInLocalEducatorsCancel"),
            MobileBy.AccessibilityId("Close"));

        /// <summary>
        /// Clicks on the first room labeled 'Automation Room'.
        /// </summary>
        public void ClickOnRoomFirst()
        {
            this.WaitForObjectToBeVisible(RoomFirst);
            this.ClickElement(RoomFirst);
        }

        /// <summary>
        /// Clicks on the second room labeled 'Automation Room 2'.
        /// </summary>
        public void ClickOnRoomSecond()
        {
            this.WaitForObjectToBeVisible(RoomSecond);
            this.ClickElement(RoomSecond);
        }

        /// <summary>
        /// Clicks on the 'Add Educator' button.
        /// </summary>
        public void ClickOnAddEducator()
        {
            this.ClickElement(AddEducator);
        }

        /// <summary>
        /// Enters the educator's phone number or email into the respective input field.
        /// </summary>
        /// <param name="educatorPhoneOrEmail">The educator's phone number or email.</param>
        public void EnterEducatorPhoneOrEmail(string educatorPhoneOrEmail)
        {
            this.EnterText(EducatorPhoneOrEmail, educatorPhoneOrEmail);
        }

        /// <summary>
        /// Enters the educator's password or PIN into the respective input field.
        /// </summary>
        /// <param name="educatorPassOrPin">The educator's password or PIN.</param>
        public void EnterEducatorPassOrPin(string educatorPassOrPin)
        {
            this.EnterText(EducatorPassOrPin, educatorPassOrPin);            
        }

        public void PressReturnKey()
        {
            this.PressKey(EducatorPassOrPin, Keys.Return);
        }

        /// <summary>
        /// Clicks on the 'Log in' button.
        /// </summary>
        public void ClickOnEducatorLoginBtn()
        {
            this.ClickElement(EducatorLoginBtn);
        }

        /// <summary>
        /// Clicks on the 'Continue' button to dismiss the welcome popup.
        /// </summary>
        public void ClickOnCancelWelcomePopup()
        {
            this.ClickElement(CancelWelcomePopup);
        }

        /// <summary>
        /// Validates that the 'Attendance' page is opened.
        /// </summary>
        public void ValidateAttendancePageOpens()
        {
            this.WaitForObjectToBeVisible(AttendancePage);
            Assert.That(AttendancePage.Text.Equals("Attendance"));
        }

        /// <summary>
        /// Clicks on the back button on the 'Attendance' page.
        /// </summary>
        public void ClickOnAttendanceBack()
        {
            this.ClickElement(AttendanceBack);
        }

        /// <summary>
        /// Clicks on the 'Forgot Password' link.
        /// </summary>
        public void ClickOnForgotPassword()
        {
            this.ClickElement(ForgotPassword);
        }

        /// <summary>
        /// Clicks on the 'Reset' button in the password reset flow.
        /// </summary>
        public void ClickOnResetBtn()
        {
            this.ClickElement(ResetBtn);
        }

        /// <summary>
        /// Enters the email address into the email input field in the password reset flow.
        /// </summary>
        /// <param name="email">The email address to be entered.</param>
        public void EnterEmailField(string email)
        {
            this.EnterText(EmailField, email);            
        }

        /// <summary>
        /// Clicks on the 'Send' button in the password reset flow.
        /// </summary>
        public void ClickOnSendBtn()
        {
            this.ClickElement(SendBtn);
        }

        /// <summary>
        /// Clicks on the 'Close' button to close the login screen.
        /// </summary>
        public void ClickOnCloseBtn()
        {
            this.ClickElement(CloseBtn);
        }
    }
}
