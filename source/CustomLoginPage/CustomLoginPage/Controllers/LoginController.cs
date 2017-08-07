using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using IdentityServer3.Core.Extensions;
using CustomLoginPage.Models;

namespace CustomLoginPage.Controllers
{
    public class LoginController : Controller
    {
        [Route("core/custom/login/{id}")]
        public ActionResult Index(string id)
        {
            return View(new LoginViewModel {AuthId = id});
        }

        [Route("core/custom/login/{id}")]
        [HttpPost]
        public ActionResult Index(string id, LoginInputModel inputModel)
        {
            var env = Request.GetOwinContext().Environment;

            var authLogin = new IdentityServer3.Core.Models.AuthenticatedLogin
            {
                Subject = inputModel.Username,
                Name = inputModel.Username,
                AuthenticationMethod = "forms",
                Claims = new List<Claim>
                {
                    new Claim("lpid", "1234"),
                    new Claim("userType", Enum.GetName(typeof(UserType), inputModel.UserType))
                }
            };

            env.IssueLoginCookie(authLogin);

            var msg = env.GetSignInMessage(id);
            var returnUrl = msg.ReturnUrl;

            env.RemovePartialLoginCookie();

            // return back to processing the OAuth/OpenID Connect flow
            return Redirect(returnUrl);
        }
    }
}