using OpenQA.Selenium.Appium;
using NSelene;
using OpenQA.Selenium;
using MobileAutomation.Tools;
using NUnit.Framework;
using System;

namespace MobileAutomation.PageObjects
{
    class LoginPage : BasePage
    {
        /// <summary>
        /// Initializes a new instance of the LoginPage class.
        /// </summary>
        public LoginPage(AppiumDriver<AppiumWebElement> driver) : base(driver) { }

        /// <summary>
        /// Selector for Email input field.
        /// </summary>
        public SeleneElement EmailField => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/txtUsername"), MobileBy.AccessibilityId("service-username"));

        /// <summary>
        /// Selector for Password input field.
        /// </summary>
        public SeleneElement PasswordlField => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/txtPassword"), MobileBy.AccessibilityId("service-password"));

        /// <summary>
        /// Selector for Sign In button.
        /// </summary>
        public SeleneElement SignInButton => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnLogin"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Log in\"]"));

        /// <summary>
        /// Selector for Dashboard title.
        /// </summary>
        public SeleneElement Dashboard => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/title_text_view"), MobileBy.AccessibilityId("Automation_Service_1 ?"));

        /// <summary>
        /// Selector for Service Sign In option.
        /// </summary>
        public SeleneElement ServiceSignIn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Service Sign in']"), MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == \"Service Sign In\"`][2]"));

        /// <summary>
        /// Selector for Admin Sign In option.
        /// </summary>
        public SeleneElement AdminSignIn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Admin Sign in']"), MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == \"Admin Sign in\"`][2]"));

        /// <summary>
        /// Selector for Australia & New Zealand region option.
        /// </summary>
        public SeleneElement SelectRegionAU => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Australia & New Zealand']"), MobileBy.AccessibilityId("Australia & New Zealand"));

        /// <summary>
        /// Selector for United Kingdom region option.
        /// </summary>
        public SeleneElement SelectRegionUK => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='United Kingdom']"), MobileBy.AccessibilityId("United Kingdom"));

        /// <summary>
        /// Selector for region submit button.
        /// </summary>
        public SeleneElement RegionSelectSubmitBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.playground.staging:id/btnConfirm"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Confirm\"]"));

        /// <summary>
        /// Selector for region title text.
        /// </summary>
        public SeleneElement RegionTitle => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Service Sign in AU/NZ']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Service Sign in AU/NZ\"]"));


        /// <summary>
        /// Enter username
        /// </summary>
        public void EnterUsername(string username)
        {
            this.WaitForObjectToBeVisible(EmailField);
            this.EnterText(EmailField, username);
        }

        /// <summary>
        /// Enter password.
        /// </summary>
        public void EnterPassword(string password)
        {
            this.WaitForObjectToBeVisible(PasswordlField);
            this.EnterText(PasswordlField, password);
            
        }

        /// <summary>
        /// Click on Sign In button.
        /// </summary>
        public void ClickSignInBtn()
        {
            this.ClickElement(SignInButton);
        }

        /// <summary>
        /// Click on AU Region checkbox.
        /// </summary>
        private void SelectAURegionSelector()
        {
            this.ClickElement(SelectRegionAU);
        }

        /// <summary>
        /// Click on Region submit button.
        /// </summary>
        private void ClickRegionSubmitBtn()
        {
            this.ClickElement(RegionSelectSubmitBtn);
        }

        /// <summary>
        /// Validate Sign In button is visible.
        /// </summary>
        public bool IsSignInButtonDisplayed()
        {
            try
            {
                return SignInButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Validate Region title is visible or not.
        /// </summary>
        public bool IsRegionTitleDisplayed
        {
            get
            {
                try
                {
                    return RegionTitle.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (TimeoutException)
                {
                    return false;
                }                
            }
        }
        public void LoginWithoutRegionSelector(string username, string password)
        {
            this.WaitForElementToBeVisible(EmailField);
            this.EnterUsername(username);
            this.EnterPassword(password);
            this.ClickSignInBtn();
        }

        public void LoginWithRegionSelector(string username, string password)
        {
            this.SelectAURegion();
            this.EnterUsername(username);
            this.EnterPassword(password);
            this.ClickSignInBtn();
        }

        /// <summary>
        /// Validate User is able to select AU/NZ region.
        /// </summary>
        public void SelectAURegion()
        {
            this.SelectAURegionSelector();
            this.ClickRegionSubmitBtn();
        }

        /// <summary>
        /// Validate Sign In page is displayed.
        /// </summary>
        public void ValidateSignInPageDisplayed()
        {
            this.WaitForElementToBeVisible(RegionTitle);
            string actualTitleText = GetElementText(RegionTitle);
            string expectedText = "Service Sign in AU/NZ";
            Assert.That(actualTitleText, Is.EqualTo(expectedText));            
        }
    }
}
