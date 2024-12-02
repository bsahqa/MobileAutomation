using MobileAutomation.PageObjects;
using MobileAutomation.PageObjects.Attendance;
using OpenQA.Selenium.Appium;


namespace MobileAutomation.Steps
{
    class LearningSteps : BaseSteps
    {
        private AppiumDriver<AppiumWebElement> _driver;
        private LearningPage learningPage;
        private EducatorSteps educatorStep;
        public LearningSteps(AppiumDriver<AppiumWebElement> driver)
        {
            _driver = driver;
            learningPage = new LearningPage(_driver);
            educatorStep = new EducatorSteps(_driver);
        }

        
        public void ValidateCreatePostFunctionality()
        {
            educatorStep.ValidateEducatorLogin();
            learningPage.ClickOnLearningBtn();
            learningPage.OpenCreatePostPage();
            learningPage.CreatePost();
            learningPage.ValidatePostIsCreatedSuccessfully();
        }

        public void ValidateCreatePostFromChildProfile()
        {
            educatorStep.ValidateEducatorLogin();
            learningPage.ClickOnLearningBtn();
            learningPage.OpenCreatePostPageFromChildrenProfile();
            learningPage.EnterTitleAndDescription();
            learningPage.ClickOnSaveBtn();
            learningPage.ClickOnSharedWithFamilies();
            learningPage.WaitForElementToBeClickable();
            if (MobileDriver.IsAndroid)
            {
                learningPage.ClickOnSaveBtn();
            }
            else
            {
                learningPage.ClickOnSaveButton();
            }
            if(MobileDriver.IsAndroid)
            {
                learningPage.ClickBackBtnChildrenPosts();
            }
            
            learningPage.ClickOnChildrenName();
            learningPage.WaitForElementToBeClickable();
            learningPage.ValidatePostCreatedSuccessfully();
        }

        public void ValidateOutcomePageLoaded()
        {
            educatorStep.ValidateEducatorLogin();
            learningPage.ClickOnLearningBtn();
            learningPage.OpenCreatePostPageFromChildrenProfile();
            learningPage.OpenOutcomesPage();
            learningPage.ValidateOutcomePageOpenedSuccessfully();
        }

        public void ValidateLinksPageLoaded()
        {
            educatorStep.ValidateEducatorLogin();
            learningPage.ClickOnLearningBtn();
            learningPage.OpenCreatePostPageFromChildrenProfile();
            learningPage.OpenLinksPage();
            learningPage.WaitForElement(15000);
            learningPage.ValidateLinksPageOpenedSuccessfully();
        }

        public void ValidateMorePageLoaded()
        {
            educatorStep.ValidateEducatorLogin();
            learningPage.ClickOnLearningBtn();
            learningPage.OpenCreatePostPageFromChildrenProfile();
            learningPage.ClickOnMoreBtn();
            learningPage.ValidateMorePageOpenedSuccessfully();
        }

        public void ValidateChildrenFiltersOptionOnhildrenTag()
        {
            educatorStep.ValidateEducatorLogin();
            learningPage.ClickOnLearningBtn();
            learningPage.OpenCreatePostPage();
            learningPage.OpenChildrenTagPage();
            learningPage.ClickOnAllChildrenFilter();
            learningPage.ValidateAllChildrenFilterOptionDisplayed();
            learningPage.ValidateBookedInOptionDisplayed();
            learningPage.ValidateSignedInOptionDisplayed();
            learningPage.ValidateDefaultOptionDisplayed();
        }

        public void ValidateChildrenFiltersOptionOnChildrenPage()
        {
            educatorStep.ValidateEducatorLogin();
            learningPage.ClickOnLearningBtn();
            learningPage.ClickOnAllChildrenDropdown();
            learningPage.ValidateSignedInFilterDisplayed();
            learningPage.ValidateBookedInFilterDisplayed();
            learningPage.ValidateDefaultRoomFilterDisplayed();
            learningPage.ValidateAllChildrenBtnDisplayed();
        }

    }
}
