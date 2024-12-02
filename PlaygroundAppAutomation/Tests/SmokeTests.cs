using log4net;
using MobileAutomation.PageObjects;
using MobileAutomation.Steps;
using MobileAutomation.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Appium;
using System;

namespace MobileAutomation.Tests
{
    [TestFixture]
    public class SmokeTests : BaseTest
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SmokeTests));
        LoginSteps loginStep = new LoginSteps(MobileDriver.Driver);
        HomeSteps homeStep = new HomeSteps(MobileDriver.Driver);
        EducatorSteps educatorStep = new EducatorSteps(MobileDriver.Driver);
        AttendanceStep attendanceStep = new AttendanceStep(MobileDriver.Driver);
        HealthStep healthStep = new HealthStep(MobileDriver.Driver);
        TransportListSteps transportStep = new TransportListSteps(MobileDriver.Driver);
        EmergencyListSteps emergencyListStep = new EmergencyListSteps(MobileDriver.Driver);
        HeadCountSteps headCountStep = new HeadCountSteps(MobileDriver.Driver);
        IncidentRecordSteps incidentRecordStep= new IncidentRecordSteps(MobileDriver.Driver);
        MessengerSteps messengerSteps = new MessengerSteps(MobileDriver.Driver);
        LearningSteps learningSteps = new LearningSteps(MobileDriver.Driver);
        HelpAndSupportSteps helpStep= new HelpAndSupportSteps(MobileDriver.Driver);
        private bool isLoggedin = false;
        private TestData testData;
        private UserData user;

       /* [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            testData = JsonUtil.GetTestData();
            var user = testData.UserData[0];
            if (!isLoggedin)
            {
                loginStep.ValidateLogin(user.ServiceUser, user.ServicePass);
                isLoggedin = true;
            }
        }*/

        [SetUp]
        public void LogInApplication()
        {
            testData = JsonUtil.GetTestData();
            var user = testData.UserData[0];
            LoggerHelper.Log(log, _test, "Test Started---->" + TestContext.CurrentContext.Test.Name);
            loginStep.ValidateLogin(user.ServiceUser, user.ServicePass);

            /*if (IsUserLogout)
            {
                loginStep.ValidateLogin(user.ServiceUser, user.ServicePass);
            }*/
        }

        [Test]
		[Category ("Smoke")]
        [Description("Verify All button on dashboard")]
        public void VerifyAllButtonIsPresentOnDashboard()
		{
            homeStep.ValidateAllButtonIsPresentOnHomePage();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Educator login functionality with Mobile and Pin")]
        public void VerifyEducatorLoginFunctionality()
        {
            educatorStep.ValidateEducatorLogin();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Educator login functionality with Email and Password")]
        public void VerifyEducatorLoginWithEmailAndPassword()
        {
            educatorStep.ValidateEducatorLoginWithEmailAndPassword();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Login functionality")]
        public void VerifyLoginFunctionality()
        {
            homeStep.VerifyDashboardDisplayed();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify forgot password functionality")]
        public void VerifyForgotEducatorPasswordFunctionality()
        {
            educatorStep.ValidateForgotPassword();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Children signed in functionality on attendace page")]
        public void VerifyChildrenSignedInFunctionalityOnAttendacePage()
        {
            educatorStep.ValidateEducatorLogin();
            attendanceStep.ValidateChildrenSignIn();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Children absent functionality on attendace page")]
        public void VerifyZChildrenAbsenceFunctionalityOnAttendacePage()
        {
            educatorStep.ValidateEducatorLogin();
            attendanceStep.ValidateChildrenAbsence();            
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Select all and Deselect all functionality on attendace page")]
        public void VerifySelectAllAndDeselectAllFunctionalityOnAttendacePage()
        {
            educatorStep.ValidateEducatorLogin();
            attendanceStep.ValidateSelectAllAndDeselectAllFunctionality();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Children search functionality on attendace page")]
        public void VerifyChildrenSearchFunctionalityOnAttendacePage()
        {
            educatorStep.ValidateEducatorLogin();
            attendanceStep.ValidateSearchChildrenFunctionality();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Children Signed In and Signed out from headcount")]
        public void VerifyChildrenSignedInAndSignedOutFunctionalityOnAttendacePageFromHeadCount()
        {
            educatorStep.ValidateEducatorLogin();
            attendanceStep.ValidateSignedInAndSignedOutFromHeadCount();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify educator is able to create Nappies event  successsfully")]
        public void VerifyCreateNappiesEventForDryUnderHealth()
        {
            educatorStep.ValidateLoginForEducator();
            healthStep.CreateDryNappiesEventUnderHealth();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify educator is able to create awake event successfully")]
        public void VerifyCreateAwakeEventForSleepingUnderHealth()
        {
            educatorStep.ValidateLoginForEducator();
            healthStep.ValidateCreateAwakeEventUnderHealth();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify educator is able to create sunscreen successfully")]
        public void VerifyCreateSunscreenEventUnderHealth()
        {
            educatorStep.ValidateLoginForEducator();
            healthStep.ValidateCreateSunscreenEventUnderHealth();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify educator is able to create  Nutrition events")]
        public void VerifyNutritionEventWithAppleFoodUnderHealth()
        {
            educatorStep.ValidateLoginForEducator();
            healthStep.CreateNutritionEventWithAppleUnderHealth();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify user is able to create new and submit transport list with children pickup and dropoff")]
        public void VerifyEducatorCanCreateTransportListWithChildrenPickupAndDropoff()
        {
            transportStep.ValidateTransportListFunctionality();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify user is able to create emergency list as Evacuation drill")]
        public void VerifyCreateEmergencyListAsEvacuationDrill()
        {
            emergencyListStep.CreateEmergencyListAsEvacuationDrill();
        }
        [Test]
        [Category("Smoke")]
        [Description("Verify user is able to create emergency list as Lockdown drill")]
        public void VerifyCreateEmergencyListAsLockdownDrill()
        {
            emergencyListStep.CreateEmergencyListAsLockdown();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify user is able to sign in new Head Count")]
        public void VerifyHeadCountSignedInFunctionality()
        {
            headCountStep.CreateHeadCountSignedIn();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Incident record page opens successfully")]
        public void VerifyIncidentRecordPageOpenSuccessfully()
        {
            incidentRecordStep.ValidateIncidentRecordPageOpen();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Incident record page opens successfully")]
        public void VerifyMessengerFunctionality()
        {
            messengerSteps.ValidateMessengerFunctionality();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Create Post")]
        public void VerifyCreatePostFromPostsTab()
        {
            learningSteps.ValidateCreatePostFunctionality();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Create Post")]
        public void VerifyCreatePostFromChildrenTab()
        {
            learningSteps.ValidateCreatePostFromChildProfile(); 
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Outcome page loaded")]
        public void VerifyOutcomePageLoaded()
        {
            learningSteps.ValidateOutcomePageLoaded();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify link page loaded")]
        public void VerifyLinksPageLoaded()
        {
            learningSteps.ValidateLinksPageLoaded();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify more page loaded")]
        public void VerifyMorePageLoaded()
        {
            learningSteps.ValidateMorePageLoaded();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify filter option on Children tag")]
        public void VerifyChildrenFilterOptionOnChildrenTag()
        {
            learningSteps.ValidateChildrenFiltersOptionOnhildrenTag();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify filter childrens based on signed in, booked in, default room and All children")]
        public void VerifyChildrenFilterOptionOnChildrenPage()
        {
            learningSteps.ValidateChildrenFiltersOptionOnChildrenPage();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify clicking on Help &Support navigate to Support page")]
        public void VerifyHelpAndSupportPageOpened()
        {
            helpStep.ValidateHelpAndSupportPageOpened();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify logout functionality")]
        [Ignore("Need to fix login issue after logout")]
        public void VerifyLogoutFunctionality()
        {
            loginStep.ValidateLogout();
        }

        [Test]    
        [Category("Smoke")]
        [Description("Verify educator is able to create new incident record")]
        [Ignore("Need to fix signature issue")]
        public void VerifyCreateIncidentRecordFunctionalityUnderHealth()
        {
            educatorStep.ValidateEducatorLogin();
            healthStep.VerifyIncidentCreate();
        }

        [TearDown]
        public void DisposeDriver()
        {
            LoggerHelper.Log(log, _test, "Test Ended---->" + TestContext.CurrentContext.Test.Name);
            //MobileDriver.Driver.CloseApp();
            //MobileDriver.Driver.LaunchApp();
        }
        private bool IsUserLogout
        {
            get
            {
                try
                {
                    LoginPage loginPage = new LoginPage(MobileDriver.Driver);
                    return loginPage.SelectRegionAU.Displayed;
                }
                catch (TimeoutException)
                {
                    return false;
                }
            }
        }       
    }
}