using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
public class JsonUtil
{
    public static TestData GetTestData()
    {
        string json = File.ReadAllText("TestData/TestData.json");
        return JsonConvert.DeserializeObject<TestData>(json);
    }
}

public class UserData
{
    public string ServiceUser { get; set; }
    public string ServicePass { get; set; }
    public string EduUser { get; set; }
    public string EduPin { get; set; }
    public string EduEmail { get; set; }
    public string EduPass { get; set; }

}

public class UserContent
{
    public string ChildName { get; set; }
    public string Name { get; set; }
    public string Expected { get; set; }
    public string Email { get; set; }
    public string Location { get; set; }
    public string IncidentActivityDrtails { get; set; }
    public string IncidentCause { get; set; }
    public string IncidentCircumtance { get; set; }
    public string IncidentTaken { get; set; }
    public string IncidentFutureSteps { get; set; }
    public string Fullname { get; set; }
    public string Role { get; set; }
}

public class TestData
{
    public List<UserData> UserData { get; set; }
    public List<UserContent> UserContent { get; set; }
}
