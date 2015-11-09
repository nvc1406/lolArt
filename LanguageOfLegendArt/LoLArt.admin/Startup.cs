using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoLArt.admin.Startup))]
namespace LoLArt.admin
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
