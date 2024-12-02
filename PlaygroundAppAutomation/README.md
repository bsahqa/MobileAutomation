# Introduction 
This standard mobile automation project is created to kickstart writing test cases script with minimal changes in configuration.

# Getting Started
For local test runs on Android this library requires Appium Server and preset mobile device - real or emulated.

General setup steps for iOS are [here](https://appium.io/docs/en/drivers/ios-xcuitest-real-devices/).
IOS application testing requires UI Automation turned on (in Developer tools) on iPhone and mac with AppCenter distribution certificate installed 

# Build and Test
For running tests locally application build must be placed in project directory. 
Build's file name must be placed into `AppBuildForTesting.json` to related key.
Before test run appium server must run on `127.0.0.1:4723` and device must be connected.

# configRunner.json
RunType: "LocalExecutor" or "RemoteExecutor" - two options for run tests: local or remote.
BSUser: Enter your BSUser here.
BSToken: Enter your BSToken here.
BSAppPath: Path to app that was uploaded to BS
LatestBuildRequired: If true the latest build will be upload to BS from AppCenter
IsRegressionRun: If true the test result will be sent to Slack

# AppBuildForTesting.json
testingOS: "Android" or "iOS" to run test either on android or iOS
deviceType: "Phone" or "Tablet" to run test either on phone or tablet

# Contribute
TODO: Explain how other users and developers can contribute to make your code better. 

If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)