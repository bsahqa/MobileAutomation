using System.Threading;
using HomeAppAutomations.Tools;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;
using log4net.Config;
using log4net;
using HomeAppAutomations.Steps;
using HomeAppAutomation.PageObjects;

namespace HomeAppAutomations.Tests
{
    
    [TestFixture]
    class SmokeTests : BaseTest
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SmokeTests));
        LoginSteps loginStep = new LoginSteps(MobileDriver.Driver);
        CarePage carePage = new CarePage(MobileDriver.Driver);
        BookingPage bookingPage= new BookingPage(MobileDriver.Driver);
        AccountPage accountPage = new AccountPage(MobileDriver.Driver);
        FinancePage financePage = new FinancePage(MobileDriver.Driver);
        private bool isLoggedin = false;

         [SetUp]
        public void LogInApplication()
        {
            LoggerHelper.Log(log, _test, "Test Started---->"+TestContext.CurrentContext.Test.Name);
            loginStep.VerifyParentLogin();            
        }
      
        [Test]
        [Category("Smoke")]
        [Description("Verify login functionality")]
        public void VerifyLoginFunctionality()
        {
            loginStep.ValidateParentLoginFunctionality();
            LoggerHelper.Log(log, _test, "Parent logged in successfully");
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Parent can see the Learning and Heath Journey option on care tab")]
        public void VerifyLearningAndHealthJourneyOptionIsVisibleOnCarePage()
        {
            carePage.ClickOnCareTab();
            LoggerHelper.Log(log, _test, "Clicked on Care tab");
            carePage.ValidateLearningOptionIsVisible();
            LoggerHelper.Log(log, _test, "Learning Option is visible");
            carePage.ValidateHealthJoruneyOptionOptionIsVisible();
            LoggerHelper.Log(log, _test, "Health Journey Option is visible");
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Parent can view the post and download attached media")]
        public void VerifyParentCanViewPostAndDownloadMediaAttachment()
        {
            carePage.ClickOnCareTab();
            LoggerHelper.Log(log, _test, "Clicked on Care tab");
            carePage.ClickOnLearningViewAllBtn();
            LoggerHelper.Log(log, _test, "Clicked on Learning View All button");
            carePage.ClickOnPosts();
            LoggerHelper.Log(log, _test, "Clicked on Existing Post list");
            carePage.ClickOnDownloadMediaBtn();
            LoggerHelper.Log(log, _test, "Clicked on Download Media button");
            carePage.ValidateMediaFileIsDownloaded();
            LoggerHelper.Log(log, _test, "Attached media file is downloaded successfully");
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Post contents on Post view details page")]
        public void VerifyPostContentsOnPostView()
        {
            carePage.OpenPostDetailedPage();
            LoggerHelper.Log(log, _test, "Clicked on Existing Post list");
            carePage.ValidateEducatorNameIsVisible();
            LoggerHelper.Log(log, _test, "Educator Name is visible");
            carePage.ValidatePostTitleIsVisible();
            LoggerHelper.Log(log, _test, "Post title is visible");
            carePage.ValidatePostDescIsVisible();
            LoggerHelper.Log(log, _test, "Post description is visible");
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Post comment like and dislike functionality")]
        public void VerifyPostLikeAndDislikeFunctionality()
        {
            carePage.OpenPostDetailedPage();
            LoggerHelper.Log(log, _test, "Clicked on Existing Post list");
            carePage.ClickOnCommentLikeBtn();
            LoggerHelper.Log(log, _test, "Clicked on Comment Like btn");
            carePage.ValidateCommentIsLikedSuccessfully();
            LoggerHelper.Log(log, _test, "Comment is liked successfully");
            carePage.ClickOnDislikeBtn();
            LoggerHelper.Log(log, _test, "Clicked on comment dislike button");
            carePage.ValidateCommentIsDislikedSuccessfully();
            LoggerHelper.Log(log, _test, "Comment is disliked successfully");
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Parent is able to comment on post")]
        public void VerifyParentCanCommentOnPost()
        {
            carePage.OpenPostDetailedPage();
            LoggerHelper.Log(log, _test, "Clicked on Existing Post list");
            carePage.ScrollDownToElement("Love");
            LoggerHelper.Log(log, _test, "Scroll to comment field");
            carePage.TypeComment();
            LoggerHelper.Log(log, _test, "Typed text in comment input box");
            carePage.ClickOnCommentPostBtn();
            LoggerHelper.Log(log, _test, "Clicked on comment post button");
            carePage.ValidateCommentIsPostedSuccessfully();
            LoggerHelper.Log(log, _test, "Comment is posted and displaying successfully");
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Parent can able to open the attached documents")]
        public void VerifyParentCanOpenAttachedDocument()
        {
            carePage.OpenPostDetailedPage();
            LoggerHelper.Log(log, _test, "Clicked on Existing Post list");
            carePage.ClickOnAttachment();
            LoggerHelper.Log(log, _test, "Clicked on attachment");
            carePage.ValidateDocumentOpended();
            LoggerHelper.Log(log, _test, "Document is opened successfully");            
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Parent can able to open the attached documents")]
        public void VerifyParentIsAbleToDoBookingRequest()
        {
            bookingPage.ClickOnBookingsTab();
            LoggerHelper.Log(log, _test, "Clicked on Booking tab");
            bookingPage.ClickOnNewBtn();
            LoggerHelper.Log(log, _test, "Clicked on New booking button");
            bookingPage.ClickOnNewBooking();
            LoggerHelper.Log(log, _test, "Clicked on Booking button");
            bookingPage.ClickOnRequestSpace();
            LoggerHelper.Log(log, _test, "Clicked on request space");
            bookingPage.SelectBookingTime();
            LoggerHelper.Log(log, _test, "Time selected");
            bookingPage.ClickOnSaveBtn();
            LoggerHelper.Log(log, _test, "Clicked on Save button");
            bookingPage.ValidateSpaceRequestedDisplayed();
            LoggerHelper.Log(log, _test, "Space requested label displayed");
            bookingPage.ClickOnMyCartIcon();
            LoggerHelper.Log(log, _test, "Clicked on My cart icon");
            bookingPage.ClickOnRequestBtn();
            LoggerHelper.Log(log, _test, "Clicked on Request button");
            bookingPage.ValidateBookingIsConfirmed();
            LoggerHelper.Log(log, _test, "Booking is confirmed");
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Parent can able to mark the Absence ")]
        public void VerifyParentIsAbleToMarkChildrenAbsentRequest()
        {
            bookingPage.ClickOnBookingsTab();
            LoggerHelper.Log(log, _test, "Clicked on Booking tab");
            bookingPage.ClickOnNewBtn();
            LoggerHelper.Log(log, _test, "Clicked on New booking button");
            bookingPage.ClickOnAbsenseHoliday();
            LoggerHelper.Log(log, _test, "Clicked on Absence button");
            bookingPage.ClickOnAbsenceBtn();
            LoggerHelper.Log(log, _test, "Clicked on Absence tab");
            bookingPage.ClickOnRequestBtn();
            LoggerHelper.Log(log, _test, "Clicked on Request button");
            bookingPage.ValidateChildrenIsMarkedAsAbsent();
            LoggerHelper.Log(log, _test, "Children is marked as absent");
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Parent can able to mark the Holiday")]
        public void VerifyParentIsAbleToMarkChildrenHolidayRequest()
        {
            bookingPage.ClickOnBookingsTab();
            LoggerHelper.Log(log, _test, "Clicked on Booking tab");
            bookingPage.ClickOnNewBtn();
            LoggerHelper.Log(log, _test, "Clicked on New booking button");
            bookingPage.ClickOnAbsenseHoliday();
            LoggerHelper.Log(log, _test, "Clicked on Holiday button");
            bookingPage.ClickOnHolidayBtn();
            LoggerHelper.Log(log, _test, "Clicked on Holiday tab");
            bookingPage.ClickOnRequestBtn();
            LoggerHelper.Log(log, _test, "Clicked on Request button");
            bookingPage.ValidateChildrenIsMarkedAsHoliday();
            LoggerHelper.Log(log, _test, "Children is marked as holiday");
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Invalid Parent login functionality")]
        public void VerifyParentCanSendMessageToCenter()
        {
            accountPage.ClickOnAccountTab();
            LoggerHelper.Log(log, _test, "Clicked on Account tab");
            accountPage.ClickOnInboxBtn();
            LoggerHelper.Log(log, _test, "Clicked on Inbox button");
            accountPage.ClickOnComposeMessageBtn();
            LoggerHelper.Log(log, _test, "Clicked on Compose message button");
            accountPage.EnterMessageTitle("Automated Message");
            LoggerHelper.Log(log, _test, "Entered message title");
            accountPage.EnterMessageBody("Automated Message body");
            LoggerHelper.Log(log, _test, "Entered message body");
            accountPage.ClickOnSendBtn();
            LoggerHelper.Log(log, _test, "Clicked on Send button");
            accountPage.ValidateMessageIsCreatedAndSent();
            LoggerHelper.Log(log, _test, "Message is sent successfully");
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Parent can see the Admin Posts")]
        public void VerifyParentCanSeeAdminPost()
        {
            accountPage.ClickOnAccountTab();
            LoggerHelper.Log(log, _test, "Clicked on Account tab");
            accountPage.ClickOnInboxBtn();
            LoggerHelper.Log(log, _test, "Clicked on Inbox button");
            accountPage.ClickOnAdminPostTab();
            LoggerHelper.Log(log, _test, "Clicked on Admin Post button");
            accountPage.ValidateAdminPostIsDisplayed();
            LoggerHelper.Log(log, _test, "Admin Post is displayed");
            accountPage.ClickOnAdminPostTitle();
            LoggerHelper.Log(log, _test, "Clicked on Admin Post title");
            accountPage.ValidateAdminPostDetailViewIsDisplayed();
            LoggerHelper.Log(log, _test, "Post detailed view is displayed");
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Notifications are received")]
        public void VerifyNotificationFunctionality()
        {
            accountPage.ClickOnAccountTab();
            LoggerHelper.Log(log, _test, "Clicked on Account tab");
            accountPage.ClickOnInboxBtn();
            LoggerHelper.Log(log, _test, "Clicked on Inbox button");
            accountPage.ClickOnNotificationTab();
            LoggerHelper.Log(log, _test, "Clicked on  Nitification button");
            accountPage.ValidateNotificationIsDisplayed();
            LoggerHelper.Log(log, _test, "Notification is displayed");           
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Account Summary")]
        public void VerifyAccountSummaryPages()
        {
            financePage.ClickOnFinanceTab();
            LoggerHelper.Log(log, _test, "Clicked on Finance tab");
            financePage.ValidateFinanceTitleIsDisplayed();
            LoggerHelper.Log(log, _test, "Finance page is opened successfully");
            financePage.ClickOnServiceName();
            LoggerHelper.Log(log, _test, "Clicked on  Service name");
            financePage.ClickOnAccountService();
            LoggerHelper.Log(log, _test, "Clicked on Account Summary");
            financePage.ValidateOwingAmountIsDisplayed();
            LoggerHelper.Log(log, _test, "Owing amount is displayed");
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Parent can able to do payment to center")]
        public void VerifyPayNowFunctionality()
        {
            financePage.ClickOnFinanceTab();
            LoggerHelper.Log(log, _test, "Clicked on Finance tab");
            financePage.EnterPaymentInformation();
            LoggerHelper.Log(log, _test, "Entered payment information");                  
            financePage.ValidatePaymentConfirmationMsgIsDisplayed();
            LoggerHelper.Log(log, _test, "Payment confirmation message is displayed");
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Parent can change the direct debit setup")]
        public void VerifyChangeDirectDebitDetails()
        {
            financePage.ClickOnFinanceTab();
            LoggerHelper.Log(log, _test, "Clicked on Finance tab");
            financePage.ClickOnServiceName();
            LoggerHelper.Log(log, _test, "Clicked on  Service name");
            financePage.ChangeDirectDebitDetails();
            LoggerHelper.Log(log, _test, "Direct Debit Changed");
            financePage.ValidateCreditCardPageIsDisplayed();
            LoggerHelper.Log(log, _test, "Credit card page is displayed");
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Parent can see the Account statement")]
        public void VerifyParentCanSeeAccountStatement()
        {
            financePage.ClickOnFinanceTab();
            LoggerHelper.Log(log, _test, "Clicked on Finance tab");
            financePage.ClickOnServiceName();
            LoggerHelper.Log(log, _test, "Clicked on  Service name");
            financePage.ClickOnShowStatementBtn();
            LoggerHelper.Log(log, _test, "Clicked on Show statement button");
            financePage.ValidateStatementTitleIsDisplayed();
            LoggerHelper.Log(log, _test, "Statement title is displayed");
            financePage.ValidateAmountDueIsDisplayed();
            LoggerHelper.Log(log, _test, "Amount due is displayed");
            financePage.ValidateViewAccountSummaryBtnIsDisplayed();
            LoggerHelper.Log(log, _test, "View Account Summary button is displayed");
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Invalid Parent login functionality")]
        [Ignore("Ignore negative test")]
        public void VerifyInvalidParentLoginFunctionality()
        {
            loginStep.ValidateInvalidParentLogin();
        }

        [Test]
        [Category("Smoke")]
        [Description("Verify Invalid Parent login with empty username")]
        [Ignore("Ignore negative test")]
        public void VerifyInvalidParentLoginWithEmptyUsername()
        {
            loginStep.ValidateInvalidParentLoginWithEmptyUsername();
        }

        [TearDown]
        public void DisposeDriver()
        {
            LoggerHelper.Log(log, _test, "Test Ended---->" + TestContext.CurrentContext.Test.Name);
        }
    }
}
