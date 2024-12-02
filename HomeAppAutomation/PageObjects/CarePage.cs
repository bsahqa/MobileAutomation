using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using Bogus;
using HomeAppAutomations;
using HomeAppAutomations.PageObjects;
using HomeAppAutomations.Tools;
using NSelene;
using NUnit.Framework;
using OpenQA.Selenium.Appium;


namespace HomeAppAutomation.PageObjects
{
    class CarePage : BasePage 
    {
        private TestData testData;
        private Faker Data;
        public CarePage(AppiumDriver<AppiumWebElement> driver) : base(driver) 
        {
            testData = JsonUtil.GetTestData();
            this.Data = new Faker();
        }
        public SeleneElement CareTab => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/menuItemCare"), MobileBy.AccessibilityId("learning-tab-inactive"));
        public SeleneElement LearningLbl => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/documentsLabel"), MobileBy.AccessibilityId("Learning"));
        public SeleneElement HealthJourney => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvHealthJourneyLabel"), MobileBy.AccessibilityId("Health Journey"));
        public SeleneElement LearningViewAll => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/documentsViewAll"), MobileBy.XPath("(//XCUIElementTypeButton[@name='View All'])[1]"));
        public SeleneElement Posts => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Post']"), MobileBy.AccessibilityId("Post"));
        public SeleneElement DownloadMediaBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/miDownloadMedia"), MobileBy.XPath("//XCUIElementTypeNavigationBar[@name='home_dev.PostDetailsView']/XCUIElementTypeButton[2]"));
        public SeleneElement DownloadPhotoBtn => GetElementByXPath("//XCUIElementTypeStaticText[@name='Download Photos/ Videos']");
        public SeleneElement DownloadStatus => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvDownloadStatusTitle"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='Media downloaded successfully']"));
        public SeleneElement GrantAccessBtn => GetElementByXPath("//XCUIElementTypeButton[@name='Grant Access']");
        public SeleneElement AllowAccess => GetElementByXPath("//XCUIElementTypeButton[@name='Allow Full Access']");
        public SeleneElement RatingAlert => GetElementByAccessibilityId("Love it");
        public SeleneElement PostListTitle => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvItemTimelineObservationTitle"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='New school year session started']"));
        public SeleneElement EducatorName => GetPlatformSpecificElement(MobileBy.XPath($"//android.widget.TextView[@text='{testData.UserContent[0].EducatorName}']"), MobileBy.XPath($"//XCUIElementTypeStaticText[@name='{testData.UserContent[0].EducatorName}']"));
        public SeleneElement PostLbl => GetPlatformSpecificElement(MobileBy.XPath($"//android.widget.TextView[@text='{testData.UserContent[0].PostTitle}']"), MobileBy.XPath($"//XCUIElementTypeStaticText[@name='{testData.UserContent[0].PostTitle}']"));
        public SeleneElement PostDesc => GetPlatformSpecificElement(MobileBy.XPath($"//android.widget.TextView[@text='{testData.UserContent[0].PostDesc}']"), MobileBy.XPath($"//XCUIElementTypeStaticText[@name='{testData.UserContent[0].PostDesc}']"));
        public SeleneElement LikeBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Love']"), MobileBy.AccessibilityId("Love"));
        public SeleneElement DislikeBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Love']"), MobileBy.AccessibilityId("Love"));
        public SeleneElement Comment => GetPlatformSpecificElement(MobileBy.XPath("//android.view.View[9]/android.view.View/android.view.View/android.widget.EditText"), MobileBy.IosClassChain("**/XCUIElementTypeTextView[`value == \"Write your comment...\"`]"));
        public SeleneElement CommentPostBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.view.View/android.view.View[10]/android.widget.Image"), MobileBy.XPath("//XCUIElementTypeButton[@name='Post']"));
        public SeleneElement NoOfLike => GetPlatformSpecificElement(MobileBy.XPath("//android.view.View/android.view.View[3]/android.widget.TextView"), MobileBy.XPath("//XCUIElementTypeOther/XCUIElementTypeOther[12]/XCUIElementTypeStaticText"));
        public SeleneElement CommentText => GetPlatformSpecificElement(MobileBy.XPath($"//android.widget.TextView[@text='{commentTxt}']"), MobileBy.XPath($"//XCUIElementTypeStaticText[@name='{commentTxt}']"));
        string commentTxt;
        public SeleneElement Attachment => GetPlatformSpecificElement(MobileBy.XPath("//android.view.View[2]/android.view.View/android.widget.TextView[1]"), MobileBy.XPath("//XCUIElementTypeOther[@name=\"Xplor - Home\"]/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther[8]"));
        public SeleneElement OpenPDFConfirmation => GetPlatformSpecificElement(MobileBy.Id("com.android.chrome:id/positive_button"), MobileBy.XPath("confirmation"));
        public SeleneElement OpenDocumentTitle => GetPlatformSpecificElement(MobileBy.Id("com.android.chrome:id/title"), MobileBy.XPath("//XCUIElementTypeWebView[@name=\"WebView\"]"));
       
        // Create Moment elements
        public SeleneElement PhotoIcon => GetPlatformSpecificElement(MobileBy.Id("Nill"), MobileBy.XPath("//XCUIElementTypeNavigationBar[@name=\"Learning\"]/XCUIElementTypeButton[1]"));
        public SeleneElement GallaryBtn => GetPlatformSpecificElement(MobileBy.Id("Nill"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Gallery\"]"));
        public SeleneElement GrantAccess => GetPlatformSpecificElement(MobileBy.Id("Nill"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Grant Access\"]"));
        public SeleneElement AllowFullAccess => GetPlatformSpecificElement(MobileBy.Id("Nill"), MobileBy.XPath("//XCUIElementTypeButton[@name=\"Allow Full Access\"]"));


        public void ClickOnAttachment()
        {
            this.ScrollDownToElements("Love");
            this.ClickElement(Attachment);
        }
        public void ValidateDocumentOpended()
        {
            string actualDocumentTitle= GetElementText(OpenDocumentTitle);
            if(MobileDriver.IsAndroid)
            {
                Assert.AreEqual("Open PDF?", actualDocumentTitle, "Document is not opened");
            }
            else
            {
                if(!IsElementDisplayed(Attachment))
                {
                    Assert.IsTrue(true);
                }
                else 
                { 
                    Assert.IsTrue(false); 
                }
            }            
        }
        public void TypeComment()
        { 
            commentTxt = Data.Lorem.Sentence();
            this.EnterText(Comment, commentTxt);           
        }
        public void ScrollDownToElement(string text)
        {
            this.ScrollToElement(text);
        }
        public void ClickOnCommentPostBtn()
        {
            if(MobileDriver.IsIOS)
            {
                this.TapOnCoordinates(88, 34);
            }
            else
            {
                this.ClickElement(CommentPostBtn);
            }            
        }

        public void ValidateCommentIsPostedSuccessfully()
        {
            string actualComment = GetElementText(CommentText);
            Assert.AreEqual(commentTxt, actualComment, "Comment is not posted successfully");
        }
        public void ClickOnCommentLikeBtn()
        {
            ScrollToElement("Love");
            this.ClickElement(LikeBtn);
            this.WaitForElementToBeClickable();
        }
        public void ClickOnDislikeBtn()
        {
            this.ClickElement(DislikeBtn);
        }
        public void ValidateCommentIsLikedSuccessfully()
        {
            string actualNoOfLike = GetElementText(NoOfLike);
            Assert.AreEqual("1", actualNoOfLike, "Comment is not liked successfully");
        }
        public void ValidateCommentIsDislikedSuccessfully()
        {
            string actualNoOfLike = GetElementText(NoOfLike);
            Assert.AreEqual("0", actualNoOfLike, "Comment is not disliked successfully");
        }

        public void ValidateEducatorNameIsVisible()
        {
            string actualEducatorName = GetElementText(EducatorName);
            string expectedEducatorName = testData.UserContent[0].EducatorName;
            Assert.AreEqual(expectedEducatorName, actualEducatorName, "Educator name is not displayed");
        }

        public void ValidatePostTitleIsVisible()
        {
            string actualPostTitle = GetElementText(PostLbl);
            string expectedPostTitle = testData.UserContent[0].PostTitle;
            Assert.AreEqual(expectedPostTitle, actualPostTitle, "Post title is not displayed");
        }
        public void ValidatePostDescIsVisible() 
        {
            string actualPostDesc = GetElementText(PostDesc);
            string expectedPostDesc = testData.UserContent[0].PostDesc;
            Assert.AreEqual(expectedPostDesc, actualPostDesc, "Post description is not displayed");
        }

        public void ClickOnAllowFullAccess()
        {
            this.ClickElement(AllowAccess);
        }   
        public void ClickOnGrantAccessBtn()
        {
            this.ClickElement(GrantAccessBtn);
        }
        public void ClickOnDownloadPhotoBtn()
        {
            this.ClickElement(DownloadPhotoBtn);
        }
        public void ClickOnLearningViewAllBtn()
        {
            this.WaitForElementToBeClickable();
            this.ClickElement(LearningViewAll);
        }
        public void ClickOnPosts()
        {
            //this.WaitForElementToBeClickable();
            //this.ScrollToElement("Post");
            this.WaitForElementToBeClickable();
            this.ClickElement(Posts);
        }

        public void ClickOnDownloadMediaBtn()
        {
            this.WaitForElementToBeClickable();
            this.ClickElement(DownloadMediaBtn);
            if(MobileDriver.IsIOS)
            {
                this.ClickOnDownloadPhotoBtn();
                this.ClickOnGrantAccessBtn();
                this.ClickOnAllowFullAccess();
            }
        }

        public void OpenPostDetailedPage()
        {
            this.ClickOnCareTab();
            this.ClickOnLearningViewAllBtn();
            this.ClickOnPosts();
            this.WaitForElementToBeClickable();
        }

        public void ValidateMediaFileIsDownloaded()
        {
            this.WaitForElementToBeClickable();
            if(MobileDriver.IsIOS)
            {
                bool IsRatingAlertVisible = IsElementDisplayed(RatingAlert);
                if (IsRatingAlertVisible)
                {
                    Assert.IsTrue(true, "Media file is downloaded successfully");
                }
                else
                {
                    Assert.IsTrue(false, "Media file is not downloaded");
                }
            }
            else
            {
                bool IsMediaDownloaded = IsElementDisplayed(DownloadStatus);
                if (IsMediaDownloaded)
                {
                    Assert.IsTrue(true, "Media file is downloaded successfully");
                }
                else
                {
                    Assert.IsTrue(false, "Media file is not downloaded");
                }
            }         
            
        }

        public void ClickOnCareTab()
        {
            this.WaitForElementToBeClickable();
            this.ClickElement(CareTab);
        }

        public void ValidateLearningOptionIsVisible()
        {
            string actualLearningLbl = GetElementText(LearningLbl);
            Assert.AreEqual(CareConstants.LearningLbl, actualLearningLbl, "Learning option is not displayed");

        }

        public void ValidateHealthJoruneyOptionOptionIsVisible()
        {
            string actualHealthJourneyLbl = GetElementText(HealthJourney);
            Assert.AreEqual(CareConstants.HealthJourneyLbl, actualHealthJourneyLbl, "Health Journey is not displayed");
        }

    }
    class CareConstants
    {
        public CareConstants() {}
        public const string LearningLbl = "Learning";
        public const string HealthJourneyLbl = "Health Journey";
    }
}
