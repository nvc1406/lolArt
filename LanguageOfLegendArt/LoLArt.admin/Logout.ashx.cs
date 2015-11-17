using System;
using System.Text;
using System.Web;

namespace LoLArt.admin
{
    /// <summary>
    /// Summary description for Logout
    /// </summary>
    public class Logout : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.ContentEncoding = Encoding.UTF8;
            try
            {
                if (context.Session["USER_LOGIN"] != null)
                {
                    context.Session["USER_LOGIN"] = "0";
                }
                context.Response.Redirect("login.aspx",false);
            }
            catch (Exception ex)
            {
                context.Session["USER_LOGIN"] = "0";
                context.Response.Redirect("login.aspx", false);
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}