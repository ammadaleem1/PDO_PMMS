using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;

namespace chartDemo.Helpers
{
    public static class StringHelper
    {
        public static string[] GetStringInBetween(string strBegin,string strEnd, string strSource,bool includeBegin, bool includeEnd)
        {
            string[] result = { "", "" };

            int iIndexOfBegin = strSource.IndexOf(strBegin);

            if (iIndexOfBegin != -1)
            {
                // include the Begin string if desired
                
                if (includeBegin)
                    iIndexOfBegin -= strBegin.Length;

                strSource = strSource.Substring(iIndexOfBegin + strBegin.Length);

                int iEnd = strSource.IndexOf(strEnd);
                if (iEnd != -1)
                {
                    // include the End string if desired
                    if (includeEnd)
                        iEnd += strEnd.Length;

                    result[0] = strSource.Substring(0, iEnd);

                    // advance beyond this segment

                    if (iEnd + strEnd.Length < strSource.Length)
                        result[1] = strSource.Substring(iEnd + strEnd.Length);
                }
            }

            else
                // stay where we are
                result[1] = strSource;
            return result;

        }

        public static List<string> GetStringInBetween(string text, string start, string end)
        {
            
            string regex = string.Format("{0}(.*?){1}",
                Regex.Escape(start),
                Regex.Escape(end));

            MatchCollection matches = Regex.Matches(text, regex, RegexOptions.Singleline);
            List<string> matchesValues = new List<string>();

            foreach (Match match in matches)
            {
                if(Regex.IsMatch(match.Value,@"[a-zA-z0-9]"))
                matchesValues.Add(match.Value.Replace(start, string.Empty).Replace(end, string.Empty));
            }
            return matchesValues;
                
        }
        public static string ReplaceNewlines(string blockOfText, string replaceWith)
        {
            return blockOfText.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
        }

        public static DateTime MyDateConversion(string dateAsString)
        {
            return System.DateTime.ParseExact(dateAsString, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
        }

        public static int TryParse(string s)
        {
            int i;
            if (!int.TryParse(s, out i))
            {
                return 0;
            }
            else
            {
                return i;
            }
        }

        public static decimal TryParseDecimal(string s)
        {
            decimal i;
            if (!decimal.TryParse(s, out i))
            {
                return 0;
            }
            else
            {
                return i;
            }
        }


        #region Crytrogarphy Code
        
        private static byte[] key = { };

        private static byte[] IV = { 38, 55, 206, 48, 28, 64, 20, 16 };

        private static string stringKey = "!5663a#KN";


        public static string Encrypt(string text)
        {

            try
            {

                key = Encoding.UTF8.GetBytes(stringKey.Substring(0, 8));



                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                Byte[] byteArray = Encoding.UTF8.GetBytes(text);



                MemoryStream memoryStream = new MemoryStream();

                CryptoStream cryptoStream = new CryptoStream(memoryStream,

                    des.CreateEncryptor(key, IV), CryptoStreamMode.Write);



                cryptoStream.Write(byteArray, 0, byteArray.Length);

                cryptoStream.FlushFinalBlock();



                return Convert.ToBase64String(memoryStream.ToArray()).Replace("+","*");

            }

            catch (Exception ex)
            {

                // Handle Exception Here

            }



            return string.Empty;

        }

        public static string Decrypt(string text)
        {

            try
            {
                text = text.Replace("*", "+");
                key = Encoding.UTF8.GetBytes(stringKey.Substring(0, 8));



                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                Byte[] byteArray = Convert.FromBase64String(text);



                MemoryStream memoryStream = new MemoryStream();

                CryptoStream cryptoStream = new CryptoStream(memoryStream,

                    des.CreateDecryptor(key, IV), CryptoStreamMode.Write);



                cryptoStream.Write(byteArray, 0, byteArray.Length);

                cryptoStream.FlushFinalBlock();



                return Encoding.UTF8.GetString(memoryStream.ToArray());

            }

            catch (Exception ex)
            {

                // Handle Exception Here

            }



            return string.Empty;

        }
        
        #endregion

        public static string GetNumberFromString(string str)
        {
            str = str.Trim();
            Match m = Regex.Match(str, @"\d+");
            return (m.Value);
        }

        public static string GetFixedLengthString(string input, int length)
        {
            string result = string.Empty;

            if (string.IsNullOrEmpty(input))
            {
                result = new string(' ', length);
            }
            else if (input.Length > length)
            {
                result = input.Substring(0, length);
            }
            else
            {
                result = input.PadLeft(length);
            }

            return result;
        }

        public static string SetNullValueToDash(object value)
        {
            if (value != null)
            {
                System.Type datatype = value.GetType();
                if (datatype.Equals(typeof(DateTime)))
                {
                    if (DateTime.Parse(value.ToString()).Equals(DateTime.MinValue))
                        return "-";
                    else
                        return DateTime.Parse(value.ToString()).ToString("dd-MMM-yyyy");
                }
                else if (datatype.Equals(typeof(string)))
                {
                    if (string.IsNullOrEmpty(value.ToString()))
                        return "-";
                    else
                        return value.ToString();
                }
                else
                    return value.ToString();
            }
            else
                return "-";
        }

    }
}
