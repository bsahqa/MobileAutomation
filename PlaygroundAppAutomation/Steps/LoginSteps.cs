using MobileAutomation.PageObjects;
using OpenQA.Selenium.Appium;
using System;

namespace MobileAutomation.Steps
{
    class LoginSteps : BaseSteps
    {
        private AppiumDriver<AppiumWebElement> _driver;
        private LoginPage loginPage;
        private HomePage homePage;
        
        /// <summary>
        /// Initializes a new instance of the LoginSteps class.
        /// </summary>
        public LoginSteps(AppiumDriver<AppiumWebElement> driver)
        {
            _driver = driver;
            loginPage = new LoginPage(_driver);
            homePage = new HomePage(_driver);
        }

        /// <summary>
        /// Validates the region selector for AU region and checks if the Sign In page is displayed.
        /// </summary>
        public void ValidateRegionSelectorForAURegion()
        {
            loginPage.SelectAURegion();
            loginPage.ValidateSignInPageDisplayed();
        }

        /// <summary>
        /// Verify login functionality.
        /// </summary>
        public void ValidateLogin(string username, string pass)
        {
            if (MobileDriver.IsIOS)
            {
                if(loginPage.IsRegionTitleDisplayed)
                {
                    try
                    {
                        loginPage.LoginWithoutRegionSelector(username, pass);                        
                    }
                    catch(TimeoutException)
                    {
                        loginPage.LoginWithoutRegionSelector(username, pass);                        
                    }
                   
                }
                else
                {
                    loginPage.LoginWithRegionSelector(username, pass);                    
                }                              
            }
            else
            {
                loginPage.LoginWithRegionSelector(username, pass);                
            }           
        }

        /// <summary>
        /// Validate logout functionality
        /// </summary>
        public void ValidateLogout()
        {
            homePage.ClickOnHeaderDashboardTitle();
            if(MobileDriver.IsAndroid)
            {
                homePage.ClickOnLogoutButton();
            }
            loginPage.ValidateSignInPageDisplayed();
        }

    }
}
