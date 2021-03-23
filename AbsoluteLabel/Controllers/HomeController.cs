using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web.UI.WebControls;

namespace AbsoluteLabel.Controllers
{
    public class HomeController : Controller
    {
        string typeName;


        public ActionResult Index()
        {

            return View();
        }

        /* This action method takes the search string from the index view and searches the term using the Itunes api */
        [HttpGet]
        protected void Submit(object sender, EventArgs e)
        {
            typeName = Request.Form["TypeName"];
        }
        public ActionResult Search(String searchTerm)
        {

            try
            {
                
                //string typeName = Request.Form["TypeName"];
                SearchResult releases = new SearchResult();
                String actual_url = "https://itunes.apple.com/search?term=";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(actual_url + searchTerm + "&entity" +  typeName);

                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 58.0.3029.110 Safari / 537.36";
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                request.ContentType = "application/json";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string content = string.Empty;
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }

                releases = JsonConvert.DeserializeObject<SearchResult>(content);
                return View(releases);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}