using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.CoinKit
{
    public static class StringHelper
    {
        /// <summary>
        /// 生成一个指定前缀的随机字符串
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="length"></param>
        /// <param name="suffixLength"></param>
        /// <returns></returns>
        public static string RandString(string prefix, int length = 8, int suffixLength = 0, bool autoPrefix = false)
        {
            var random = new Random();
            var alpha = "ABCDEFGHRJKLMNOPQRSTUVWXYZ0123456789";

            if (prefix.IsNullOrEmpty() && autoPrefix)
            {
                for(int i=0; i < 3; i++)
                {
                    prefix += alpha.Substring(random.Next(0, 25), 1);
                }
            }

            var result = new StringBuilder(prefix);

            var numberLength = length - prefix.Length;
            if (suffixLength > 0)
                numberLength -= suffixLength;

            if (numberLength <= 0)
                throw new Exception("InvalidLength");

            for (int i = 0; i < numberLength; i++)
            {
                int feed = random.Next(0, 9);

                result.Append(feed);
            }

            if (suffixLength > 0)
            {
                for (int i = 0; i < suffixLength; i++)
                {
                    result.Append(alpha.Substring(random.Next(0, 35), 1));
                }
            }

            return result.ToString();
        }
    }
}
