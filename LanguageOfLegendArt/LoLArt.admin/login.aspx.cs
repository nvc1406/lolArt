using System;
using System.Web.UI;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.ConvertObject;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.PageDefault;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.User;
using LanguageOfLegendArt.Core.LanguageOfLegentArt.Constkey;

namespace LoLArt.admin
{
   
    public partial class Login : Page
    {
        private int _logMess;
        private string _sEmail;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetRequest();
            if (!IsPostBack)
            {
                InitForm();
            }
        }

        private void GetRequest()
        {
            _logMess = ConvertObject.Object2Integer(Request.QueryString["status"]);
            _sEmail = Request.QueryString["mail"];
        }

        private void InitForm()
        {
            #region check Session
            if (Session["USER_LOGIN"] != null)
            {
                var userId = ConvertObject.Object2Integer(Session["USER_LOGIN"].ToString());
                if (userId > 0)
                {
                    UserController us = new UserController();
                    PageDefaultController pageDefault = new PageDefaultController();
                    var objUser = us.GetById(userId);
                    if (objUser != null)
                    {
                        var objPageDefault = pageDefault.GetPageDefaultByUserId(objUser.UserId);
                        Response.Redirect(objPageDefault != null ? objPageDefault.PageUrl : "Contact.aspx", false);
                    }
                }
            }
            #endregion
            #region In ra thông báo lỗi
            if (_logMess > 0)
            {
                if (_logMess == EnumKey.EmailFailure)
                {
                    txtMessage.InnerText = @"Email hoặc passwords của bạn vừa nhập không đúng !";
                }
                else if (_logMess == EnumKey.LoginFail)
                {
                    txtMessage.InnerText = @"Đăng nhập thất bại !";
                }
            }
            if (!string.IsNullOrEmpty(_sEmail))
            {
                txtEmail.Value = _sEmail;
            }
            #endregion
        }
    }
}