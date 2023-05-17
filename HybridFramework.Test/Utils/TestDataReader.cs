using Microsoft.Extensions.Configuration;

namespace HybridFramework.Test.Utils;

public class TestDataReader
{
    private IConfiguration Configuration { get; }

    public TestDataReader()
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        Configuration = new ConfigurationBuilder()
            .AddJsonFile("../../../TestDatas/appsettings.json")
            .AddJsonFile($"../../../TestDatas/appsettings.{environmentName}.json", optional: true)
            .Build();
    }

    public string? GetTestData(string key)
    {
        return Configuration[key];
    }
}
