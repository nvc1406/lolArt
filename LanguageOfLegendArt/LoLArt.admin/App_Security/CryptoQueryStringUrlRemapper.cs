﻿using System;
using System.Web;
using System.Web.Configuration;

namespace LoLArt.admin.App_Security
{
    public class CryptoQueryStringUrlRemapper : IHttpModule
    {
        #region IHttpModule Members

        /// <summary>
        /// Initialize the http module.
        /// </summary>
        /// <param name="application">Application, that called this module.</param>
        public void Init(HttpApplication application)
        {
            // Attach the acquire request state event to catch the encrypted query string
            application.AcquireRequestState += application_AcquireRequestState;
        }

        public void Dispose()
        { }

        #endregion
        public void application_AcquireRequestState(object sender, EventArgs e)
        {
            // Get http context from the caller.
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;

            // Check for encrypted query string
            string encryptedQueryString = context.Request.QueryString["query"];
            if (!string.IsNullOrEmpty(encryptedQueryString))
            {
                // Decrypt query strings
                string cryptoKey = WebConfigurationManager.AppSettings["CryptoKey"];
                string decryptedQueryString = CryptoQueryStringHandler.DecryptQueryStrings(encryptedQueryString, cryptoKey);
                context.Server.Transfer(context.Request.AppRelativeCurrentExecutionFilePath + "?" + decryptedQueryString);
            }
        }
    }
}