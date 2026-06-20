using System.Text.Json;

namespace SampleAutoTest.TestHelpers
{
    public class JsonContainsProvider
    {
        private const string _nameJsonFile = "appsettings.json";

        public JsonContains Provide()
        {
            string objectJsonFile = ReadJsonFile();
            return JsonSerializer.Deserialize<JsonContains>(objectJsonFile)
                ?? throw new InvalidOperationException(
                    $"Не удалось десериализовать файл {_nameJsonFile}. Проверьте формат JSON.");
        }

        private string ReadJsonFile()
        {
            if (!File.Exists(_nameJsonFile))
                throw new FileNotFoundException(
                    $"Файл конфигурации не найден: {_nameJsonFile}. " +
                    $"Текущая директория: {Directory.GetCurrentDirectory()}");

            return File.ReadAllText(_nameJsonFile);
        }
    }
}
