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
    public string Username { get; set; }
    public string Password { get; set; }
    public string InvalidUser { get; set; }
    public string InvalidPass { get; set; }
    public string UKUsername { get; set; }
    public string UKPassword { get; set; }
    public string NewUser { get; set; }
    public string NewPass { get; set; }

}

public class UserContent
{
    public string EducatorName { get; set; }
    public string PostTitle { get; set; }
    public string PostDesc { get; set; }

}

public class TestData
{
    public List<UserData> UserData { get; set; }
    public List<UserContent> UserContent { get; set; }
}
