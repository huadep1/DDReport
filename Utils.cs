using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DDReport
{
    public class Utils
    {
        public static string extra_get_dtsg_token(string response_text)
        {
            try
            {
                var result = new Regex("name=\"fb_dtsg\" value=\"([^\"]+)\"", RegexOptions.None)
                    .Match(response_text)
                    .Groups[1].Value;
                return result;
            }
            catch
            {
                return "";
            }
        }
        public static CookieContainer parser_cookies(string cookies)
        {
            CookieContainer cookieContainer = new CookieContainer();
            string[] cookieValues = cookies.Split(';');
            foreach (string item in cookieValues)
            {
                var temp1 = item.Trim();
                var temp2 = temp1.Split('=');
                if (temp2.Length > 1)
                {
                    cookieContainer.Add(
                        new Uri("https://www.facebook.com"),
                        new Cookie(temp2[0], temp2[1])
                    );
                }
            }
            return cookieContainer;

        }

        public static string extra_get_story_id(string response_text)
        {
            try
            {
                var result = new Regex("\"storyID\":\"([^\\\"]+)\"", RegexOptions.None)
                    .Match(response_text)
                    .Groups[1].Value;
                return result;
            }
            catch
            {
                return "";
            }
        }
    }
}
