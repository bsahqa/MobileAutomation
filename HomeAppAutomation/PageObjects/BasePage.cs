using HomeAppAutomations.Tools;
using NSelene;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.iOS;
using System.Threading.Tasks;

namespace HomeAppAutomations.PageObjects
{
    abstract class BasePage
    {
        protected readonly AppiumDriver<AppiumWebElement> _driver;
        protected readonly TouchAction action;

        public BasePage(AppiumDriver<AppiumWebElement> driver)
        {
            _driver = driver;
            action = new TouchAction(_driver);
        }


        protected string AndroidAutoIdAttribute => "@content-desc";

        protected string IOSAutoIdAttribute => "@name";

        protected string AutoIdAttribute => MobileDriver.IsAndroid ? AndroidAutoIdAttribute : IOSAutoIdAttribute;

        protected AppiumWebElement GetElement(By by)
        {
            try
            {
                return _driver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        protected SeleneElement GetPlatformSpecificElement(By androidLocator, By iosLocator)
        {
            Dictionary<string, By> platforSpecificLocator = new Dictionary<string, By>
            {
                { "Android", androidLocator },
                { "iOS", iosLocator }
            };

            return Selene.S(platforSpecificLocator[MobileDriver.TestingOS]);
        }

        protected SeleneElement GetPlatformSpecificElement(SeleneElement androidLocator, SeleneElement iosLocator)
        {
            Dictionary<string, SeleneElement> platforSpecificLocator = new Dictionary<string, SeleneElement>
            {
                { "Android", androidLocator },
                { "iOS", iosLocator }
            };

            return platforSpecificLocator[MobileDriver.TestingOS];
        }

        protected List<SeleneElement> GetPlatformSpecificElementsList(By androidLocator, By iosLocator)
        {
            Dictionary<string, By> platforSpecificLocator = new Dictionary<string, By>
            {
                { "Android", androidLocator },
                { "iOS", iosLocator }
            };

            return new List<SeleneElement>(Selene.SS(platforSpecificLocator[MobileDriver.TestingOS]));
        }

        protected SeleneElement GetElementByAutomationId(string automationId)
        {
            return Selene.S(MobileBy.AccessibilityId(automationId)).With(timeout: 5);
        }

        protected List<SeleneElement> GetElementsListByAutomationId(string automationId)
        {
            List<SeleneElement> output = new List<SeleneElement>();
            SeleneCollection a = Selene.SS(MobileBy.AccessibilityId(automationId));
            foreach (SeleneElement elem in a)
            {
                output.Add(elem);
            }
            return output;
        }

        protected List<SeleneElement> GetElementsListByText(string searchText)
        {
            List<SeleneElement> output = new List<SeleneElement>();
            SeleneCollection a = MobileDriver.IsAndroid ?
                Selene.SS(MobileBy.XPath($"//android.widget.TextView[contains(@text,\"{searchText}\")]")) :
                Selene.SS(MobileBy.IosClassChain($"**/XCUIElementTypeStaticText[`label CONTAINS \"{searchText}\"`]"));
            foreach (SeleneElement elem in a)
            {
                output.Add(elem);
            }
            return output;
        }

        protected SeleneElement GetElementByXPath(string xPath)
        {
            return Selene.S(MobileBy.XPath(xPath)).With(timeout: 5);
        }

        protected SeleneElement GetElementByAccessibilityId(string accessibility)
        {
            return Selene.S(MobileBy.AccessibilityId(accessibility)).With(timeout: 5);
        }

        protected SeleneElement GetElementByIOSClassChain(string classChain)
        {
            return Selene.S(MobileBy.IosClassChain(classChain)).With(timeout: 5);
        }

        public static bool IsElementExists(SeleneElement element)
        {
            bool isInDOM = element.With(timeout: 10).Matching(Be.InDom);
            return isInDOM && element.Matching(Be.Visible);
        }

        public static bool IsElementDisplayed(SeleneElement element)
        {
            return element.With(timeout: 10).Matching(Be.Visible);
        }

        /// <summary>
        ///     <param name="element">an instance representation of any element type</param>
        ///     <param name="timeout">given waiting timeout as TimeSpan instance</param>
        ///     <param name="condition">condition to be tested (must have the same type as element)</param>
        ///     <example>
        ///         This example shows how to add a simple waiter until web element will be in 'Enabled' state
        ///     <code>
        ///         IWebElement webElement => _browser.GetElementByCssSelector("example");
        ///         WaitFor(webElement, Timeouts.UiInteractionTimeout, elem => elem.Enabled())
        ///         <see cref="Timeouts"/>
        ///     </code>
        ///     </example>
        /// </summary>
        public static void WaitFor<T>(T element, TimeSpan timeout, Predicate<T> condition)
        {
            var pollingTimeout = Timeouts.UiInteractionTimeout;
            var waitTimeout = Timeouts.UiCheckStatusTimeout;

            var end = DateTime.Now.Add(timeout);
            var isReady = false;
            while (!isReady && DateTime.Now.CompareTo(end) <= 0)
            {
                try
                {
                    for (int i = 0; i < 3; i++)
                    {
                        isReady = condition.Invoke(element);
                        Thread.Sleep(waitTimeout);
                    }
                }
                catch (Exception)
                {
                    Thread.Sleep(pollingTimeout);
                    if (DateTime.Now.CompareTo(end) > 0)
                    {
                        throw;
                    }
                }
            }
        }

        public void ScrollIntoView(SeleneElement element, int attemptsAmount)
        {
            Size screenSize = _driver.Manage().Window.Size;
            int screenWidth = screenSize.Width;
            int screenHeight = screenSize.Height;

            while (!IsElementExists(element) && attemptsAmount > 0)
            {
                action.Press(screenWidth / 2, screenHeight / 2);
                action.Wait(200);
                action.MoveTo(screenWidth / 2, screenHeight / 4)
                    .Release()
                    .Wait(200)
                    .Perform();
                action.Cancel();
                attemptsAmount--;
            }
        }


        public void ScrollIntoView(string text, int attemptsAmount)
        {
            Size screenSize = _driver.Manage().Window.Size;
            int screenWidth = screenSize.Width;
            int screenHeight = screenSize.Height;

            SeleneElement element = GetTextItemWithWait(text);

            while (!IsElementExists(element) && attemptsAmount > 0)
            {
                action.Press(screenWidth / 2, screenHeight / 2);
                action.Wait(200);
                action.MoveTo(screenWidth / 2, screenHeight / 4)
                    .Release()
                    .Perform();
                action.Cancel();
                attemptsAmount--;
            }

        }
        public void ScrollIntoView(SeleneElement element, int attemptsAmount, double screenWidthTap = 0.5, double screenHeightTap = 0.5, double screenHeightRelease = 0.25)
        {
            int attempts = attemptsAmount * 2;
            Size screenSize = _driver.Manage().Window.Size;
            int screenWidthTapCoordinate = Convert.ToInt32(screenSize.Width * screenWidthTap);
            int screenHeightTapCoordinate = Convert.ToInt32(screenSize.Height * screenHeightTap);
            int screenHeightReleaseCoordinate = Convert.ToInt32(screenSize.Height * screenHeightRelease);

            while (!IsElementExists(element) && attempts > attemptsAmount)
            {
                action.Press(screenWidthTapCoordinate, screenHeightTapCoordinate);
                action.Wait(100);
                action.MoveTo(screenWidthTapCoordinate, screenHeightReleaseCoordinate)
                    .Release()
                    .Perform();
                action.Wait(100);
                action.Cancel();
                attempts--;
            }
            while (attempts > 0 && !IsElementExists(element))
            {
                action.Press(screenWidthTapCoordinate, screenHeightReleaseCoordinate);
                action.Wait(100);
                action.MoveTo(screenWidthTapCoordinate, screenHeightTapCoordinate)
                    .Release()
                    .Perform();
                action.Wait(100);
                action.Cancel();
                attempts--;
            }
        }

        public void ScrollIntoViewWithoutWait(SeleneElement element, int attemptsAmount, double screenWidthTap = 0.5, double screenHeightTap = 0.5, double screenHeightRelease = 0.25)
        {
            Size screenSize = _driver.Manage().Window.Size;
            int screenWidthTapCoordinate = Convert.ToInt32(screenSize.Width * screenWidthTap);
            int screenHeightTapCoordinate = Convert.ToInt32(screenSize.Height * screenHeightTap);
            int screenHeightReleaseCoordinate = Convert.ToInt32(screenSize.Height * screenHeightRelease);

            while (!IsElementExists(element) && attemptsAmount > 0)
            {
                action.Press(screenWidthTapCoordinate, screenHeightTapCoordinate)
                    .MoveTo(screenWidthTapCoordinate, screenHeightReleaseCoordinate)
                    .Release()
                    .Wait(350)
                    .Perform();
                action.Cancel();
                attemptsAmount--;
            }
        }

        public void ScrollIntoView(By by, int attemptsAmount)
        {
            Size screenSize = _driver.Manage().Window.Size;
            int screenWidth = screenSize.Width;
            int screenHeight = screenSize.Height;
            AppiumWebElement element = null;

            while (element == null && attemptsAmount > 0)
            {
                try
                {
                    element = _driver.FindElement(by);
                    return;
                }
                catch
                {
                    element = null;
                }
                action.Press(screenWidth / 2, screenHeight / 2)
                    .Wait(200)
                    .MoveTo(screenWidth / 2, screenHeight / 4)
                    .Release()
                    .Perform();
                action.Cancel();
                attemptsAmount--;
            }
        }

        public virtual void SwipeRight()
        {
            Size screenSize = _driver.Manage().Window.Size;
            int screenWidth = screenSize.Width;
            int screenHeight = screenSize.Height;

            action.Press(screenWidth - 1, screenHeight / 2)
             .Wait(200)
             .MoveTo(1, screenHeight / 2)
             .Wait(200)
             .Release()
             .Perform();
            action.Cancel();
        }
        public virtual void SwipeLeft()
        {
            Size screenSize = _driver.Manage().Window.Size;
            int screenWidth = screenSize.Width;
            int screenHeight = screenSize.Height;

            action.Press(1, screenHeight / 2)
             .Wait(200)
             .MoveTo(screenWidth - 1, screenHeight / 2)
             .Wait(200)
             .Release()
             .Perform();
            action.Cancel();
        }
        public virtual void SwipeByCoordinates(SeleneElement element, double screenWidthTap, double screenHeightTap, double screenWidthRelease)
        {
            Size screenSize = _driver.Manage().Window.Size;

            int screenWidthTapCoordinate = Convert.ToInt32(screenSize.Width * screenWidthTap);
            int screenHeightTapCoordinate = Convert.ToInt32(screenSize.Height * screenHeightTap);
            int screenWidthReleaseCoordinate = Convert.ToInt32(screenSize.Width * screenWidthRelease);
            action.Press(screenWidthTapCoordinate, screenHeightTapCoordinate);
            action.Wait(100);
            action.MoveTo(screenWidthReleaseCoordinate, screenHeightTapCoordinate * 0.98)
            .Release()
            .Perform();
            action.Cancel();
        }
        public virtual void SwipeByCoordinates(double screenWidthTap, double screenHeightTap, double screenWidthRelease)
        {
            Size screenSize = _driver.Manage().Window.Size;

            int screenWidthTapCoordinate = Convert.ToInt32(screenSize.Width * screenWidthTap);
            int screenHeightTapCoordinate = Convert.ToInt32(screenSize.Height * screenHeightTap);
            int screenWidthReleaseCoordinate = Convert.ToInt32(screenSize.Width * screenWidthRelease);
            action.Press(screenWidthTapCoordinate, screenHeightTapCoordinate);
            action.Wait(100);
            action.MoveTo(screenWidthReleaseCoordinate, screenHeightTapCoordinate * 0.98)
            .Release()
            .Perform();
            action.Cancel();
        }

        public void FillField(IWebElement field, string data)
        {
            if (data != null)
                field.SendKeys(data);
        }

        public void SetCheckboxValue(IWebElement checkbox, bool value)
        {
            if (checkbox.Selected != value)
                checkbox.Click();
        }

        private Dictionary<string, string> ProgressBarLocator => new Dictionary<string, string>
                {
                    {"Android", "//android.widget.ProgressBar" },
                    {"iOS", "//XCUIElementTypeProgressIndicator" }
                };

        public SeleneElement ProgressBar => GetElementByXPath(ProgressBarLocator[MobileDriver.TestingOS]);

        public bool IsUploadFinished
        {
            get
            {
                return ProgressBar.Matching(Be.Not.InDom);
            }
        }

        public void WaitUntillElementIsLoaded(TimeSpan timeout)
        {
            WaitFor(this, timeout, p => p.IsUploadFinished);
        }

        public void WaitUntilUploadFinished()
        {
            ProgressBar.With(timeout: 10).Should(Be.Not.Visible);
        }

        
        public void WaitUntilUploadFinished(int timeout)
        {
            ProgressBar.With(timeout: timeout).Should(Be.Not.Visible);
        }

        public AppiumWebElement GetItemByText(string text, bool isFullText = true)
        {
            if (MobileDriver.IsAndroid)
            {
                string attribute = "text";
                string baseXPath = "//android.widget.TextView";
                string textXPath = $"[contains(@{attribute}, \"{text}\")]";
                if (isFullText)
                    textXPath = $"[@{attribute}=\"{text}\"]";
                return GetElement(MobileBy.XPath($"{baseXPath}{textXPath}"));
            }
            else
            {
                if (isFullText)
                    return GetElement(MobileBy.IosClassChain($"**/*[`label == \"{text}\"`]"));
                else
                    return GetElement(MobileBy.IosClassChain($"**/*[`label CONTAINS \"{text}\"`]"));
            }
        }

        public SeleneElement GetTextItemWithWait(string text, bool isFullText = false)
        {
            if (MobileDriver.IsAndroid)
            {
                string attribute = "text";
                //string baseXPath = MobileDriver.IsAndroid ? "//android.widget.TextView" : "//XCUIElementTypeStaticText";
                string textXPath = $"[contains(@{attribute}, \"{text}\")]";
                if (isFullText)
                    textXPath = $"[@{attribute}=\"{text}\"]";
                return Selene.S(MobileBy.XPath($"//*{textXPath}")).With(timeout: 20);
            }
            else
            {
                if (isFullText)
                    return Selene.S(MobileBy.IosClassChain($"**/*[`label == \"{text}\"`]")).With(timeout: 20);
                else
                    return Selene.S(MobileBy.IosClassChain($"**/*[`label CONTAINS \"{text}\"`]")).With(timeout: 20);
            }
        }

        public virtual SeleneElement ScrollToElement(string acessebilityId)
        {
            if (MobileDriver.IsAndroid)
            {
                SeleneElement element = Selene.S(MobileBy.AndroidUIAutomator($"new UiScrollable(new UiSelector().scrollable(true).instance(0)).setMaxSearchSwipes(15).scrollIntoView(new UiSelector().description(\"{acessebilityId}\"))"));
                element.With(timeout: 5).Matching(Be.InDom);
                return element;
            }
            else
            {
                SeleneElement elem = Selene.S(MobileBy.AccessibilityId(acessebilityId));
                for (int i = 0; i < 2; i++)
                {                   
                    Dictionary<string, string> scrollObject = new Dictionary<string, string>();
                    scrollObject.Add("direction", "down");
                    ((IJavaScriptExecutor)MobileDriver.Driver).ExecuteScript("mobile: scroll", scrollObject);                    
                }
                return elem;
            }
        }

        public virtual void ScrollToItemByText(string textContent)
        {
            if (MobileDriver.IsAndroid)
            {
                SeleneElement element = Selene.S(MobileBy.AndroidUIAutomator(
                    $"new UiScrollable(new UiSelector().scrollable(true).instance(0)).setMaxSearchSwipes(10).scrollIntoView(new UiSelector().text(\"{textContent}\"))"
                    ));
                element.With(timeout: 5).Matching(Be.InDom);
            }
            else
            {
                SeleneElement elem = GetTextItemWithWait(textContent);
                var scrollParams = new Dictionary<string, string>
                {
                    {"element", ((AppiumWebElement)elem.ActualWebElement).Id },
                    {"direction", "down" }
                };
                _driver.ExecuteScript("mobile: scroll", scrollParams);
            }
        }

        public virtual void TapOnModalButtonByCoordinates(SeleneElement element)
        {
            new TouchAction(_driver).Press(element.Location.X + 5,
                    element.Location.Y + 5).Wait(2).Release().Perform();
        }

        public virtual void TapOnModalButtonByCoordinates(SeleneElement element, double xLocation, double yLocation)
        {
            new TouchAction(_driver).Press(element.Location.X * xLocation,
                    element.Location.Y * yLocation).Wait(2).Release().Perform();
        }

        public static bool IsCanadianFormatDate(string date, string cultureVariable = "ru-RU")
        {
            return DateTime.TryParse(date, CultureInfo.CreateSpecificCulture(cultureVariable), DateTimeStyles.None, out DateTime dateTime);
        }

        public static string ParseTime(string dateTime)
        {
            Match parseTime = Regex.Match(dateTime, @"(\d{1,2}):(\d{2})(am|pm)");
            int hours = int.Parse(parseTime.Groups[1].Value);
            int minutes = int.Parse(parseTime.Groups[2].Value);
            bool isPM = parseTime.Groups[3].Value.Contains("pm");
            DateTime todayDate = DateTime.Today.AddHours(hours).AddMinutes(minutes);
            if (isPM && hours != 12)
            {
                todayDate = todayDate.AddHours(12);
            }
            return todayDate.ToShortTimeString();
        }
        public virtual void LongPress(AppiumWebElement element)
        {
            action.LongPress(element)
               .Wait(200)
               .Release()
               .Perform();
            action.Cancel();
        }

        public virtual void ScrollUp(double screenWidthTap, double screenHeightTap, double screenHeightRelease)
        {
            Size screenSize = _driver.Manage().Window.Size;
            int screenWidth = screenSize.Width;
            int screenHeight = screenSize.Height;
            action.Press(screenWidth * screenWidthTap, screenHeight * screenHeightTap);
            action.Wait(200);
            action.MoveTo(screenWidth * screenWidthTap, screenHeight * screenHeightRelease)
                .Release()
                .Perform();
            action.Cancel();
        }
        public void TapLogoElement(SeleneElement element, int count)
        {
            try
            {
                action.Tap(element.Location.X, element.Location.Y, count)
                    .Perform();
                action.Cancel();
            }
            catch (Exception)
            {
                IWebElement logo = _driver.FindElement("-ios predicate string", "type =='XCUIElementTypeImage' AND name =='logo.png' AND visible == 1");

                action.Tap(logo.Location.X, logo.Location.Y, 8)
                  .Perform();
                action.Cancel();
            }
        }
        public int GetElementYCoordinates(SeleneElement element)
        {
            return element.Location.Y;
        }

        public void ClickElement(SeleneElement element)
        {
            element.With(timeout: 10).Click();
        }

       public bool ValidateElementIsDisplayed(SeleneElement element)
        {
            return element.Displayed;
        }
            

        public void EnterText(SeleneElement element, string text)
        {
            element.With(timeout: 5).Click();
            element.With(timeout: 5).Clear();
            element.With(timeout: 5).SendKeys(text);
        }

        public void PressKey(SeleneElement element, string text)
        {
            element.With(timeout: 5).SendKeys(text);
        }

        public static string GetElementText(SeleneElement elements)
        {
            if (MobileDriver.IsIOS)
            {
                return elements.With(timeout: 30).GetAttribute("label");
            }
            else
            {
                return elements.With(timeout: 30).GetAttribute("text");
            }
        }

        public void TapOnCoordinates(int x, int y)
        {
            // Initialize TouchAction for tapping
            TouchAction touchAction = new TouchAction(MobileDriver.Driver);

            // Perform the tap on the given coordinates
            touchAction.Tap(x, y).Perform();
        }

        public static string GetElementByLabel(SeleneElement elements)
        {
            if (MobileDriver.IsIOS)
            {
                return elements.With(timeout: 30).GetAttribute("label");
            }
            else
            {
                return elements.With(timeout: 30).GetAttribute("text");
            }
        }

        public void WaitForElementToBeVisible(SeleneElement element)
        {
            element.With(timeout: 15).Should(Be.Visible);
        }

        public virtual SeleneElement ScrollToElements(string acessebilityId)
        {
            if (MobileDriver.IsAndroid)
            {
                SeleneElement element = Selene.S(MobileBy.AndroidUIAutomator($"new UiScrollable(new UiSelector().scrollable(true).instance(0)).setMaxSearchSwipes(10).scrollIntoView(new UiSelector().description(\"{acessebilityId}\"))"));
                element.With(timeout: 5).Matching(Be.InDom);
                return element;
            }
            else
            {
                SeleneElement elem = Selene.S(MobileBy.AccessibilityId(acessebilityId));
                Dictionary<string, string> scrollObject = new Dictionary<string, string>();
                scrollObject.Add("direction", "down");
                ((IJavaScriptExecutor)MobileDriver.Driver).ExecuteScript("mobile: scroll", scrollObject);

                return elem;
            }
        }

        public virtual SeleneElement ScrollDownToElements(string accessibilityId)
        {
            if (MobileDriver.IsAndroid)
            {
                SeleneElement element = Selene.S(MobileBy.AndroidUIAutomator($"new UiScrollable(new UiSelector().scrollable(true).instance(0)).setMaxSearchSwipes(1).scrollIntoView(new UiSelector().description(\"{accessibilityId}\"))"));
                element.With(timeout: 5).Matching(Be.InDom);
                return element;
            }
            else
            {
                SeleneElement elem = Selene.S(MobileBy.AccessibilityId(accessibilityId));
                Dictionary<string, string> scrollObject = new Dictionary<string, string>();
                scrollObject.Add("direction", "down");
                ((IJavaScriptExecutor)MobileDriver.Driver).ExecuteScript("mobile: scroll", scrollObject);

                return elem;
            }
        }




        public virtual SeleneElement ScrollUpToElements(string accessibilityId)
        {
            if (MobileDriver.IsAndroid)
            {
                SeleneElement element = Selene.S(MobileBy.AndroidUIAutomator($"new UiScrollable(new UiSelector().scrollable(true).instance(0)).setMaxSearchSwipes(1).scrollIntoView(new UiSelector().description(\"{accessibilityId}\"))"));
                element.With(timeout: 5).Matching(Be.InDom);
                return element;
            }
            else
            {
                SeleneElement elem = Selene.S(MobileBy.AccessibilityId(accessibilityId));

                // iOS specific scroll logic to scroll to 1/4 of the screen
                Dictionary<string, object> scrollObject = new Dictionary<string, object>
        {
            { "direction", "up" },
            { "element", elem.ActualWebElement },  // GetWebElement() retrieves the actual WebElement from SeleneElement
            { "percent", 0.75 }  // Scrolls down by 1/2 of the screen height
        };

                ((IJavaScriptExecutor)MobileDriver.Driver).ExecuteScript("mobile: scroll", scrollObject);

                return elem;
            }
        }

        public virtual void ScrollDownHalfScreen()
        {
            if (MobileDriver.IsAndroid)
            {
                var size = MobileDriver.Driver.Manage().Window.Size;
                int startX = size.Width / 2;
                int startY = (int)(size.Height * 0.75);
                int endY = (int)(size.Height * 0.25);

                new TouchAction(MobileDriver.Driver)
                    .Press(startX, startY)
                    .Wait(5000)
                    .MoveTo(startX, endY)
                    .Release()
                    .Perform();
            }
            else
            {
                for (int i = 0; i < 2; i++) // Scroll 2 times on iOS
                {
                    Dictionary<string, object> scrollObject = new Dictionary<string, object>
            {
                { "direction", "down" },
                { "percent", 0.75 }
            };

                    ((IJavaScriptExecutor)MobileDriver.Driver).ExecuteScript("mobile: scroll", scrollObject);
                }
            }
        }


        public virtual void ScrollUpHalfScreen()
        {
            if (MobileDriver.IsAndroid)
            {
                var size = MobileDriver.Driver.Manage().Window.Size;
                int startX = size.Width / 2;
                int startY = (int)(size.Height * 0.75);
                int endY = (int)(size.Height * 0.25);

                new TouchAction(MobileDriver.Driver)
                    .Press(startX, startY)
                    .Wait(5000)
                    .MoveTo(startX, endY)
                    .Release()
                    .Perform();
            }
            else
            {
               Dictionary<string, object> scrollObject = new Dictionary<string, object>
        {
            { "direction", "up" },
            { "percent", 0.15 }  
        };

                ((IJavaScriptExecutor)MobileDriver.Driver).ExecuteScript("mobile: scroll", scrollObject);
            }
        }

        public void DrawSignature(SeleneElement signatureLocator)
        {
            // Get the element's location and size
            var location = signatureLocator.Location;
            var size = signatureLocator.Size;

            // Define points to simulate a signature
            int startX = location.X + (int)(size.Width * 0.2);
            int startY = location.Y + (int)(size.Height * 0.5);
            int midX = location.X + (int)(size.Width * 0.5);
            int midY = location.Y + (int)(size.Height * 0.7);
            int endX = location.X + (int)(size.Width * 0.8);
            int endY = location.Y + (int)(size.Height * 0.5);

            // Create a new TouchAction object
            var touchAction = new TouchAction(MobileDriver.Driver);

            // Draw a simple signature by moving through a few points
            touchAction.Press(startX, startY)
                       .MoveTo(midX, midY)
                       .MoveTo(endX, endY)
                       .Release()
                       .Perform();
        }

        public void ScrollHalfOfTheScreen()
        {
            var screenSize = MobileDriver.Driver.Manage().Window.Size;

            // Define the scroll duration and the starting and ending coordinates
            int scrollDuration = 1000; // in milliseconds
            int startY = (int)(screenSize.Height * 0.75);
            int endY = (int)(screenSize.Height * 0.25);
            int centerX = screenSize.Width / 2;

            // Perform the scroll action using TouchAction class
            ITouchAction touchAction = new TouchAction(MobileDriver.Driver);
            touchAction.Press(centerX, startY).Wait(scrollDuration).MoveTo(centerX, endY).Release().Perform();
        }

        public void WaitForObjectToBeVisible(SeleneElement element)
        {
            WebDriverWait wait = new WebDriverWait(MobileDriver.Driver, TimeSpan.FromSeconds(30));

            wait.Until(driver =>
            {
                try
                {
                    return element.ActualWebElement.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void WaitForElementToBeClickable()
        {
            Task.Delay(8000).Wait();
        }       

        public void WaitForElement(int time)
        {
            Task.Delay(time).Wait();
        }



    }


}

