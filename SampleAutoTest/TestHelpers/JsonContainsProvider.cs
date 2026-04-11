using System.Text.Json;

namespace SampleAutoTest.TestHelpers
{
    public class JsonContainsProvider
    {
        private const string _nameJsonFile = "appsettings.json";
        public void Provide(out JsonContains jsonContainsObject)
        {
            string objectJsonFile = File.ReadAllText(_nameJsonFile);
            jsonContainsObject = JsonSerializer.Deserialize<JsonContains>(objectJsonFile)!;
        }

        public static IEnumerable<string> GetBrowsers()
        {
            string objectJsonFile = File.ReadAllText(_nameJsonFile);
            var settings = JsonSerializer.Deserialize<JsonContains>(objectJsonFile);
            return settings?.Browsers ?? ["Chrome"];
        }
    }
}
