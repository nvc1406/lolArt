using System;
using System.Web.UI;

namespace LoLArt.admin
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = @"Home - Management";
        }
    }
}