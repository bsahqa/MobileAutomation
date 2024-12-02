using log4net;
using NUnit.Framework;
using HomeAppAutomations.Steps;
using HomeAppAutomation.PageObjects;
using HomeAppAutomations;
using HomeAppAutomations.Tests;

namespace HomeAppAutomation.Tests
{
    [TestFixture]
    class SmokeTestsNewBookingFlow : BaseTest
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SmokeTestsNewBookingFlow));
        LoginSteps loginStep = new LoginSteps(MobileDriver.Driver);
        BookingPage bookingPage = new BookingPage(MobileDriver.Driver);

        [SetUp]
        public void LogInApplication()
        {
            LoggerHelper.Log(log, _test, "Test Started---->" + TestContext.CurrentContext.Test.Name);

        }

        [Test]
        [Category("Smoke")]
        [Description("Verify login functionality")]
        public void VerifyUKParentLogin()
        {
            loginStep.VerifyUKParentLogin();
            loginStep.ValidateParentLoginFunctionality();
            LoggerHelper.Log(log, _test, "Parent logged in successfully");
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify casual booking functionality")]
        public void VerifyCasualBookingFunctionality()
        {
            loginStep.VerifyNewParentLogin();
            bookingPage.ClickOnBookingsTab();
            LoggerHelper.Log(log, _test, "Clicked on Booking tab");
            bookingPage.ClickOnNewBtn();
            LoggerHelper.Log(log, _test, "Clicked on New booking button");
            bookingPage.ClickOnBookingBtn();
            LoggerHelper.Log(log, _test, "Clicked on Booking button");
            bookingPage.ClickOnSelectChild();
            LoggerHelper.Log(log, _test, "Clicked on Select Child");
            bookingPage.ClickOnChildren();
            LoggerHelper.Log(log, _test, "Clicked on Chidren Name");
            bookingPage.ClickOnSelectSession();
            LoggerHelper.Log(log, _test, "Clicked on Select Session");
            bookingPage.ClickOnSession();
            LoggerHelper.Log(log, _test, "Clicked on Session");
            bookingPage.ClickOnCasual();
            LoggerHelper.Log(log, _test, "Clicked on casual radio btn");
            bookingPage.ClickOnSelectDate();
            LoggerHelper.Log(log, _test, "Clicked on Select date");
            bookingPage.ClickOnDate();
            LoggerHelper.Log(log, _test, "Clicked on current date");
            bookingPage.ClickOnSaveDateBtn();
            LoggerHelper.Log(log, _test, "Clicked on Save button");
            bookingPage.ClickOnReviewBtn();
            LoggerHelper.Log(log, _test, "Clicked on Review button");
            bookingPage.ClickOnConfirmBtn();
            LoggerHelper.Log(log, _test, "Clicked on Confirm button");
            bookingPage.ValidateNewBookingPopupDisplayed();
            LoggerHelper.Log(log, _test, "Booking request is created successfully");
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify recurring booking functionality")]
        public void VerifyRecuringBookingFunctionality()
        {

            loginStep.VerifyNewParentLogin();
            bookingPage.ClickOnBookingsTab();
            LoggerHelper.Log(log, _test, "Clicked on Booking tab");
            bookingPage.ClickOnNewBtn();
            LoggerHelper.Log(log, _test, "Clicked on New booking button");
            bookingPage.ClickOnBookingBtn();
            LoggerHelper.Log(log, _test, "Clicked on Booking button");
            bookingPage.ClickOnSelectChild();
            LoggerHelper.Log(log, _test, "Clicked on Select Child");
            bookingPage.ClickOnChildren();
            LoggerHelper.Log(log, _test, "Clicked on Chidren Name");
            bookingPage.ClickOnSelectSession();
            LoggerHelper.Log(log, _test, "Clicked on Select Session");
            bookingPage.ClickOnSession();
            bookingPage.ClickOnRecurring();
            LoggerHelper.Log(log, _test, "Clicked on casual radio btn");
            bookingPage.ClickOnSelectDate();
            LoggerHelper.Log(log, _test, "Clicked on Select date");
            bookingPage.SelectStartDate();
            bookingPage.SelectEndDate();
            bookingPage.SelectAllDays();
            if(MobileDriver.IsAndroid)
            {
                bookingPage.ScrollDownHalfScreen();
            }
            bookingPage.ClickOnSaveDateBtn();
            LoggerHelper.Log(log, _test, "Clicked on Save button");
            if (MobileDriver.IsAndroid)
            {
                bookingPage.ScrollDownHalfScreen();
            }
            bookingPage.ClickOnReviewBtn();
            LoggerHelper.Log(log, _test, "Clicked on Review button");
            bookingPage.ClickOnConfirmBtn();
            LoggerHelper.Log(log, _test, "Clicked on Confirm button");
            bookingPage.ValidateNewBookingPopupDisplayed();
            LoggerHelper.Log(log, _test, "Booking request is created successfully");
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Parent can cancel booking")]
        public void VerifyParentCanCancelBooking()
        {
            loginStep.VerifyNewParentLogin();
            bookingPage.ClickOnBookingsTab();
            LoggerHelper.Log(log, _test, "Clicked on Booking tab");
            bookingPage.ClickOnNewBtn();
            LoggerHelper.Log(log, _test, "Clicked on New booking button");
            bookingPage.ClickOnCancellationBtn();
            LoggerHelper.Log(log, _test, "Clicked on Cancellation button");
            bookingPage.ClickOnSelectChild();
            LoggerHelper.Log(log, _test, "Clicked on Select Child");
            bookingPage.ClickOnChildren();
            LoggerHelper.Log(log, _test, "Clicked on Chidren Name");
            bookingPage.ClickOnCancelStartDate();
            bookingPage.ClickOnCancelEndDate();
            bookingPage.SelectAllDays();
            if (MobileDriver.IsAndroid)
            {
                bookingPage.ScrollDownHalfScreen();
            }
            bookingPage.SelectAvailableSessions();
            LoggerHelper.Log(log, _test, "Clicked on Select Session");
            bookingPage.ClickOnSession();
            bookingPage.ClickOnSaveDateBtn();
            LoggerHelper.Log(log, _test, "Clicked on Save button");
            if (MobileDriver.IsAndroid)
            {
                bookingPage.ScrollDownHalfScreen();
            }
            bookingPage.ClickOnReviewBtn();
            LoggerHelper.Log(log, _test, "Clicked on Review button");
            bookingPage.ClickOnConfirmBtn();
            LoggerHelper.Log(log, _test, "Clicked on Confirm button");
            bookingPage.ValidateNewBookingPopupDisplayed();
            LoggerHelper.Log(log, _test, "Booking request is created successfully");

        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Parent can cancel single booking")]
        public void VerifyParentCanCancelSingleBooking()
        {
            loginStep.VerifyNewParentLogin();
            bookingPage.ClickOnBookingsTab();
            LoggerHelper.Log(log, _test, "Clicked on Booking tab");
            bookingPage.ClickOnChildName();
            LoggerHelper.Log(log, _test, "Clicked on Child Name");
            bookingPage.ClickOnCancelBooking();
            LoggerHelper.Log(log, _test, "Clicked on Cancel Booking");
            bookingPage.ClickOnReviewCancel();
            LoggerHelper.Log(log, _test, "Clicked on Review Cancel");
            bookingPage.ClickOnConfirmBtn();
            LoggerHelper.Log(log, _test, "Clicked on Confirm button");
            bookingPage.ValidateCancelBookingPopupDisplayed();
            LoggerHelper.Log(log, _test, "Booking request is cancelled successfully");

        }

        [TearDown]
        public void DisposeDriver()
        {
            LoggerHelper.Log(log, _test, "Test Ended---->" + TestContext.CurrentContext.Test.Name);
        }
    }
}
