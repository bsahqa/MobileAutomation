using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using System;
using System.Collections.Generic;

namespace MobileAutomation.Tools
{
    abstract class DriverFactory
    {
        public Dictionary<string, string> CommandExecutorUrls => new Dictionary<string, string>
        {
            { "LocalExecutor", "http://localhost:4723/" },
            { "RemoteExecutor", $"https://{DataContext.BSUser}:{DataContext.BSToken}@hub-cloud.browserstack.com/wd/hub" }
        };
        public abstract AppiumDriver<AppiumWebElement> GetAppiumDriver(AppiumOptions appiumOptions);

        public string GetCommandExecutorUrl()
        {
            if (AutomationContext.Data.ContainsKey("CommandExecutorUrl"))
                return AutomationContext.Data["CommandExecutorUrl"] as string;
            string runType = MobileDriver.GetRunType();
            AutomationContext.Data["CommandExecutorUrl"] = CommandExecutorUrls[runType];
            return CommandExecutorUrls[runType];
        }
    }

    class AndroidDriverFactory : DriverFactory
    {
        public override AppiumDriver<AppiumWebElement> GetAppiumDriver(AppiumOptions appiumOptions)
        {
            string url = GetCommandExecutorUrl();
            return new AndroidDriver<AppiumWebElement>(new Uri(url), appiumOptions);
        }
    }

    class IOSDriverFactory : DriverFactory
    {
        public override AppiumDriver<AppiumWebElement> GetAppiumDriver(AppiumOptions appiumOptions)
        {
            string url = GetCommandExecutorUrl();
            return new IOSDriver<AppiumWebElement>(new Uri(url), appiumOptions);
        }
    }
}
