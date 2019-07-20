using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WebAPIClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveRecord(String txtWord)
        {
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:50169/");
            client.BaseAddress = new Uri("https://webapiforcloudsg.azurewebsites.net");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("appcation/json"));
            string root = "api/values/" + txtWord;
            HttpResponseMessage response = client.GetAsync(root).Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<string>().Result;

            }
            else
            {
                ViewBag.result = "Error";
            }

            return View("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}