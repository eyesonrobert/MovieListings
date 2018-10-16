using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;

namespace ProjectRF.ConsumerApi.Services
{
    public class WebScraping
    {
        static void Main(string[] args)
        {
            GetHtmlAsync();
            Console.ReadLine();
        }

        private static async void GetHtmlAsync()
        {
            var url = "https://www.ebay.com/sch/i.html?_from=R40&_nkw=retro+jordan+ones&_in_kw=1&_ex_kw=&_sacat=0&LH_Complete=1&_udlo=&_udhi=&_samilow=&_samihi=&_sadis=15&_stpos=48121&_sargn=-1%26saslc%3D1&_salic=1&_sop=12&_dmd=1&_ipg=50&_fosrp=1";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var ProductsHtml = htmlDocument.DocumentNode.Descendants("ul")
                .Where(node => node.GetAttributeValue("id", "")
                .Equals("ListViewInner")).ToList();

            var ProductListItems = ProductsHtml[0].Descendants("li")
                .Where(node => node.GetAttributeValue("id", "")
                .Contains("item")).ToList();
            Console.WriteLine(ProductListItems.Count());
            Console.WriteLine();
            foreach (var ProductListItem in ProductListItems)
            {
                //product id
                Console.WriteLine(ProductListItem.GetAttributeValue("listingid", ""));

                //product title
                Console.WriteLine(ProductListItem.Descendants("h3")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("lvtitle")).FirstOrDefault().InnerText.Trim('\r', '\n', '\t') //trim the return, new line, and tab from the values we are itterating through
                    );

                //product price (cleaned using regex)
                Console.WriteLine(
                    Regex.Match(
                        ProductListItem.Descendants("li")
                       .Where(node => node.GetAttributeValue("class", "")
                       .Equals("lvprice prc")).FirstOrDefault().InnerText.Trim('\r', '\n', '\t')  //trim the return, new line, and tab from the values we are itterating through
                   , @"\d+.\d+") //d is for decimal value. the + is for any number of decimal values following it
                       );


                //ListingType
                Console.WriteLine(
                      ProductListItem.Descendants("li")
                     .Where(node => node.GetAttributeValue("class", "")
                     .Equals("lvformat")).FirstOrDefault().InnerText.Trim('\r', '\n', '\t')
                     );

                //URL
                Console.WriteLine(
                    ProductListItem.Descendants("a").FirstOrDefault().GetAttributeValue("href", "").Trim('\r', '\n', '\t')
                    );
                Console.WriteLine();
                Console.Read();
            }
        }
    }
}
