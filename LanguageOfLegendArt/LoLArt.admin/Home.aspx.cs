using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.LogException;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Model;
using LanguageOfLegendArt.Core.LanguageOfLegentArt.Constkey;

namespace LoLArt.admin
{
    public partial class Home : Page
    {
        private List<LogException> _lstExceptions;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitForm();
            }
            Page.Title = @"Home - Management";
        }

        private void Bind()
        {
            _lstExceptions = new List<LogException>();
            LogExceptionController logController = new LogExceptionController();
            _lstExceptions = logController.GetAllExceptionNotFixed();
        }

        private void InitForm()
        {
            Bind();
            var strTableLog = new StringBuilder();
            int count = 0;
            if (_lstExceptions.Count == 0)
                lbNote.Text = @"<p style='font-style:italic;'>Hiện tại không có exception nào được ghi nhận.</p>";
            else
            {
                foreach (var exception in _lstExceptions)
                {
                    count++;
                    strTableLog.Append("<tr><th scope=\"row\">" + count + "</th>");
                    strTableLog.AppendFormat("<td>{0}</td>", exception.Id);
                    strTableLog.AppendFormat("<td>{0}</td>", exception.FileException);
                    strTableLog.AppendFormat("<td>{0}</td>", exception.MethodName);
                    strTableLog.AppendFormat("<td>{0}</td>", ExceptionSubstring(exception.Exception));
                    strTableLog.AppendFormat("<td>{0}</td>", exception.Time);
                    strTableLog.AppendFormat("<td>{0}</td>", StatusRender(exception.StatusException));
                    strTableLog.Append("</tr>");
                }
                lbTableLog.Text = strTableLog.ToString();
            }
        }

        private void GetRequest()
        {
            
        }

        private string StatusRender(int status)
        {
            string strStatus;
            switch (status)
            {
                case EnumKey.Running:
                    strStatus = "Chưa được fix";
                    break;
                case EnumKey.Waiting:
                    strStatus = "Đang được fix";
                    break;
                case EnumKey.Block:
                    strStatus = "Đã được fix";
                    break;
                default:
                    strStatus = "Không xác định";
                    break;
            }
            return strStatus;
        }

        private string ExceptionSubstring(string exception)
        {
            if (exception.Length > 30)
            {
                var newExeption = exception.Substring(0, 27) + "...";
                return newExeption;
            }
            return exception;
        }
    }
}