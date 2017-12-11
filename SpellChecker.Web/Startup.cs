using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpellChecker.Web.Startup))]
namespace SpellChecker.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
