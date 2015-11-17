using System;
using System.Text.RegularExpressions;

namespace LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.ConvertObject
{
    public class ConvertObject
    {
        public static int Object2Integer(object value)
        {
            Int32 result = 0;
            if (value != null)
                Int32.TryParse(value.ToString(), out result);
            if (result == 0 && value is double)
                result = Convert.ToInt32(Math.Round((double)value, 0));
            return result;
        }
        public static int Object2Integer(object value, int defaultVal)
        {
            Int32 result;
            if (value != null)
            {
                Int32.TryParse(value.ToString(), out result);
                if (result == 0 && value is double)
                    result = Convert.ToInt32(Math.Round((double)value, 0));
            }
            else
            {
                result = defaultVal;
            }
            return result;
        }

        /// <summary>
        /// Chuyển đổi 1 giá trị sang kiểu Long
        /// </summary>
        /// <param name="value">Giá trị cần chuyển đổi</param>
        /// <returns>Số kiểu Long, nếu lỗi return 0</returns>
        public static long Object2Long(object value)
        {
            long result = 0;
            if (value != null)
                long.TryParse(value.ToString(), out result);
            if (result == 0 && value is double)
                result = Convert.ToInt64(Math.Round((double)value, 0));
            return result;
        }
        /// <summary>
        /// Chuyển đổi 1 giá trị sang kiểu Double
        /// </summary>
        /// <param name="value">Giá trị cần chuyển đổi</param>
        /// <returns>Số kiểu Double, nếu lỗi return 0</returns>
        public static double Object2Double(object value)
        {
            Double result = 0;
            if (value != null)
                Double.TryParse(value.ToString(), out result);
            return Double.IsInfinity(result) ? 0 : result;
        }
        /// <summary>
        /// Chuyển đổi 1 giá trị sang kiểu float
        /// </summary>
        /// <param name="value">Giá trị cần chuyển đổi</param>
        /// <returns>Số kiểu float, nếu lỗi return float.NaN</returns>
        public static float Object2Float(object value)
        {
            float result = 0;
            if (value != null)
                float.TryParse(value.ToString(), out result);
            return float.IsInfinity(result) ? 0 : result;
        }
        public static bool Object2Bool(object value)
        {
            var result = false;
            if (value != null)
                bool.TryParse(value.ToString(), out result);
            return result;
        }
        public static bool Object2Boolean(object value)
        {
            var result = false;
            if (value != null)
                bool.TryParse(value.ToString(), out result);
            return result;
        }
        public static bool IsValidEmailAddress(string email)
        {
            const string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            var re = new Regex(strRegex);
            return re.IsMatch(email);
        }
    }
}
