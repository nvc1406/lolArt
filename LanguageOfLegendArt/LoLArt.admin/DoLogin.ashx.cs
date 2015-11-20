using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.LogException;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.User;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Model;
using LanguageOfLegendArt.Core.LanguageOfLegentArt.Constkey;
using LanguageOfLegendArt.Core.LanguageOfLegentArt.Security;

namespace LoLArt.admin
{
    /// <summary>
    /// Summary description for DoLogin
    /// </summary>
    public class DoLogin : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.ContentEncoding = Encoding.UTF8;
            UserController user = new UserController();
            LogExceptionController logException = new LogExceptionController();
            ExtractQueryString extractQuery = new ExtractQueryString();
            try
            {
                string txtEmail = context.Request["txtEmail"].Trim();
                string txtPass = context.Request["txtPass"];
                string urlBuilder;
                if (Validate(txtEmail, txtPass))
                {
                    var doLogin = user.DoLogin(txtEmail, txtPass);
                    if (doLogin)
                    {
                        var objUser = user.GetByEmail(txtEmail);
                        if (objUser.UserStatus == EnumKey.AccountBlocked)
                        {
                            urlBuilder = string.Format("status={0}&mail={1}", EnumKey.AccountBlocked,txtEmail);
                            var url =  extractQuery.EncyptionUrl("login.aspx", urlBuilder);
                            context.Response.Redirect(url, false);
                        }
                        else // Phần này cần check thêm quyền.
                        {
                            string perUrl = string.Empty;
                            context.Session["USER_LOGIN"] = objUser.UserId;
                            if (objUser.Role == EnumKey.Administrator) // nếu là admin
                            {
                                perUrl = "Home.aspx";
                            }
                            else if (objUser.Role == EnumKey.Moderator) // là Mod - ng quản lý
                            {
                                perUrl = "Home.aspx";
                            }
                            //urlBuilder = string.Format("status={0}&mail={1}", EnumKey.AccountBlocked, txtEmail);
                            var url = extractQuery.EncyptionUrl(perUrl, string.Empty);
                            context.Response.Redirect(url, false);
                        }
                    }
                    else
                    {
                        urlBuilder = string.Format("status={0}&mail={1}", EnumKey.LoginFail,txtEmail);
                        var url = extractQuery.EncyptionUrl("login.aspx", urlBuilder);
                        context.Response.Redirect(url, false);
                    }
                }
                else
                {
                    urlBuilder = string.Format("status={0}&mail={1}", EnumKey.EmailFailure,txtEmail);
                    var url = extractQuery.EncyptionUrl("login.aspx", urlBuilder);
                    context.Response.Redirect(url, false);
                } 
            }
            catch (Exception e)
            {
                var mes = GetType() + e.Message;
                logException.InsertException(new LogException { Exception = mes, Time = DateTime.Now });
                context.Response.Redirect("login.aspx",false);
            }
            
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public bool Validate(string email, string pass)
        {
            var emailValid = new EmailAddressAttribute();
            bool result = true;
            if (string.IsNullOrEmpty(email))
            {
                result = false;
            }
            else
            {
                if (!emailValid.IsValid(email))
                {
                    result = false;
                }
            }
            if (string.IsNullOrEmpty(pass))
            {
                result = false;
            }
            return result;
        }
    }
}