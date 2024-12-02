using AventStack.ExtentReports;
using log4net;

public static class LoggerHelper
{
    public static void Log(ILog log, ExtentTest test, string message, Status status = Status.Info)
    {
        log.Info(message);
        test.Log(status, message);
    }

    public static void LogSuccess(ILog log, ExtentTest test, string message, Status status = Status.Pass)
    {
        log.Info(message);
        test.Log(status, message);
    }

    public static void LogError(ILog log, ExtentTest test, string message, Status status = Status.Error)
    {
        log.Info(message);
        test.Log(status, message);
    }
}
