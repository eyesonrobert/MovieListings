using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ProjectRF.ConsumerApi.Services
{
    public class TestScrape
    {
        public string Scrape()
        {
            string headlines = "";

            HtmlDocument doc = new HtmlDocument();
            doc.OptionFixNestedTags = true;
            string url = "https://python.org";

            // if you are using SSL use the following line
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls11;

            HttpWebRequest req = HttpWebRequest.Create(url) as HttpWebRequest;

            req.Method = "GET";
            /* Sart browser signature */
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0";
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            req.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-us,en;q=0.5");
            /* Sart browser signature */

            WebResponse response = req.GetResponse();

            doc.Load(response.GetResponseStream(), true);
            if (doc.DocumentNode != null)
            {
                var root = doc.DocumentNode;
                var hrefNodes = root.Descendants("a").ToList();
                foreach (HtmlNode node in hrefNodes)
                {
                    headlines += $"<li>{node.InnerText.Trim()}</li>";
                    //var articleNodes = doc.DocumentNode.SelectNodes("/html/body/div[@role='main']/div[1]/div/div[1]/div/ul/li");

                    //if (articleNodes != null && articleNodes.Any())
                    //{
                    //    foreach (var articleNode in articleNodes)
                    //    {
                    //        var titleNode = articleNode.SelectSingleNode("div/div/h2/a");
                    //        headlines += "<li>" + WebUtility.HtmlDecode(titleNode.InnerText.Trim()) + "</li>";
                    //    }
                    //}
                }

                return headlines;
            }
            return null;

        }
    }
}