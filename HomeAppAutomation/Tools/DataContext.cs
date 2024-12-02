using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HomeAppAutomations.Tools
{
    static class DataContext
    {
        private static string testedBuildsData;
        private static string configRunnerData;
        private static string slackWebHook;
        private static readonly string testedAppBuildsDataFile = "AppBuildForTesting.json";
        private static readonly string configRunnerDataFile = "configRunner.json";
        private static readonly string webHooksUrlFile = "web_hooks_url.json";

        private static JObject TestedBuildsNames
        {
            get
            {
                if (string.IsNullOrEmpty(testedBuildsData))
                {
                    string jsonPath = Path.Combine(MobileDriver.ProjectDirectory, testedAppBuildsDataFile);
                    testedBuildsData = File.ReadAllText(jsonPath);
                }
                return JObject.Parse(testedBuildsData);
            }
        }

        private static JObject ConfigRunnerProperties
        {
            get
            {
                if (string.IsNullOrEmpty(configRunnerData))
                {
                    string jsonPath = Path.Combine(MobileDriver.ProjectDirectory, configRunnerDataFile);
                    configRunnerData = File.ReadAllText(jsonPath);
                }
                return JObject.Parse(configRunnerData);
            }
        }

        private static JObject GetSlackWebHook
        {
            get
            {
                if (string.IsNullOrEmpty(slackWebHook))
                {
                    slackWebHook = File.ReadAllText(Path.Combine(MobileDriver.ProjectDirectory, webHooksUrlFile));
                }
                return JObject.Parse(slackWebHook);
            }
        }

        public static string SlackWebHook => GetSlackWebHook["slack"].ToString();
        public static string AndroidBuildFile => TestedBuildsNames[DeviceType][MobileDriver.AndroidOSName].ToString();

        public static string iOSBuildFile => TestedBuildsNames[DeviceType][MobileDriver.IOSName].ToString();

        public static string AlternateTestingOS => TestedBuildsNames["testingOS"].ToString();

        public static bool isMOQBuild => TestedBuildsNames["isMOQBuild"].ToObject<bool>();

        public static bool isProductionBuild => TestedBuildsNames["isProductionBuild"].ToObject<bool>();


        public static string CanadianDBName => "QBD";

        public static string EAStagingDBName => "EA_staging";

        public static string ProductionDBName => "Prod";

        public static string TestRunEnvironment
        {
            get
            {
                if (IsEnvironmentSet)
                {
                    string feTestEnvironment = Environment.GetEnvironmentVariable("FETestEnvironment");
                    switch (feTestEnvironment)
                    {
                        case "Prod":
                            return ProductionDBName;
                        case "EA_staging":
                            return EAStagingDBName;
                        case "QBD":
                            return CanadianDBName;
                        default:
                            return EAStagingDBName;
                    }
                }
                else
                {
                    return EAStagingDBName; // To run locally change the value here to the desired db environment
                }
            }
        }

        public static string RunType => ConfigRunnerProperties["RunType"].ToString();
        public static string BSToken => ConfigRunnerProperties["BSToken"].ToString();
        public static string BSUser => ConfigRunnerProperties["BSUser"].ToString();
        public static string iOSOSVersion => ConfigRunnerProperties["iOSOSVersion"].ToString();
        public static string iOSDeviceName => ConfigRunnerProperties["iOSDeviceName"].ToString();
        public static string AndroidOSVersion => ConfigRunnerProperties["AndroidOSVersion"].ToString();
        public static string AndroidDeviceName => ConfigRunnerProperties["AndroidDeviceName"].ToString();
        public static string AppCenterToken => ConfigRunnerProperties["AppCenterToken"].ToString();
        public static string BSAndroidAppPath => ConfigRunnerProperties["BSAppPath"]["Android"].ToString();
        public static string BSiOSAppPath => ConfigRunnerProperties["BSAppPath"]["iOS"].ToString();
        public static string ReleaseVersion => ConfigRunnerProperties["ReleaseVersion"].ToString();
        public static bool LatestBuildRequired => ConfigRunnerProperties["LatestBuildRequired"].ToString().Equals("true");

        public static bool IsRegressionRun => ConfigRunnerProperties["IsRegressionRun"].ToString().Equals("true");

    
        public static string DeviceType => IsDeviceTypeSet ? Environment.GetEnvironmentVariable("MobileDeviceType") : TestedBuildsNames["deviceType"].ToString();


        public static bool IsDeviceTypeSet => !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("MobileDeviceType"));

        private static bool IsEnvironmentSet => !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("FETestEnvironment"));

        public static string ProjectName => ConfigRunnerProperties["ProjectName"].ToString();
        public static string BuildNameAndroid => ConfigRunnerProperties["BuildNameAndroid"].ToString();
        public static string BuildNameIos => ConfigRunnerProperties["BuildNameIos"].ToString();

        public static string AndroidAppPackage => TestedBuildsNames["AndroidAppPackage"].ToString();
        public static string AndroidAppActivity => TestedBuildsNames["AndroidAppActivity"].ToString();


        private static JObject environmentPreSetupData;

       
        public static JObject EnvironmentPreSetupData
        {
            get
            {
                if (environmentPreSetupData == null)
                {
                    LoadUsedDatabaseItems();
                }
                return environmentPreSetupData;
            }
        }

        public static string Host => EnvironmentPreSetupData["api_server_host"].ToString();
        public static string ResourceHost => EnvironmentPreSetupData["api_resource_server"].ToString();
              
        public static JObject LoadUsedDatabaseItems()
        {
            string projectPath = MobileDriver.ProjectDirectory;
            string dataFileName = $"{TestRunEnvironment}_data_entities.json";
            string jsonPath = Path.Combine(projectPath, dataFileName);
            string jsonString = File.ReadAllText(jsonPath);
            environmentPreSetupData = JObject.Parse(jsonString);
            return environmentPreSetupData;
        }

        
    }
}
