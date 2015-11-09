using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lolArt.web.admin.Startup))]
namespace lolArt.web.admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
