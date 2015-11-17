using System;
using System.Web.Configuration;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.LogException;
using LanguageOfLegendArt.Core.LanguageOfLegendArt.Model;

namespace LanguageOfLegendArt.Core.LanguageOfLegentArt.Security
{
    public class ExtractQueryString
    {
        private readonly LogExceptionController _logException = new LogExceptionController();
        /// <summary>
        /// Hàm generate ra link mã hóa
        /// </summary>
        /// <param name="pageName">Tên control ví dụ :"Default.aspx"</param>
        /// <param name="queryString">chuỗi param phía sau ví dụ : "a=1 & b=2</param>
        /// <returns>Nếu = emty => có lỗi xảy ra và ngược lại</returns>
        public string EncyptionUrl(string pageName,string queryString)
        {
            try
            {
                var key = WebConfigurationManager.AppSettings["CryptoKey"];
                var url = Encryption.Encrypt(queryString, key);
                var urlBuilder = string.Concat("query=", url);
                urlBuilder = string.Format("{0}?{1}", pageName, urlBuilder);
                return urlBuilder;
            }
            catch (Exception e)
            {
                var ex = GetType() + e.Message;
                _logException.InsertException(new LogException{Exception = ex,Time = DateTime.Now});
                return string.Empty;
            }
        }
    }
}
