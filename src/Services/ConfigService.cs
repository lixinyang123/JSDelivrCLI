using JSDelivrCLI.Models;
using System.Text.Json;

namespace JSDelivrCLI.Services
{
    public class ConfigService
    {
        private readonly string configPath = "jsdelivr.json";

        private readonly Config config;

        public ConfigService()
        {
            if (File.Exists(configPath))
            {
                config = JsonSerializer.Deserialize<Config>(File.ReadAllText(configPath));
            }
            else
            {
                config = new Config();
            }
        }

        public void AddLibrary(ConfigItem item)
        {
            config.Libraries.Add(item);
        }

        public void RemoveLibrary(string libraryName)
        {
            config.Libraries.Remove(config.Libraries.SingleOrDefault(i => i.Name == libraryName));
        }

        public ConfigItem GetLibrary(string libraryName)
        {
            return config.Libraries.SingleOrDefault(i => i.Name.Contains(libraryName));
        }

        public void Save()
        {
            File.WriteAllText(configPath,
                JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true })
            );
        }

        public List<ConfigItem> GetLibraries()
        {
            return config.Libraries;
        }
    }
}