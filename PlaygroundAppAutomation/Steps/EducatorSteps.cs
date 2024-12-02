using Mailosaur;
using Mailosaur.Models;
using MobileAutomation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using System.Threading.Tasks;

namespace MobileAutomation.Steps
{
    class EducatorSteps : BaseSteps
    {
        private AppiumDriver<AppiumWebElement> _driver;
        private EducatorLoginPage educatorLoginPage;
        private TestData testData;
        private UserData user;
        // Mailosaur configuration
        string apiKey = "SgXvirX78YgB1eNU0cfnCLMvs8oGz0qx";
        string serverId = "xliwjpak";
        string serverDomain = $"serverId.mailosaur.net";

        /// <summary>
        /// Initializes a new instance of the HomeSteps class.
        /// </summary>
        public EducatorSteps(AppiumDriver<AppiumWebElement> driver)
        {
            _driver = driver;
            educatorLoginPage = new EducatorLoginPage(_driver);
        }

        /// <summary>
        /// Validate educator login functionality.
        /// </summary>
        /// <param name="username">varibale for username</param>
        /// <param name="password">variable for password</param>
        public void ValidateEducatorLogin()
        {
            testData = JsonUtil.GetTestData();
            var user = testData.UserData[0];
            educatorLoginPage.ClickOnRoomFirst();
            educatorLoginPage.ClickOnAddEducator();
            educatorLoginPage.EnterEducatorPhoneOrEmail(user.EduUser);
            educatorLoginPage.EnterEducatorPassOrPin(user.EduPin);
            if(MobileDriver.IsIOS)
            {
                educatorLoginPage.PressReturnKey();
            }
            else
            {
                MobileDriver.Driver.HideKeyboard();
            }
            educatorLoginPage.ClickOnEducatorLoginBtn();
            educatorLoginPage.ValidateAttendancePageOpens();
        }

        /// <summary>
        /// Validate educator login functionality.
        /// </summary>
        /// <param name="Email">varibale for username</param>
        /// <param name="Password">variable for password</param>
        public void ValidateEducatorLoginWithEmailAndPassword()
        {
            Task.Delay(5000).Wait();
            testData = JsonUtil.GetTestData();
            var user = testData.UserData[0];
            educatorLoginPage.ClickOnRoomFirst();
            educatorLoginPage.ClickOnAddEducator();
            educatorLoginPage.EnterEducatorPhoneOrEmail(user.EduEmail);
            educatorLoginPage.EnterEducatorPassOrPin(user.EduPass);
            if (MobileDriver.IsIOS)
            {
                educatorLoginPage.PressReturnKey();
            }
            else
            {
                MobileDriver.Driver.HideKeyboard();
            }
            educatorLoginPage.ClickOnEducatorLoginBtn();
            educatorLoginPage.ValidateAttendancePageOpens();
        }

        public void VerifyEducatorLogin()
        {
            testData = JsonUtil.GetTestData();
            var user = testData.UserData[0];
            educatorLoginPage.ClickOnAddEducator();
            educatorLoginPage.EnterEducatorPhoneOrEmail(user.EduEmail);
            educatorLoginPage.EnterEducatorPassOrPin(user.EduPass);
            if (MobileDriver.IsIOS)
            {
                educatorLoginPage.PressReturnKey();
            }
            else
            {
                MobileDriver.Driver.HideKeyboard();
            }
            educatorLoginPage.ClickOnEducatorLoginBtn();
        }

        /// <summary>
        /// Validate educator login functionality.
        /// </summary>
        /// <param name="Email">varibale for username</param>
        /// <param name="Password">variable for password</param>
        public void ValidateLoginForEducator()
        {
            Task.Delay(5000).Wait();
            testData = JsonUtil.GetTestData();
            var user = testData.UserData[0];
            educatorLoginPage.ClickOnRoomSecond();
            educatorLoginPage.ClickOnAddEducator();
            educatorLoginPage.EnterEducatorPhoneOrEmail(user.EduEmail);
            educatorLoginPage.EnterEducatorPassOrPin(user.EduPass);
            if (MobileDriver.IsIOS)
            {
                educatorLoginPage.PressReturnKey();
            }
            else
            {
                MobileDriver.Driver.HideKeyboard();
            }
            educatorLoginPage.ClickOnEducatorLoginBtn();
            educatorLoginPage.ValidateAttendancePageOpens();
        }

        /// <summary>
        /// Validate Forgot password functionality
        /// </summary>
        public void ValidateForgotPassword()
        {
            MailosaurClient mailosaurClient = new MailosaurClient(apiKey);                    
            string emailAddress = "outline-fort@xliwjpak.mailosaur.net";
            educatorLoginPage.ClickOnRoomFirst();
            educatorLoginPage.ClickOnAddEducator();
            educatorLoginPage.ClickOnForgotPassword();
            if(MobileDriver.IsAndroid)
            {
                educatorLoginPage.ClickOnResetBtn();
            }
            
            educatorLoginPage.EnterEmailField(emailAddress);
            if(MobileDriver.IsAndroid)
            {
                MobileDriver.Driver.HideKeyboard();
            }
            educatorLoginPage.ClickOnSendBtn();
            // Fetch the email from Mailosaur
            var criteria = new SearchCriteria()
            {
                SentTo = emailAddress
            };
            var email = mailosaurClient.Messages.Get(serverId, criteria, 5000);
            if (email.Subject.Contains("Xplor Password Reset"))
            {
                Assert.IsTrue(true);
            }
        }

    }
}
