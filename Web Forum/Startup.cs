using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_Forum.Startup))]
namespace Web_Forum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "UserCookie",
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}