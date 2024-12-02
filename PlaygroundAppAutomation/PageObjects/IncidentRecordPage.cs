using MobileAutomation.Tools;
using NSelene;
using NUnit.Framework;
using OpenQA.Selenium.Appium;

namespace MobileAutomation.PageObjects
{
    class IncidentRecordPage : BasePage
    {
        public IncidentRecordPage(AppiumDriver<AppiumWebElement> driver) : base(driver) { }
        public SeleneElement IncidentButton => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Incident Records']"), MobileBy.AccessibilityId("Incident Records"));

        public void ClickOnIncidentRecordBtn()
        {
            this.ClickElement(IncidentButton);
        }

        public void ValidateIncidentRecordPageOpenedSuccessfully()
        {
            string actualPageTitle=GetElementText(IncidentButton);
            string expectedPageTitle = "Incident Records";
            Assert.AreEqual(expectedPageTitle, actualPageTitle, "Incident Record page is not opened successfully");
        }

    }
}
