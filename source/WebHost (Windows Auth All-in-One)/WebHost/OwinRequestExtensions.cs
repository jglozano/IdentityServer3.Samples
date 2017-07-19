using System.Net;
using Microsoft.Owin;

namespace WebHost
{
    public static class OwinRequestExtensions
    {
        public static IPAddress GetClientAddress(this IOwinRequest request)
        {
            var remote = request.RemoteIpAddress;

            IPAddress client;
            if (!IPAddress.TryParse(remote, out client))
            {
                client = null;
            }

            return client;
        }
    }
}