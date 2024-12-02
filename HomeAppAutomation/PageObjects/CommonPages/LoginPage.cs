using OpenQA.Selenium.Appium;
using NSelene;
using OpenQA.Selenium;
using HomeAppAutomations.Tools;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace HomeAppAutomations.PageObjects
{
    class LoginPage : BasePage
    {
        public LoginPage(AppiumDriver<AppiumWebElement> driver) : base(driver) { }
        public SeleneElement usernameField => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tiEmail"), MobileBy.IosClassChain("**/XCUIElementTypeTextField[`value == \"Email\"`]"));
        public SeleneElement LoginAURegionTitle => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvHeaderTitle"), MobileBy.AccessibilityId("Login AU/NZ"));
        public SeleneElement LoginUKRegionTitle => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvHeaderTitle"), MobileBy.AccessibilityId("Login UK"));
        public SeleneElement passwordField => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tiPassword"), MobileBy.IosClassChain("**/XCUIElementTypeSecureTextField[`value == \"Password\"`]"));
        public SeleneElement loginButton => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/btnOnboardingLogin"), By.XPath("//XCUIElementTypeButton[@name=\"Log In\"]"));
        public SeleneElement loginUserBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/btnLogin"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Login\"]"));
        public SeleneElement versionLabel => GetPlatformSpecificElement(MobileBy.Id("Version-label"), MobileBy.AccessibilityId("Automation_Service_1 ?"));
        public SeleneElement emptyErrorLabel => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@resource-id=\"com.xplor.home.staging:id/textinput_error\"]"), MobileBy.AccessibilityId("Invalid username/password"));
        public SeleneElement wrongCredentialsErrorLabel => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvLoginDescriptionText"), MobileBy.AccessibilityId("Wrong credentials. Try again or press forgot password or pin to reset it."));
        public SeleneElement SkipBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvOnboardingSkip"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Skip\"]"));
        public SeleneElement Dismiss => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/secondary_button"), MobileBy.AccessibilityId("Dismiss"));
        public SeleneElement SelectRegionAU => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Australia & New Zealand']"), MobileBy.AccessibilityId("Australia & New Zealand"));
        public SeleneElement SelectRegionUK => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='United Kingdom']"), MobileBy.AccessibilityId("United Kingdom"));
        public SeleneElement RegionSelectSubmitBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/btnConfirm"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Confirm\"]"));
        public SeleneElement AcceptAlert => GetElementByAccessibilityId("Allow");
        public void AcceptAlerts()
        {
            Task.Delay(3000).Wait();
            this.ClickElement(AcceptAlert);
        }
       
        public void TypeUsername(string username)
        {
            this.EnterText(usernameField, username);
        }
        public void TypePassword(string password)
        {
            this.EnterText(passwordField, password);
        }
        public void ClickLoginButton()
        {
            this.ClickElement(loginButton);
        }
        public void ClickLoginUserButton()
        {
            this.ClickElement(loginUserBtn);
        }
        public void ClickSkipButton()
        {
            this.ClickElement(SkipBtn);
        }
        public void ClickDismissButton()
        {
            this.ClickElement(Dismiss);
        }
        public void SelectAuRegion()
        {
            this.ClickElement(SelectRegionAU);
        }
        public void SelectUKRegion()
        {
            this.ClickElement(SelectRegionUK);
        }
        public void ClickRegionSelectSubmitBtn()
        {
            this.ClickElement(RegionSelectSubmitBtn);
        }

        public void ValidateAURegionLoginPageTitle()
        {
            this.WaitForElementToBeClickable();
            string actualTitle = GetElementText(LoginAURegionTitle);
            string expectedTitle = "Login AU/NZ";
            Assert.AreEqual(expectedTitle, actualTitle, "Login AU/NZ title is not displayed");
        }

        public void ValidateUKRegionLoginPageTitle()
        {
            this.WaitForElementToBeClickable();
            string actualTitle = GetElementText(LoginUKRegionTitle);
            string expectedTitle = "Login UK";
            Assert.AreEqual(expectedTitle, actualTitle, "Login UK title is not displayed");
        }
        public void ValidateLoginFailedAndDisplayErrorMessage()
        {
            this.WaitForElementToBeClickable();
            string emptyErrorLbl= GetElementText(wrongCredentialsErrorLabel);
            string expectedErrorLbl = LoginConstants.InvalidCredError;
            Assert.AreEqual(expectedErrorLbl, emptyErrorLbl, "Empty error label is not displayed");           
        }

        public void ValidateLoginFailedWithEmptyUsername()
        {
            this.WaitForElementToBeClickable();
            string emptyErrorLbl = GetElementText(emptyErrorLabel);
            string expectedErrorLbl = LoginConstants.EmptyError;
            if(MobileDriver.IsIOS)
            {
                Assert.AreEqual(expectedErrorLbl, emptyErrorLbl, "Empty error label is not displayed");
            }
            else
            {
                Assert.AreEqual("Required", emptyErrorLbl, "Empty error label is not displayed");
            }            
        }
    }

    public class LoginConstants
    {
        public LoginConstants() { }
        public const string InvalidCredError = "Wrong credentials. Try again or press forgot password or pin to reset it.";  
        public const string EmptyError = "Invalid username/password";
    }
}
