using HomeAppAutomation.PageObjects.CommonPages;
using HomeAppAutomations.PageObjects;
using OpenQA.Selenium.Appium;
using System;

namespace HomeAppAutomations.Steps
{
    class LoginSteps : BaseSteps
    {
        private AppiumDriver<AppiumWebElement> _driver;
        private LoginPage loginPage;
        private HomePage homePage;
        private TestData testData;

        /// <summary>
        /// Initializes a new instance of the LoginSteps class.
        /// </summary>
        public LoginSteps(AppiumDriver<AppiumWebElement> driver)
        {
            _driver = driver;
            loginPage = new LoginPage(_driver);   
            homePage = new HomePage(_driver);
        }

        public void OpenAURegionLoginPage()
        {
            loginPage.ClickSkipButton();
            loginPage.ClickLoginButton();
            loginPage.SelectAuRegion();
            loginPage.ClickRegionSelectSubmitBtn();
            loginPage.ValidateAURegionLoginPageTitle();
        }

        public void OpenUKRegionLoginPage()
        {
            loginPage.ClickSkipButton();
            loginPage.ClickLoginButton();
            loginPage.SelectUKRegion();
            loginPage.ClickRegionSelectSubmitBtn();
            loginPage.ValidateUKRegionLoginPageTitle();
        }

        public void VerifyParentLogin()
        {
            testData = JsonUtil.GetTestData();
            var user = testData.UserData[0];
            this.OpenAURegionLoginPage();
            loginPage.TypeUsername(user.Username);
            loginPage.TypePassword(user.Password);
            MobileDriver.Driver.HideKeyboard();
            loginPage.ClickLoginUserButton();
            if(MobileDriver.IsIOS)
            {
                loginPage.AcceptAlerts();
            }            
        }

        public void VerifyUKParentLogin()
        {
            testData = JsonUtil.GetTestData();
            var user = testData.UserData[0];
            this.OpenUKRegionLoginPage();
            loginPage.TypeUsername(user.UKUsername);
            loginPage.TypePassword(user.UKPassword);
            MobileDriver.Driver.HideKeyboard();
            loginPage.ClickLoginUserButton();
            if (MobileDriver.IsIOS)
            {
                loginPage.AcceptAlerts();
            }
        }

        public void VerifyNewParentLogin()
        {
            testData = JsonUtil.GetTestData();
            var user = testData.UserData[0];
            this.OpenAURegionLoginPage();
            loginPage.TypeUsername(user.NewUser);
            loginPage.TypePassword(user.NewPass);
            MobileDriver.Driver.HideKeyboard();
            loginPage.ClickLoginUserButton();
            if (MobileDriver.IsIOS)
            {
                loginPage.AcceptAlerts();
            }
        }

        public bool IsLogout
        {
            get
            {
                try
                {
                    return loginPage.SkipBtn.Displayed;

                }
                catch (TimeoutException)
                {
                    return false;
                }
            }
        }

        public void ValidateParentLoginFunctionality()
        {
            homePage.ValidateParentSingedInSuccessfully();
        }

        public void ValidateInvalidParentLogin()
        {
            testData = JsonUtil.GetTestData();
            var user = testData.UserData[0];
            loginPage.TypeUsername(user.InvalidUser);
            loginPage.TypePassword(user.InvalidPass);
            MobileDriver.Driver.HideKeyboard();
            loginPage.ClickLoginUserButton();
            loginPage.ValidateLoginFailedAndDisplayErrorMessage();
        }

        public void ValidateInvalidParentLoginWithEmptyUsername()
        {
            testData = JsonUtil.GetTestData();
            var user = testData.UserData[0];
            loginPage.TypePassword(user.InvalidPass);
            MobileDriver.Driver.HideKeyboard();
            loginPage.ClickLoginUserButton();
            loginPage.ValidateLoginFailedWithEmptyUsername();
        }



    }
}
