using Newtonsoft.Json;

namespace Helper;

public static class Helper
{
    public static string Dump<T>(this T data)
    {
        var json = JsonConvert.SerializeObject(data, Formatting.Indented);
        Console.WriteLine(json);
        return json;
    }
    
    
}