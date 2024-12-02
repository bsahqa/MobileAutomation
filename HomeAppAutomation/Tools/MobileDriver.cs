using HomeAppAutomations.Steps;
using HomeAppAutomations.Tools;
using Newtonsoft.Json.Linq;
using NSelene;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Diagnostics;

namespace HomeAppAutomations
{
    static class MobileDriver
    {
        public static AppiumDriver<AppiumWebElement> Driver => _driver;
        private static AppiumDriver<AppiumWebElement> _driver;
        private readonly static int newCommandTimeoutSeconds = 60000;
        public static bool IsDriverActive { get; private set; }
        public static System.Drawing.Size ScreenParams { get; private set; }
        public static WebDriverWait uiCheckStatusWait;
        public static WebDriverWait shortWait;
        public static WebDriverWait longWait;
        private readonly static string testingOS = GetTestingOS();
        private static string projectDir;
        private static bool workOrderInvoiceAuthorized = false;
        private static bool screenRecordingRunning = false;

        public static bool WorkOrderInvoiceAuthorized
        {
            get
            {
                return workOrderInvoiceAuthorized;
            }
            set
            {
                workOrderInvoiceAuthorized = value;
            }
        }

        public static string TestingOS => testingOS;

        public static bool IsMOQBuild => DataContext.isMOQBuild;
        public static bool MasterUserPreLoginRequired => Environment.GetEnvironmentVariable("MASTER_USER_PRELOGIN") != null;

        public static bool IsAndroid => TestingOS.Contains(AndroidOSName);
        public static bool IsIOS => TestingOS.Contains(IOSName);
        public static bool IsPhone => DataContext.DeviceType.Equals(PhoneDeviceType);
        public static bool IsTablet => DataContext.DeviceType.Equals(TabletDeviceType);

        private static string runStartTime;

        public static string RunStartTime
        {
            get
            {
                return runStartTime;
            }

            set
            {
                runStartTime = String.IsNullOrEmpty(runStartTime) ? value : runStartTime;
            }
        }

        public static void SetStartRun()
        {
            RunStartTime = DateTime.Now.ToString("dd.MM.yyyy__H.mm");
        }

        public static string AndroidOSName => "Android";
        public static string IOSName => "iOS";
        public static string PhoneDeviceType => "Phone";
        public static string TabletDeviceType => "Tablet";

        public static Dictionary<string, string> AppLocations => new Dictionary<string, string>
        {
            { AndroidOSName, DataContext.AndroidBuildFile },
            { IOSName, DataContext.iOSBuildFile }
        };

        private static Dictionary<string, DriverFactory> factories = new Dictionary<string, DriverFactory>
        {
            {AndroidOSName, new AndroidDriverFactory() },
            {IOSName, new IOSDriverFactory() }
        };

        public static void PushFile(string localFile = "equipmentImage.jpg", string devicePath = "/storage/emulated/0/Pictures/FieldEdge")
        {
            string deviceFilePath = $"{devicePath}/{localFile}";
            string localFilePath = Path.Combine(ProjectDirectory, localFile);
            _driver.PushFile(deviceFilePath, new FileInfo(localFilePath));
        }
        public static string GetAppUrl()
        {
            AutomationContext.InitializeSteps();
            APISteps ApiSteps = AutomationContext.Steps["APISteps"] as APISteps;
            string releaseVersion = GetTestingReleaseVersion();
            if (!IsLatestBuildRequired())
            {
                JObject appItem = ApiSteps.UploadAppCenterMobileBuildToBrowserStack(releaseVersion);
                return appItem["app_url"].ToString();
            }
            else
            {
                JObject appItem = ApiSteps.UploadAppCenterMobileLatestBuildToBrowserStack();
                return appItem["app_url"].ToString();
            }
        }

        public static void StartDriver(AppiumOptions options)
        {
            _driver = GetRequiredDriver(options);
            Configuration.Driver = Driver;
            IsDriverActive = true;
            ScreenParams = Driver.Manage().Window.Size;
            uiCheckStatusWait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(100));
            shortWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            longWait = new WebDriverWait(Driver, TimeSpan.FromMinutes(10));
        }

        public static string GetScreenshot()
        {
            if (IsDriverActive)
            {
                Screenshot screen = Driver.GetScreenshot();
                string directory = $"{ProjectDirectory}{Path.DirectorySeparatorChar}run{RunStartTime}";
                Directory.CreateDirectory(directory);
                string test = $"{TestContext.CurrentContext.Test.ClassName}_{TestContext.CurrentContext.Test.MethodName}";
                string fileName = $"{directory}{Path.DirectorySeparatorChar}{test}.png";
                screen.SaveAsFile(fileName);
                return fileName;
            }
            return null;
        }

        public static string GetScreenMarkup()
        {
            string currentTest = $"{TestContext.CurrentContext.Test.ClassName}_{TestContext.CurrentContext.Test.MethodName}";
            string directory = $"{ProjectDirectory}{Path.DirectorySeparatorChar}run{RunStartTime}";
            Directory.CreateDirectory(directory);
            string fileName = $"{directory}{Path.DirectorySeparatorChar}{currentTest}.xml";
            StreamWriter xmlWriter = new StreamWriter(fileName, false, Encoding.ASCII);
            xmlWriter.WriteLine(Driver.PageSource);
            xmlWriter.Close();
            return fileName;
        }

        public static bool DisposeDriver()
        {
            bool shouldBeRestarted = IsDriverActive;
            if (IsDriverActive)
            {
                Configuration.Driver = null;
                IsDriverActive = false;
                Driver.Quit();
            }
            return shouldBeRestarted;
        }

        public static AppiumOptions SingleSessionLocalAndroidOptions
        {
            get
            {
                AppiumOptions options = new AppiumOptions();

                string projectDirectory = ProjectDirectory;
                string appPath = $@"{projectDirectory}{Path.DirectorySeparatorChar}AppBuilds{Path.DirectorySeparatorChar}{AppLocations[GetTestingOS()]}";
                options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
                options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Pixel6");
                options.AddAdditionalCapability(MobileCapabilityType.App, appPath);
                options.AddAdditionalCapability("appium:appPackage", DataContext.AndroidAppPackage);
                options.AddAdditionalCapability("appium:appActivity", DataContext.AndroidAppActivity);
                options.AddAdditionalCapability(MobileCapabilityType.FullReset, true);
                options.AddAdditionalCapability("appium:autoGrantPermissions", true);
                options.AddAdditionalCapability("appium:automationName", "UiAutomator2");
                options.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, newCommandTimeoutSeconds);
                return options;
            }
        }

        public static AppiumOptions FlowRunSessionLocalAndroidOptions
        {
            get
            {
                AppiumOptions options = new AppiumOptions();

                string projectDirectory = ProjectDirectory;
                string appPath = $@"{projectDirectory}{Path.DirectorySeparatorChar}AppBuilds{Path.DirectorySeparatorChar}{AppLocations[GetTestingOS()]}";
                options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
                options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "emulator-5554");
                options.AddAdditionalCapability(MobileCapabilityType.App, appPath);
                options.AddAdditionalCapability("appium:appPackage", DataContext.AndroidAppPackage);
                options.AddAdditionalCapability("appium:appActivity", DataContext.AndroidAppActivity);
                options.AddAdditionalCapability(MobileCapabilityType.NoReset, true);
                options.AddAdditionalCapability("appium:autoGrantPermissions", true);
                options.AddAdditionalCapability("appium:automationName", "UiAutomator2");
                options.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, newCommandTimeoutSeconds);
                return options;
            }
        }

        public static AppiumOptions FlowRunSessionLocalAndroidTabletOptions
        {
            get
            {
                AppiumOptions options = new AppiumOptions();
                string projectDirectory = ProjectDirectory;
                string appPath = $@"{projectDirectory}{Path.DirectorySeparatorChar}AppBuilds{Path.DirectorySeparatorChar}{AppLocations[GetTestingOS()]}";
                options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
                options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "emulator-5554");
                options.AddAdditionalCapability(MobileCapabilityType.App, appPath);
                options.AddAdditionalCapability("appium:appPackage", DataContext.AndroidAppPackage);
                options.AddAdditionalCapability("appium:appActivity", DataContext.AndroidAppActivity);
                options.AddAdditionalCapability(MobileCapabilityType.NoReset, true);
                options.AddAdditionalCapability("appium:autoGrantPermissions", true);
                options.AddAdditionalCapability("appium:automationName", "UiAutomator2");
                options.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, newCommandTimeoutSeconds);
                return options;
            }
        }

        public static AppiumOptions RemoteSessionSingleRunOptions
        {
            get
            {
                AppiumOptions mobileOptions = new AppiumOptions();
                string osVersion = GetTestingAndroidOSVersion();
                string deviceName = GetTestingAndroidDeviceName();
                string appURL = GetTestingBuildPathAndroid();
                mobileOptions.AddAdditionalCapability("projectName", DataContext.ProjectName);
                mobileOptions.AddAdditionalCapability("buildName", DataContext.BuildNameAndroid);
                mobileOptions.AddAdditionalCapability("browserstack.user", DataContext.BSUser);
                mobileOptions.AddAdditionalCapability("browserstack.key", DataContext.BSToken);
                mobileOptions.AddAdditionalCapability("device", deviceName);
                mobileOptions.AddAdditionalCapability("os_version", osVersion);
                mobileOptions.AddAdditionalCapability("app_url", appURL);
                mobileOptions.AddAdditionalCapability("appPackage", DataContext.AndroidAppPackage);
                mobileOptions.AddAdditionalCapability("appActivity", DataContext.AndroidAppActivity);
                mobileOptions.AddAdditionalCapability("autoAcceptAlerts", true);
                mobileOptions.AddAdditionalCapability("autoDismissAlerts", true);
                mobileOptions.AddAdditionalCapability("autoGrantPermissions", true);
                mobileOptions.AddAdditionalCapability("browserstack.enableCameraImageInjection", "true");
                mobileOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UiAutomator2");
                mobileOptions.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name);
                TestContext.Progress.WriteLine("Added capabilities for remote run");
                return mobileOptions;
            }
        }

        public static AppiumOptions RemoteSessionSingleRunOptionsTablet
        {
            get
            {
                AppiumOptions mobileOptions = new AppiumOptions();
                string osVersion = GetTestingAndroidOSVersion();
                string deviceName = GetTestingAndroidDeviceName();
                string appURL = GetTestingBuildPathAndroid();
                mobileOptions.AddAdditionalCapability("projectName", DataContext.ProjectName);
                mobileOptions.AddAdditionalCapability("buildName", DataContext.BuildNameAndroid);
                mobileOptions.AddAdditionalCapability("browserstack.user", DataContext.BSUser);
                mobileOptions.AddAdditionalCapability("browserstack.key", DataContext.BSToken);
                mobileOptions.AddAdditionalCapability("device", deviceName);
                mobileOptions.AddAdditionalCapability("os_version", osVersion);
                mobileOptions.AddAdditionalCapability("app_url", appURL);
                mobileOptions.AddAdditionalCapability("appPackage", DataContext.AndroidAppPackage);
                mobileOptions.AddAdditionalCapability("appActivity", DataContext.AndroidAppActivity);
                mobileOptions.AddAdditionalCapability(MobileCapabilityType.FullReset, true);
                mobileOptions.AddAdditionalCapability("autoGrantPermissions", true);
                mobileOptions.AddAdditionalCapability("interactiveDebugging", true);
                mobileOptions.AddAdditionalCapability("video", true);
                mobileOptions.AddAdditionalCapability("browserstack.networkLogs", true);
                mobileOptions.AddAdditionalCapability("browserstack.enableCameraImageInjection", "true");
                mobileOptions.AddAdditionalCapability("locale", "eng_US");
                mobileOptions.AddAdditionalCapability("language", "eng_US");
                mobileOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UiAutomator2");
                mobileOptions.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name);
                TestContext.Progress.WriteLine("Added capabilities for remote run");
                return mobileOptions;
            }
        }

        public static AppiumOptions RemoteSessionSingleRunIOSOptions
        {
            get
            {
                AppiumOptions mobileOptions = new AppiumOptions();
                string osVersion = GetTestingiOSOSVersion();
                string deviceName = GetTestingiOSDeviceName();
                string appURL = GetTestingBuildPathIOS();
                mobileOptions.AddAdditionalCapability("projectName", DataContext.ProjectName);
                mobileOptions.AddAdditionalCapability("buildName", DataContext.BuildNameIos);
                mobileOptions.AddAdditionalCapability("browserstack.user", DataContext.BSUser);
                mobileOptions.AddAdditionalCapability("browserstack.key", DataContext.BSToken);
                mobileOptions.AddAdditionalCapability("device", deviceName);
                mobileOptions.AddAdditionalCapability("os_version", osVersion);
                mobileOptions.AddAdditionalCapability("app_url", appURL);
               // mobileOptions.AddAdditionalCapability("autoGrantPermissions", true);
                mobileOptions.AddAdditionalCapability("interactiveDebugging", true);
                //mobileOptions.AddAdditionalCapability("autoAcceptAlerts", true);
               // mobileOptions.AddAdditionalCapability("autoDismissAlerts", false);
                mobileOptions.AddAdditionalCapability("video", true);
                mobileOptions.AddAdditionalCapability("browserstack.networkLogs", true);
                mobileOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "XCUITest");
                mobileOptions.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name);
                mobileOptions.AddAdditionalCapability("locale", "eng_US");
                mobileOptions.AddAdditionalCapability("language", "eng_US");
                TestContext.Progress.WriteLine("Added capabilities for remote run");
                return mobileOptions;
            }
        }

        public static AppiumOptions GetLatestRemoteSessionSingleRunOptions(string appUrl)
        {
            AppiumOptions mobileOptions = new AppiumOptions();
            string osVersion = GetTestingAndroidOSVersion();
            string deviceName = GetTestingAndroidDeviceName();
            mobileOptions.AddAdditionalCapability("projectName", DataContext.ProjectName);
            mobileOptions.AddAdditionalCapability("buildName", DataContext.BuildNameAndroid);
            mobileOptions.AddAdditionalCapability("browserstack.user", DataContext.BSUser);
            mobileOptions.AddAdditionalCapability("browserstack.key", DataContext.BSToken);
            mobileOptions.AddAdditionalCapability("device", deviceName);
            mobileOptions.AddAdditionalCapability("os_version", osVersion);
            mobileOptions.AddAdditionalCapability("app_url", appUrl);
            mobileOptions.AddAdditionalCapability("appPackage", DataContext.AndroidAppPackage);
            mobileOptions.AddAdditionalCapability("appActivity", DataContext.AndroidAppActivity);
            mobileOptions.AddAdditionalCapability(MobileCapabilityType.FullReset, true);
            mobileOptions.AddAdditionalCapability("autoGrantPermissions", true);
            mobileOptions.AddAdditionalCapability("interactiveDebugging", true);
            mobileOptions.AddAdditionalCapability("video", true);
            mobileOptions.AddAdditionalCapability("browserstack.networkLogs", true);
            mobileOptions.AddAdditionalCapability("browserstack.enableCameraImageInjection", "true");
            mobileOptions.AddAdditionalCapability("locale", "eng_US");
            mobileOptions.AddAdditionalCapability("language", "eng_US");
            mobileOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UiAutomator2");
            mobileOptions.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name);
            TestContext.Progress.WriteLine("Added capabilities for remote run");
            return mobileOptions;
        }

        public static AppiumOptions GetLatestRemoteSessionSingleRunOptionsTablet(string appUrl)
        {
            AppiumOptions mobileOptions = new AppiumOptions();
            string osVersion = GetTestingAndroidOSVersion();
            string deviceName = GetTestingAndroidDeviceName();
            mobileOptions.AddAdditionalCapability("projectName", DataContext.ProjectName);
            mobileOptions.AddAdditionalCapability("buildName", DataContext.BuildNameAndroid);
            mobileOptions.AddAdditionalCapability("browserstack.user", DataContext.BSUser);
            mobileOptions.AddAdditionalCapability("browserstack.key", DataContext.BSToken);
            mobileOptions.AddAdditionalCapability("device", deviceName);
            mobileOptions.AddAdditionalCapability("os_version", osVersion);
            mobileOptions.AddAdditionalCapability("app_url", appUrl);
            mobileOptions.AddAdditionalCapability("appPackage", DataContext.AndroidAppPackage);
            mobileOptions.AddAdditionalCapability("appActivity", DataContext.AndroidAppActivity);
            mobileOptions.AddAdditionalCapability(MobileCapabilityType.FullReset, true);
            mobileOptions.AddAdditionalCapability("autoGrantPermissions", true);
            mobileOptions.AddAdditionalCapability("interactiveDebugging", true);
            mobileOptions.AddAdditionalCapability("video", true);
            mobileOptions.AddAdditionalCapability("browserstack.networkLogs", true);
            mobileOptions.AddAdditionalCapability("browserstack.enableCameraImageInjection", "true");
            mobileOptions.AddAdditionalCapability("locale", "eng_US");
            mobileOptions.AddAdditionalCapability("language", "eng_US");
            mobileOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UiAutomator2");
            mobileOptions.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name);
            TestContext.Progress.WriteLine("Added capabilities for remote run");
            return mobileOptions;
        }

        public static AppiumOptions GetLatestRemoteSessionSingleRunIOSOptions(string appUrl)
        {
            AppiumOptions mobileOptions = new AppiumOptions();
            string osVersion = GetTestingiOSOSVersion();
            string deviceName = GetTestingiOSDeviceName();
            mobileOptions.AddAdditionalCapability("projectName", DataContext.ProjectName);
            mobileOptions.AddAdditionalCapability("buildName", DataContext.BuildNameIos);
            mobileOptions.AddAdditionalCapability("browserstack.user", DataContext.BSUser);
            mobileOptions.AddAdditionalCapability("browserstack.key", DataContext.BSToken);
            mobileOptions.AddAdditionalCapability("device", deviceName);
            mobileOptions.AddAdditionalCapability("os_version", osVersion);
            mobileOptions.AddAdditionalCapability("app_url", appUrl);
            mobileOptions.AddAdditionalCapability("autoGrantPermissions", true);
            mobileOptions.AddAdditionalCapability("interactiveDebugging", true);
            mobileOptions.AddAdditionalCapability("video", true);
            mobileOptions.AddAdditionalCapability("browserstack.networkLogs", true);
            mobileOptions.AddAdditionalCapability("locale", "eng_US");
            mobileOptions.AddAdditionalCapability("language", "eng_US");
            mobileOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "XCUITest");
            mobileOptions.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name);
            TestContext.Progress.WriteLine("Added capabilities for remote run");
            return mobileOptions;
        }

        public static AppiumOptions IOSOptions
        {
            get
            {
                AppiumOptions mobileOptions = new AppiumOptions();
                string projectDirectory = ProjectDirectory;
                string appPath = $@"{projectDirectory}{Path.DirectorySeparatorChar}AppBuilds{Path.DirectorySeparatorChar}{AppLocations[GetTestingOS()]}";

                mobileOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "iOS");
                mobileOptions.AddAdditionalCapability("appium:platformVersion", "17.5");
                mobileOptions.AddAdditionalCapability("appium:deviceName", "iPhone 15 Pro Max");
                // mobileOptions.AddAdditionalCapability("appium:xcodeOrgId", "M65LBRHVV9");
                // mobileOptions.AddAdditionalCapability("appium:udid", "e7b0826c63cc2df7d7b0a8eee4e2b5422f7c3c40");
                mobileOptions.AddAdditionalCapability("appium:app", appPath);
                mobileOptions.AddAdditionalCapability("appium:noReset", false);
                mobileOptions.AddAdditionalCapability("appium:autoGrantPermissions", true);
                mobileOptions.AddAdditionalCapability("appium:automationName", "XCUITest");
                mobileOptions.AddAdditionalCapability("appium:newCommandTimeout", 300);
                return mobileOptions;
            }
        }

        public static Dictionary<string, AppiumOptions> SingleSessionOptions
        {
            get
            {
                AppiumOptions remoteOptions;
                if (IsTablet)
                {
                    remoteOptions = IsLatestBuildRequired() ? GetLatestRemoteSessionSingleRunOptionsTablet(GetAppUrl()) : RemoteSessionSingleRunOptionsTablet;
                }
                else
                {
                    remoteOptions = IsLatestBuildRequired() ? GetLatestRemoteSessionSingleRunOptions(GetAppUrl()) : RemoteSessionSingleRunOptions;
                }

                AppiumOptions remoteIOSOptions = IsLatestBuildRequired() ? GetLatestRemoteSessionSingleRunIOSOptions(GetAppUrl()) : RemoteSessionSingleRunIOSOptions;

                return new Dictionary<string, AppiumOptions>
                {
                    {"Android", IsRemoteRun ? remoteOptions : SingleSessionLocalAndroidOptions},
                    {"iOS", IsRemoteRun ? remoteIOSOptions: RemoteSessionSingleRunIOSOptions}
                };
            }
        }

        public static Dictionary<string, AppiumOptions> FlowSessionOptions
        {
            get
            {
                AppiumOptions remoteOptions;
                if (IsTablet)
                {
                    remoteOptions = IsLatestBuildRequired() ? GetLatestRemoteSessionSingleRunOptionsTablet(GetAppUrl()) : RemoteSessionSingleRunOptionsTablet;
                }
                else
                {
                    remoteOptions = IsLatestBuildRequired() ? GetLatestRemoteSessionSingleRunOptions(GetAppUrl()) : RemoteSessionSingleRunOptions;
                }

                AppiumOptions remoteIOSOptions = IsLatestBuildRequired() ? GetLatestRemoteSessionSingleRunIOSOptions(GetAppUrl()) : RemoteSessionSingleRunIOSOptions;

                return new Dictionary<string, AppiumOptions>
                {
                    {"Android", IsRemoteRun ? remoteOptions : RemoteSessionSingleRunOptions},
                    {"iOS", IsRemoteRun? remoteIOSOptions: IOSOptions}
                };
            }
        }

        public static string GetTestingOS()
        {
            string testingOS = Environment.GetEnvironmentVariable("TESTING_OS");
            testingOS = String.IsNullOrEmpty(testingOS) ? DataContext.AlternateTestingOS : testingOS;
            return testingOS;
        }

        public static string GetTestingiOSOSVersion()
        {
            string osVersion = Environment.GetEnvironmentVariable("OS_VERSION");
            osVersion = String.IsNullOrEmpty(osVersion) ? DataContext.iOSOSVersion : osVersion;
            return osVersion;
        }
        public static string GetTestingAndroidOSVersion()
        {
            string osVersion = Environment.GetEnvironmentVariable("OS_VERSION");
            osVersion = String.IsNullOrEmpty(osVersion) ? DataContext.AndroidOSVersion : osVersion;
            return osVersion;
        }

        public static string GetTestingiOSDeviceName()
        {
            string deviceName = Environment.GetEnvironmentVariable("DEVICE_NAME");
            deviceName = String.IsNullOrEmpty(deviceName) ? DataContext.iOSDeviceName : deviceName;
            return deviceName;
        }

        public static string GetTestingAndroidDeviceName()
        {
            string deviceName = Environment.GetEnvironmentVariable("DEVICE_NAME");
            deviceName = String.IsNullOrEmpty(deviceName) ? DataContext.AndroidDeviceName : deviceName;
            return deviceName;
        }
        public static string GetTestingBuildPathAndroid()
        {
            string path = Environment.GetEnvironmentVariable("ANDROID_PATH");
            path = String.IsNullOrEmpty(path) ? DataContext.BSAndroidAppPath : path;
            return path;
        }
        public static string GetTestingBuildPathIOS()
        {
            string path = Environment.GetEnvironmentVariable("IOS_PATH");
            path = String.IsNullOrEmpty(path) ? DataContext.BSiOSAppPath : path;
            return path;
        }
        public static bool IsTestReleaseProduction()
        {
            string releaseType = Environment.GetEnvironmentVariable("IS_PROD_RELEASE");
            bool isProd = string.IsNullOrEmpty(releaseType) ? DataContext.isProductionBuild : releaseType.Equals("true");
            return isProd;
        }
        public static bool IsLatestBuildRequired()
        {
            string latestBuildRequiredSet = Environment.GetEnvironmentVariable("IS_LATEST_BUILD_REQUIRED");
            bool isLatestBuildRequired = string.IsNullOrEmpty(latestBuildRequiredSet) ? DataContext.LatestBuildRequired : latestBuildRequiredSet.Equals("true");
            return isLatestBuildRequired;
        }
        public static string GetTestingReleaseVersion()
        {
            string version = Environment.GetEnvironmentVariable("RELEASE_VERSION");
            version = String.IsNullOrEmpty(version) ? DataContext.ReleaseVersion : version;
            return version;
        }
        private static AppiumDriver<AppiumWebElement> GetRequiredDriver(AppiumOptions options)
        {
            AppiumDriver<AppiumWebElement> driver = factories[TestingOS].GetAppiumDriver(options);
            return driver;
        }

        public static string ProjectDirectory
        {
            get
            {
                if (string.IsNullOrEmpty(projectDir))
                {
                    string binDirectory = Directory.GetCurrentDirectory();
                    int binSubDirOccurrence = binDirectory.IndexOf($"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}Debug");
                    projectDir = binDirectory[0..binSubDirOccurrence];
                }
                return projectDir;
            }
        }

        public static void AddScreenAttachment(string message)
        {
            string screenDirectory = GetScreenshot();
            if (screenDirectory != null)
                TestContext.AddTestAttachment(screenDirectory, message);
        }
        public static string GetRunType()
        {
            string runType = Environment.GetEnvironmentVariable("RUN_TYPE");
            runType = string.IsNullOrEmpty(runType) ? DataContext.RunType : runType;
            return runType;
        }
        public static bool IsRemoteRun => GetRunType() == "RemoteExecutor";
        public static void StartScreenRecording()
        {
            Driver.StartRecordingScreen(
                AndroidStartScreenRecordingOptions.GetAndroidStartScreenRecordingOptions()
                .WithTimeLimit(TimeSpan.FromMinutes(6))
                .WithVideoSize("720x1280"));
            screenRecordingRunning = true;
        }

        public static void StopScreenRecording()
        {
            if (screenRecordingRunning)
            {
                string encodedVideo = Driver.StopRecordingScreen();
                DateTime now = DateTime.Now;
                screenRecordingRunning = false;
                byte[] decodedVideoBinary = Convert.FromBase64String(encodedVideo);
                string fileDirectory = $"{ProjectDirectory}{Path.DirectorySeparatorChar}record{now.Day}.{now.Month}.{now.Hour}h{now.Minute}m{now.Second}.mp4";
                using BinaryWriter videoWriter = new BinaryWriter(File.Open(fileDirectory, FileMode.Create));
                videoWriter.Write(decodedVideoBinary);
            }
        }
        public static void SetStatusOnBrowserStack()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
                _driver.ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" Oops! My test failed\"}}");
            else
                _driver.ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" Yaay! My test passed\"}}");
        }
        public static void SetOfflineModeInTheMiddleOfSession()
        {
            string sessionId = _driver.SessionId.ToString();
            HttpClient client = new();
            HttpRequestMessage request = new(HttpMethod.Put, $"https://api-cloud.browserstack.com/app-automate/sessions/{sessionId}/update_network.json");

            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes($"{DataContext.BSUser}:{DataContext.BSToken}")));

            request.Content = new StringContent("{\"networkProfile\":\"no-network\"}");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.Send(request);
        }
        public static void ResetNetworkConfiguration()
        {
            string sessionId = _driver.SessionId.ToString();
            HttpClient client = new();
            HttpRequestMessage request = new(HttpMethod.Put, $"https://api-cloud.browserstack.com/app-automate/sessions/{sessionId}/update_network.json");

            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes($"{DataContext.BSUser}:{DataContext.BSToken}")));

            request.Content = new StringContent("{\"networkProfile\":\"reset\"}");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.Send(request);
        }

        
    }
}
