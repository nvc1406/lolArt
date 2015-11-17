using System.Collections.Specialized;
using System.Text;

namespace LoLArt.admin.App_Security
{
    public static class CryptoQueryStringHandler
    {
        public static string EncryptQueryStrings(string[] unencryptedStrings, string key)
        {
            StringBuilder strings = new StringBuilder();

            foreach (string unencryptedString in unencryptedStrings)
            {
                if (strings.Length > 0) strings.Append("&");
                strings.Append(unencryptedString);
            }

            return string.Concat("query=", Encryption.Encrypt(strings.ToString(), key));
        }
        public static string EncryptQueryStrings(NameValueCollection unencryptedStrings, string key)
        {
            StringBuilder strings = new StringBuilder();

            foreach (string stringKey in unencryptedStrings.Keys)
            {
                if (strings.Length > 0) strings.Append("&");
                strings.Append(string.Format("{0}={1}", stringKey, unencryptedStrings[stringKey]));
            }

            return string.Concat("query=", Encryption.Encrypt(strings.ToString(), key));
        }
        /// <summary>
        /// Decrypt query string.
        /// </summary>
        /// <param name="encryptedStrings">Encrypted query string.</param>
        /// <param name="key">Key, being used to decrypt.</param>
        /// <remarks>The query string object replaces '+' character with an empty character.</remarks>
        /// <returns></returns>
        public static string DecryptQueryStrings(string encryptedStrings, string key)
        {
            return Encryption.Decrypt(encryptedStrings.Replace(" ", "+"), key);
        }
    }

}