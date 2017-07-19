using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace WebHost.Services
{
    public interface IConfigurationService
    {
        string GetAppSetting(string name);
        ConnectionStringSettings GetConnectionString(string connectionName);
    }
}
