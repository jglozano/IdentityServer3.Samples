using System;
using System.Linq;
using NetTools;

namespace WebHost.Services
{
    public static class ConfigurationExtensions
    {
        public static IPAddressRange[] GetClientRanges(this IConfigurationService configService)
        {
            var rangeValues = configService.GetAppSetting("client.IPRanges");
            if (string.IsNullOrEmpty(rangeValues))
            {
                return new IPAddressRange[0];
            }

            var separator = ';';
            var parts = rangeValues.Split(new[] {separator}, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0)
            {
                return new IPAddressRange[0];
            }

            var ranges = parts.Select(IPAddressRange.Parse).ToArray();
            return ranges;
        }
    }
}