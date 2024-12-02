using MobileAutomation.Tools;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace MobileAutomation.Steps
{
    class APISteps : BaseSteps
    {
        RestClient client;
        
        string SortingPayload => "{ \"Sort\": [{\"FieldName\": \"name\", \"Descending\": true}] }";
        string FilterPayload => "{ \"Filter\": [{ \"FieldName\": \"\", \"ValueLBound\": \"\", \"ValueUBound\": \"\" }]}";

        public APISteps()
        {
            client = new RestClient(DataContext.Host);
        }
        public string ResourceHost = DataContext.ResourceHost;

        public JObject GetAppCenterMobileLatestBuildData()
        {
            string appName = MobileDriver.IsTestReleaseProduction() ?
            (MobileDriver.GetTestingOS().Equals("Android") ? "TechApp-1" : "TechApp") :
            (MobileDriver.GetTestingOS().Equals("Android") ? "TechApp-Droid-Development" : "TechApp-iOS-Development");
            string ownerName = "FieldEdge";

            RestClient appCenterClient = new RestClient("https://api.appcenter.ms");
            appCenterClient.AddDefaultHeader("Content-Type", "application/json");
            appCenterClient.AddDefaultHeader("X-Api-Token", DataContext.AppCenterToken);

            RestRequest latestBuildDataRequest = new RestRequest($"/v0.1/apps/{ownerName}/{appName}/releases/latest", Method.Get);
            var latestReleaseResponse = appCenterClient.Execute(latestBuildDataRequest);
            return JObject.Parse(latestReleaseResponse.Content);
        }
        public string GetAppCenterMobileLatestBuildVersion()
        {
            JObject latestReleaseShortVersion = GetAppCenterMobileLatestBuildData();
            return latestReleaseShortVersion["short_version"].ToString();
        }
        public JObject UploadAppCenterMobileLatestBuildToBrowserStack()
        {
            JObject latestReleaseData = GetAppCenterMobileLatestBuildData();
            string downloadUrl = latestReleaseData["download_url"].ToString();

            RestClient browserStackClient = new RestClient("https://api-cloud.browserstack.com")
            {
                Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator(DataContext.BSUser, DataContext.BSToken)
            };

            RestRequest uploadBuildToBrowserStackRequest = new RestRequest("/app-automate/upload", Method.Post);
            uploadBuildToBrowserStackRequest.AddParameter("url", downloadUrl);
            var appUploadUrlResponse = browserStackClient.Execute(uploadBuildToBrowserStackRequest);
            return JObject.Parse(appUploadUrlResponse.Content);
        }
        public JObject UploadAppCenterMobileBuildToBrowserStack(string releaseVersion)
        {
            string appName = MobileDriver.IsTestReleaseProduction() ?
                (MobileDriver.GetTestingOS().Equals("Android") ? "TechApp-1" : "TechApp") :
                (MobileDriver.GetTestingOS().Equals("Android") ? "TechApp-Droid-Development" : "TechApp-iOS-Development");
            string ownerName = "FieldEdge";

            RestClient appCenterClient = new RestClient("https://api.appcenter.ms");
            appCenterClient.AddDefaultHeader("Content-Type", "application/json");
            appCenterClient.AddDefaultHeader("X-Api-Token", DataContext.AppCenterToken);

            RestRequest latestBuildDataRequest = new RestRequest($"/v0.1/apps/{ownerName}/{appName}/releases/{releaseVersion}", Method.Get);
            var latestReleaseResponse = appCenterClient.Execute(latestBuildDataRequest);
            JObject latestReleaseData = JObject.Parse(latestReleaseResponse.Content);
            string downloadUrl = latestReleaseData["download_url"].ToString();

            RestClient browserStackClient = new RestClient("https://api-cloud.browserstack.com")
            {
                Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator(DataContext.BSUser, DataContext.BSToken)
            };

            RestRequest uploadBuildToBrowserStackRequest = new RestRequest("/app-automate/upload", Method.Post);
            uploadBuildToBrowserStackRequest.AddParameter("url", downloadUrl);
            var appUploadUrlResponse = browserStackClient.Execute(uploadBuildToBrowserStackRequest);
            return JObject.Parse(appUploadUrlResponse.Content);
        }
        
    }
}
