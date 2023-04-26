using Newtonsoft.Json;

#nullable disable
namespace HybridFramework.Test;

public class ConfigurationHelper
{
    public static T ReadJsonConfiguration<T>(string filePath)
    {
        using (StreamReader file = File.OpenText(filePath))
        {
            JsonSerializer serializer = new JsonSerializer();
            return (T)serializer.Deserialize(file, typeof(T));
        }
    }
}
