using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace LoLArt.admin
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //var settings = new FriendlyUrlSettings();
            //settings.AutoRedirectMode = RedirectMode.Off;
            routes.EnableFriendlyUrls();

        }
    }
}
