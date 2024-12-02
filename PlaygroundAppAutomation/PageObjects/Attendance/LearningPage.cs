using Bogus;
using MobileAutomation.Tools;
using NSelene;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using RazorEngine.Compilation.ImpromptuInterface;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MobileAutomation.PageObjects.Attendance
{
    class LearningPage : BasePage
    {
        private Faker testData;
        private string postTitle;
        public LearningPage(AppiumDriver<AppiumWebElement> driver) : base(driver)
        {
            this.testData= new Faker();
        }

        public SeleneElement LearningButton => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/room_bottom_nav_learning"), MobileBy.AccessibilityId("TabBarIcons/learning-inactive"));
        public SeleneElement NewPostBtn => GetPlatformSpecificElement(MobileBy.AccessibilityId("New Post"), MobileBy.AccessibilityId("newPostButton"));
        public SeleneElement PostTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Posts']"), MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == \"Posts\"`]"));
        public SeleneElement MomentTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Moments']"), MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == \"Moments\"`]"));
        public SeleneElement ChildrenTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Children']"), MobileBy.IosClassChain("**/XCUIElementTypeImage[`label == \"LearningTab/children\"`]"));
        public SeleneElement TitleInput=> GetPlatformSpecificElement(MobileBy.XPath("//android.widget.ScrollView/android.widget.EditText[1]"), MobileBy.XPath("//XCUIElementTypeOther/XCUIElementTypeTextField"));
        public SeleneElement DescriptionInput => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.ScrollView/android.widget.EditText[2]/android.view.View"), MobileBy.IosClassChain("**/XCUIElementTypeOther[`label == \"Rich Text Area\"`][2]"));
        public SeleneElement PostDescBackBtn => GetPlatformSpecificElement(MobileBy.XPath("nill"), MobileBy.IosClassChain("**/XCUIElementTypeWindow[1]/XCUIElementTypeOther[4]/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeButton"));
        public SeleneElement ChildrenBtn => GetPlatformSpecificElement(MobileBy.XPath("(//android.view.View[@content-desc=\"circle icon\"])[2]"), MobileBy.AccessibilityId("childrenButton-childrenButton"));
        public SeleneElement OutcomesBtn => GetPlatformSpecificElement(MobileBy.XPath("(//android.view.View[@content-desc=\"circle icon\"])[3]"), MobileBy.IosClassChain("**/XCUIElementTypeImage[`name == \"outcomesButton\"`]"));
        public SeleneElement LinksBtn => GetPlatformSpecificElement(MobileBy.XPath("(//android.view.View[@content-desc=\"circle icon\"])[4]"), MobileBy.IosClassChain("**/XCUIElementTypeImage[`name == \"linksButton\"`]"));
        public SeleneElement ChildCheckbox=> GetPlatformSpecificElement(MobileBy.XPath("//android.view.View[5]/android.widget.CheckBox"), MobileBy.XPath("(//XCUIElementTypeImage[@name=\"Posts/square\"])[3]"));
        public SeleneElement TagChildrenBtn => GetPlatformSpecificElement(MobileBy.XPath("(//android.widget.TextView[@text=\"Tag children\"])[2]"), MobileBy.AccessibilityId("tagChildrenButton"));
        public SeleneElement SaveBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Save']"), MobileBy.AccessibilityId("saveButton"));
        public SeleneElement PreviewBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Preview']"), MobileBy.AccessibilityId("Preview"));
        public SeleneElement CancelBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Cancel']"), MobileBy.AccessibilityId("Cancel"));
        public SeleneElement SharedWithFamilies => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Share with Families']"), MobileBy.AccessibilityId("statusView-Share with Families"));
        public SeleneElement SaveButton => GetElementByXPath("(//XCUIElementTypeButton[@name=\"saveButton\"])[2]");
        public SeleneElement Draft => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Draft']"), MobileBy.AccessibilityId("statusView-Draft"));
        public SeleneElement ChildrenName => GetPlatformSpecificElement(MobileBy.XPath("//android.view.View[1]//android.view.View//android.view.View[4]/android.widget.TextView[1]"), MobileBy.XPath("//XCUIElementTypeScrollView/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeButton[1]/XCUIElementTypeStaticText[2]"));
        public SeleneElement CreatePostBtn => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/btnAddNewObservation"), MobileBy.IosClassChain("**/XCUIElementTypeButton[`label == \"create new post\"`]"));
        public SeleneElement PostTitle => GetPlatformSpecificElement(MobileBy.Id($"{DataContext.AndroidAppPackage}:id/tvObservationRecentTitle"), MobileBy.XPath("//XCUIElementTypeCell[1]/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeStaticText"));
        public SeleneElement PublishedPostTitle => GetPlatformSpecificElement(MobileBy.XPath($"//android.widget.TextView[@text='{postTitle}']"), MobileBy.XPath($"//XCUIElementTypeStaticText[@name='{postTitle}']"));
        public SeleneElement BackBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.ImageButton[@content-desc='Navigate up']"), MobileBy.AccessibilityId("Back"));
        public SeleneElement OutcomePageTitle => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Tag Learning Outcomes']"), MobileBy.AccessibilityId("navTitle"));
        public SeleneElement LinksPageTitle => GetPlatformSpecificElement(MobileBy.XPath("//android.view.View[@text='Link to Related Learning']"), MobileBy.AccessibilityId("Link to Related Learning"));
        public SeleneElement AllTab => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='All']"), MobileBy.XPath("(//XCUIElementTypeLink[@name='All'])[1]"));
        public SeleneElement MoreBtn => GetPlatformSpecificElement(MobileBy.XPath("(//android.view.View[@content-desc=\"circle icon\"])[5]"), MobileBy.XPath("//XCUIElementTypeButton[@name='More']/XCUIElementTypeImage"));
        public SeleneElement MorePageTitle => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='About This Post']"), MobileBy.AccessibilityId("About This Post"));
        // Children Tag filter
        public SeleneElement AllChildrenFilter => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='All children']"), MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == \"All children\"`]"));
        public SeleneElement AllChildrenOption => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='All children']"), MobileBy.AccessibilityId("groupFilterOption-All children"));
        public SeleneElement BookedInOption => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Booked in']"), MobileBy.AccessibilityId("groupFilterOption-Booked in"));
        public SeleneElement SignedInOption => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Signed in']"), MobileBy.AccessibilityId("groupFilterOption-Signed in"));
        public SeleneElement DefaultOption => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Default room']"), MobileBy.AccessibilityId("groupFilterOption-Default room"));

        // Children page filter elements
        public SeleneElement AllChildrenBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='All children']"), MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`label == \"All children\"`]"));
        public SeleneElement SignedInFilter => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Signed in']"), MobileBy.AccessibilityId("Signed in"));
        public SeleneElement BooeknInFilter => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Booked in']"), MobileBy.AccessibilityId("Booked in"));
        public SeleneElement AllChildrenFilters => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='All children']"), MobileBy.AccessibilityId("All children"));
        public SeleneElement DefaultRoomFilter => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Default room']"), MobileBy.AccessibilityId("Default room"));

        public void ClickOnBackBtn()
        {
            this.ClickElement(PostDescBackBtn);
        }
        public void ClickOnAllChildrenDropdown()
        {
            this.ClickElement(AllChildrenBtn);
        }
        public void ValidateAllChildrenBtnDisplayed()
        {
            string actualText = GetElementByLabel(AllChildrenFilters);
            string expectedText = "All children";
            Assert.That(actualText, Is.EqualTo(expectedText));
        }
        public void ValidateDefaultRoomFilterDisplayed()
        {
            string actualText = GetElementByLabel(DefaultRoomFilter);
            string expectedText = "Default room";
            Assert.That(actualText, Is.EqualTo(expectedText));
        }
        public void ValidateSignedInFilterDisplayed()
        {
            string actualText = GetElementByLabel(SignedInFilter);
            string expectedText = "Signed in";
            Assert.That(actualText, Is.EqualTo(expectedText));
        }
        public void ValidateBookedInFilterDisplayed()
        {
            string actualText = GetElementByLabel(BooeknInFilter);
            string expectedText = "Booked in";
            Assert.That(actualText, Is.EqualTo(expectedText));
        }
        public void ClickOnAllChildrenFilter()
        {
            this.ClickElement(AllChildrenFilter);
        }
        public void ValidateAllChildrenFilterOptionDisplayed()
        {
            string actualText = GetElementByLabel(AllChildrenOption);
            string expectedText = "All children";
            Assert.That(actualText, Is.EqualTo(expectedText));
        }
        public void ValidateBookedInOptionDisplayed()
        {
            string actualText = GetElementByLabel(BookedInOption);
            string expectedText = "Booked in";
            Assert.That(actualText, Is.EqualTo(expectedText));
        }
        public void ValidateSignedInOptionDisplayed()
        {
            string actualText = GetElementByLabel(SignedInOption);
            string expectedText = "Signed in";
            Assert.That(actualText, Is.EqualTo(expectedText));
        }
        public void ValidateDefaultOptionDisplayed()
        {
            string actualText = GetElementByLabel(DefaultOption);
            string expectedText = "Default room";
            Assert.That(actualText, Is.EqualTo(expectedText));
        }


        public void ClickOnMoreBtn()
        {
            this.ClickElement(MoreBtn);
        }

        public void ValidateMorePageOpenedSuccessfully()
        {
            string actualMorePageTitle = GetElementText(MorePageTitle);
            string expectedMorePageTitle = "About This Post";
            Assert.AreEqual(expectedMorePageTitle, actualMorePageTitle, "More page is not opened");
        }
        
        public void ClickOnAllTab()
        {
            this.ClickElement(AllTab);
        }
        public void OpenOutcomesPage()
        {
            this.ClickElement(OutcomesBtn);            
        }

        public void OpenLinksPage()
        {
            this.ClickElement(LinksBtn);
        }

        public void ValidateLinksPageOpenedSuccessfully()
        {
            string actualText = GetElementText(LinksPageTitle);
            string expectedText = "Link to Related Learning";
            Assert.That(actualText, Is.EqualTo(expectedText));
        }

        public void ValidateOutcomePageOpenedSuccessfully()
        {

           string actualText = GetElementText(OutcomePageTitle);
            string expectedText = "Tag Learning Outcomes";
            Assert.That(actualText, Is.EqualTo(expectedText));
        }
        public void ClickOnChildrenName()
        {
            this.ClickElement(ChildrenName);
        }
        public void ClickOnCreatePostBtn()
        {
            this.ClickElement(CreatePostBtn);
        }

        public void ClickBackBtnChildrenPosts()
        {
           this.ClickElement(BackBtn);
        }

        public void OpenCreatePostPageFromChildrenProfile()
        {
            this.ClickOnChildrenName();
            this.ClickOnCreatePostBtn();
        }

        public void OpenCreatePostPage()
        {
            this.ClickOnPostTab();
            this.ClickOnNewPostBtn();
        }

        public void EnterTitleAndDescription()
        {
            this.EnterTitle();
            Task.Delay(3000).Wait();
            this.EnterDescription();            
            Task.Delay(5000).Wait();
            this.ClickOnBackBtn();
        }

        public void OpenChildrenTagPage()
        {
            this.ClickOnChildrenBtn();
        }
        public void TagChildren()
        {
            this.ClickOnChildCheckbox();
            this.ClickOnTagChildrenBtn();
        }


        public void CreatePost()
        {
            this.EnterTitleAndDescription();
            this.OpenChildrenTagPage();
            this.TagChildren();
            this.WaitForElementToBeClickable();
            this.ClickOnSaveBtn();
            this.ClickOnSharedWithFamilies();
            this.WaitForElementToBeClickable();
            if (MobileDriver.IsAndroid)
            {
                this.ClickOnSaveBtn();
            }
            else
            {
                this.ClickOnSaveButton();
            }
            this.WaitForElementToBeClickable();
            this.ClickOnAllTab();
            this.ScrollToElements(postTitle);
        }

        public void ClickOnLearningBtn()
        {
            this.ClickElement(LearningButton);
        }

        public void ClickOnNewPostBtn()
        {
            this.ClickElement(NewPostBtn);
        }
        public void ClickTitle()
        {
            this.ClickElement(TitleInput);
        }
        public void EnterTitle()
        {
            postTitle= "Automated" +""+ testData.Name.FullName();
            this.EnterText(TitleInput, postTitle);
        }
        public void PressReturnKey()
        {
            this.PressKey(DescriptionInput, Keys.Return);
        }
        public void EnterDescription()
        {
            this.EnterText(DescriptionInput, "Automated" +""+ testData.Lorem.Sentences(2));
           
        }
        public void ClickOnChildrenBtn()
        {
           /* if(MobileDriver.IsAndroid)
            {
                MobileDriver.Driver.HideKeyboard();
            }
            else
            {
                this.PressReturnKey();                
            }*/
            this.ClickElement(ChildrenBtn);
        }

        public void ClickOnChildCheckbox()
        {
            this.ScrollDownHalfScreen();
            this.ClickElement(ChildCheckbox);
            this.WaitForElementToBeClickable();
        }

        public void ClickOnTagChildrenBtn()
        {
            this.ClickElement(TagChildrenBtn);
        }

        public void ClickOnSaveBtn()
        {
            this.ClickElement(SaveBtn);
        }

        public void ClickOnSaveButton()
        {
            this.ClickElement(SaveButton);
        }

        public void ClickOnPostTab()
        {
            this.ClickElement(PostTab);
        }

        public void ValidatePostCreatedSuccessfully()
        {
            string actualPostTitle = GetElementText(PostTitle);
            Assert.That(actualPostTitle, Is.EqualTo(postTitle), "Post is not created");                    
        }

        public void ClickOnSharedWithFamilies()
        {
            this.ClickElement(SharedWithFamilies);
        }

        public void ValidatePostIsCreatedSuccessfully()
        {
            string actualText = GetElementText(PostTab);
            Assert.That(actualText, Is.EqualTo("Posts"));            
        }   
    }
}
