using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.ConvertObject;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.FeedBackController;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.LogException;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.Post;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Model;
using LanguageOfLegendArt.Core.LanguageOfLegentArt.Constkey;

namespace LoLArt.admin
{
    public partial class Home : Page
    {
        private List<LogException> _lstExceptions;
        private List<FeedBack> _lstFeedBacks;
        private List<Post> _listPostsWaitting;
        private string _emailSearchFeedback;
        private int _statusFeedBack;
        private string _sTimeFeed;
        private string _eTimeFeed;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetRequest();
            if (!IsPostBack)
            {
                InitForm();
            }
            Page.Title = @"Home - Management";
        }

        private void Bind()
        {
            _lstExceptions = new List<LogException>();
            _lstFeedBacks = new List<FeedBack>();
            _listPostsWaitting = new List<Post>();
            LogExceptionController logController = new LogExceptionController();
            FeedBackController feedController = new FeedBackController();
            PostController postController = new PostController();
           
            var sDate = string.IsNullOrEmpty(_sTimeFeed) ? DateTime.MinValue : DateTime.Parse(_sTimeFeed);
            var eDate = string.IsNullOrEmpty(_eTimeFeed) ? DateTime.MinValue : DateTime.Parse(_eTimeFeed);
            _lstFeedBacks = feedController.GetAllByParam(_emailSearchFeedback, _statusFeedBack, sDate, eDate);
            _listPostsWaitting = postController.GetAllPostWaitting();
            _lstExceptions = logController.GetAllExceptionNotFixed();
        }

        private void InitForm()
        {
            Bind();
            #region Bảng exception
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
            #endregion
            #region FeedBack
            var strFeed = new StringBuilder();
            int numOfFeed = 0;
            if (_lstFeedBacks.Count > 0)
            {
                foreach (var fe in _lstFeedBacks)
                {
                    var urlShow = string.Empty;
                    var feedContent = ExceptionSubstring(fe.FContent);
                    switch (numOfFeed)
                    {
                        case 0 :
                            strFeed.AppendFormat(
                                "<a href=\"{4}\" class='feed'><div class=\"inbox-item\"><div class=\"inbox-item-img\"><img src=\"{0}\" class=\"img-circle\" alt=\"\"></div><p class=\"inbox-item-author\">{1}</p><p class=\"inbox-item-text\">{2}</p><p class=\"inbox-item-date\">{3}</p></div></a>", "Content/assets/images/avatar_f.png", fe.Email, feedContent, fe.Time.ToString("dd/MM/yyyy h:mm"), urlShow);
                            break;
                        case 1:
                            strFeed.AppendFormat(
                                "<a href=\"{4}\" class='feed'><div class=\"inbox-item\"><div class=\"inbox-item-img\"><img src=\"{0}\" class=\"img-circle\" alt=\"\"></div><p class=\"inbox-item-author\">{1}</p> <p class=\"inbox-item-text\">{2}</p><p class=\"inbox-item-date\">{3}</p></div></a>", "Content/assets/images/avatar_e.png", fe.Email, feedContent, fe.Time.ToString("dd/MM/yyyy h:mm"), urlShow);
                            break;
                        case 2:
                            strFeed.AppendFormat(
                                "<a href=\"{4}\" class='feed'><div class=\"inbox-item\"><div class=\"inbox-item-img\"><img src=\"{0}\" class=\"img-circle\" alt=\"\"></div><p class=\"inbox-item-author\">{1}</p> <p class=\"inbox-item-text\">{2}</p><p class=\"inbox-item-date\">{3}</p></div></a>", "Content/assets/images/avatar_e1.png", fe.Email, feedContent, fe.Time.ToString("dd/MM/yyyy h:mm"), urlShow);
                            break;
                        case 3:
                            strFeed.AppendFormat(
                                "<a href=\"{4}\" class='feed'><div class=\"inbox-item\"><div class=\"inbox-item-img\"><img src=\"{0}\" class=\"img-circle\" alt=\"\"></div><p class=\"inbox-item-author\">{1}</p> <p class=\"inbox-item-text\">{2}</p><p class=\"inbox-item-date\">{3}</p></div></a>", "Content/assets/images/avatar_d.png", fe.Email, feedContent, fe.Time.ToString("dd/MM/yyyy h:mm"), urlShow);
                            break;
                        case 4:
                            strFeed.AppendFormat(
                                "<a href=\"{4}\" class='feed'><div class=\"inbox-item\"><div class=\"inbox-item-img\"><img src=\"{0}\" class=\"img-circle\" alt=\"\"></div><p class=\"inbox-item-author\">{1}</p> <p class=\"inbox-item-text\">{2}</p><p class=\"inbox-item-date\">{3}</p></div></a>", "Content/assets/images/avatar_b.png", fe.Email, feedContent, fe.Time.ToString("dd/MM/yyyy h:mm"), urlShow);
                            break;
                        case 5:
                            strFeed.AppendFormat(
                                "<a href=\"{4}\" class='feed'><div class=\"inbox-item\"><div class=\"inbox-item-img\"><img src=\"{0}\" class=\"img-circle\" alt=\"\"></div><p class=\"inbox-item-author\">{1}</p> <p class=\"inbox-item-text\">{2}</p><p class=\"inbox-item-date\">{3}</p></div></a>", "Content/assets/images/avatar_a.png", fe.Email, feedContent, fe.Time.ToString("dd/MM/yyyy h:mm"), urlShow);
                            break;
                        case 6:
                            strFeed.AppendFormat(
                                "<a href=\"{4}\" class='feed'><div class=\"inbox-item\"><div class=\"inbox-item-img\"><img src=\"{0}\" class=\"img-circle\" alt=\"\"></div><p class=\"inbox-item-author\">{1}</p> <p class=\"inbox-item-text\">{2}</p><p class=\"inbox-item-date\">{3}</p></div></a>", "Content/assets/images/avatar_c.png", fe.Email, feedContent, fe.Time.ToString("dd/MM/yyyy h:mm"), urlShow);
                            break;
                        case 7:
                        strFeed.AppendFormat(
                            "<a href=\"{4}\" class='feed'><div class=\"inbox-item\"><div class=\"inbox-item-img\"><img src=\"{0}\" class=\"img-circle\" alt=\"\"></div><p class=\"inbox-item-author\">{1}</p> <p class=\"inbox-item-text\">{2}</p><p class=\"inbox-item-date\">{3}</p></div></a>", "Content/assets/images/avatar_k.png", fe.Email, feedContent, fe.Time.ToString("dd/MM/yyyy h:mm"), urlShow);
                        break;
                    }
                    count++;
                    if (count == 7)
                      count = 0;
                }
                lbFeedBack.Text = strFeed.ToString();
            }

            #endregion
            #region Post chưa duyệt
            var strPost = new StringBuilder();
            if (_listPostsWaitting.Count > 0)
            {
                foreach (var post in _listPostsWaitting)
                {
                    strPost.Append("<tr>");
                    strPost.AppendFormat("<th scope=\"row\">{0}</th>", post.PostId);
                    strPost.AppendFormat("<td>{0}</td>", post.Title);
                    strPost.Append("<td><span class=\"label label-info\">Chưa duyệt</span></td>");
                    strPost.AppendFormat("<td>{0}</td>", ""); //link tới bảng cateogry => .ra category name
                    strPost.AppendFormat("<td>{0}</td>", post.PostBy > 0 ? post.User.Email : "Nothing...");
                    strPost.AppendFormat("<td>{0}</td>", post.PostTime);
                    strPost.Append("</tr>");
                }
                lbPostWaiting.Text = strPost.ToString();
            }
            else
                lbNotePostWating.Text = @"<p style='font-style:italic;'>Hiện tại không có bài viết nào chờ duyệt.</p>";
            #endregion
        }

        private void GetRequest()
        {
            if (Request.QueryString["emailFeed"] != null)
                _emailSearchFeedback = Request.QueryString["emailFeed"];

            _statusFeedBack = ConvertObject.Object2Integer(Request.QueryString["statusFeedBack"]);
            _sTimeFeed = Request.QueryString["sTimeFeed"] ?? string.Empty;
            _eTimeFeed = Request.QueryString["eTimeFeed"] ?? string.Empty;
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