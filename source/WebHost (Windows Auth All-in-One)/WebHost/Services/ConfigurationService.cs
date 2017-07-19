using System.Configuration;

namespace WebHost.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public string GetAppSetting(string name)
        {
            var appSettings = ConfigurationManager.AppSettings;
            return appSettings[name];
        }

        public ConnectionStringSettings GetConnectionString(string connectionName)
        {
            var connStrings = ConfigurationManager.ConnectionStrings;
            return connStrings[connectionName];
        }
    }
}