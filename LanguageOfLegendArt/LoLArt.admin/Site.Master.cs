using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.ConvertObject;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.User;

namespace LoLArt.admin
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        public bool IsLogged;
        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = @"LOL ART Management";
            if (Session["USER_LOGIN"] == null || ConvertObject.Object2Integer(Session["USER_LOGIN"].ToString()) == 0)
            {
                Response.Redirect("login.aspx", false);
            }
            if (!IsPostBack)
            {
                CheckLoged();
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
        }

        private void CheckLoged()
        {
            if (Session["USER_LOGIN"] != null)
            {
                UserController us = new UserController();
               
                var userId = ConvertObject.Object2Integer(Session["USER_LOGIN"]);
                if (userId > 0)
                {
                    var objUser = us.GetById(userId);
                    if (objUser != null)
                    {
                        IsLogged = true;
                        InitProfile(objUser.Avatar, objUser.NickName);

                    }
                }
                else
                    Response.Redirect("login.aspx", false);  
            }
        }

        private void InitProfile(string imgUrl,string name)
        {
            if (!string.IsNullOrEmpty(imgUrl) && !string.IsNullOrEmpty(name))
            {
                lbProfile.Text = string.Format(
                               "<img src='{0}' width=\"52\" alt=\"{2}\"/><span>{1}</span>", imgUrl, name, name);

                lbAvatarLeft.Text = string.Format("<img src=\"{0}\" class=\"img-circle img-responsive\" alt=\"\">", imgUrl);
                lbNameLeft.Text = string.Format("<span>{0}<br><small>{1}</small></span>", name, "LOL ART Management");
                lblName.Text = string.Format("<span class=\"user-name\">{0}<i class=\"fa fa-angle-down\"></i></span>",name);
                lblAvatar.Text =
                    string.Format("<img class=\"img-circle avatar\" src=\"{0}\" width=\"40\" height=\"40\" alt=\"\">",imgUrl);
            }
        }
    }

}