using System;
using System.Collections.Specialized;
using System.Web.Configuration;
using System.Web.UI;
using LanguageOfLegendArt.Core.LanguageOfLegentArt.Security;
namespace LoLArt.admin
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetRequestParam();
            if (!IsPostBack)
            {

            }
        }

        private void GetRequestParam()
        {

        }
    }
}