using IdentityServer3.Core.Services.Default;
using IdentityServer3.Core.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer3.Core.Models;
using System.Security.Claims;
using IdentityServer3.Core.Services;
using Microsoft.Owin;

namespace CustomLoginPage
{
    public class CustomLoginPageUserService : UserServiceBase
    {
        readonly OwinContext currentContext;

        public CustomLoginPageUserService(OwinEnvironmentService environmentService)
        {
            currentContext = new OwinContext(environmentService.Environment);
        }

        public override Task PreAuthenticateAsync(PreAuthenticationContext context)
        {
            var id = currentContext.Request.Query.Get("signin");
            var authUrl = $"~/custom/login/{id}";

            context.AuthenticateResult = new AuthenticateResult(authUrl, (IEnumerable<Claim>)null);
            return Task.FromResult(0);
        }

        public override Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subjectId = context.Subject.GetSubjectId();
            var claims = context.Subject.Claims.ToArray();

            // Pass the same claims through
            context.IssuedClaims = claims;

            return base.GetProfileDataAsync(context);
        }
    }
}
