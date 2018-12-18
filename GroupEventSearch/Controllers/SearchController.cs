using GroupEventSearch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json;

using PagedList;

namespace GroupEventSearch.Controllers
{
    public class SearchController : Controller
    {

        private readonly IMemoryCache _cache;
        private readonly DataCache dataCache;
        public SearchController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
            dataCache = new DataCache(memoryCache);
        }


        public string Location { get; set; }
        public string Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Page { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }


        // GET: Search
        public ActionResult Index(string location, string category, DateTime? startDate, DateTime? endDate, int? page)
        {
            if (!string.IsNullOrEmpty(location))
            {
                HttpContext.Session.SetString("Location", location);
                ViewBag.Location = location;
            }

            Location = (string)HttpContext.Session.GetString("Location");

            if (!string.IsNullOrEmpty(category))
            {
                HttpContext.Session.SetString("Category", category);
                ViewBag.Category = category;
            }
            Category = (string)HttpContext.Session.GetString("Category");


            if (startDate.HasValue)
            {
                HttpContext.Session.SetString("StartDate", startDate.ToString());
                ViewBag.StartDate = (DateTime)startDate;
            }
            DateTime dateTime;
            DateTime.TryParse(HttpContext.Session.GetString("StartDate"), out dateTime);
            StartDate = dateTime;

            if (endDate.HasValue)
            {
                HttpContext.Session.SetString("EndDate", endDate.ToString());
                ViewBag.EndDate = (DateTime)endDate;
            }
            DateTime eoutDate;
            DateTime.TryParse(HttpContext.Session.GetString("EndDate"),out eoutDate);
            EndDate = eoutDate;

            if (page.HasValue)
            {
                Page = (int)page;
            }
            else
            {
                Page = 1;
            }


            string url = ConfigurationManager.AppSettings["URL"];
            string appKey = ConfigurationManager.AppSettings["AppKey"];
            RestClient client = new RestClient(url, HttpVerb.GET);
            int totalPages = 1000;
            int page_size = 1000;
            string json = null;

            if (dataCache.GetCachedObject("CachedData") == null || location != null || category != null || startDate.HasValue || endDate.HasValue)
            {
                json = client.MakeRequest(string.Format("?app_key={0}&location={1}&q={2}&date={3}-{4}&page_size={5}&sort_order=start_time&sort_direction=descending",
                                                appKey, Location, Category, StartDate.ToString("yyyyMMdd00"), EndDate.ToString("yyyyMMdd00"), totalPages));
                dataCache.SetCachedObjectPermanent("CachedData", json);
            }
            else
            {
                json = (string)dataCache.GetCachedObject("CachedData");
            }


            JObject jobject = JObject.Parse(json);
            if (jobject["events"].HasValues)
            {
                var evts = jobject["events"]["event"];

                IList<Events> events = new List<Events>();
                foreach (var ev in evts)
                {
                    Events e = new Events
                    {

                        Title = (string)ev["title"],
                        Performers =
                            ev["performers"].HasValues ? ev["performers"].ToObject<Dictionary<string, JToken>>() : null,
                        Image = ev["image"].HasValues ? ev["image"].ToObject<Dictionary<string, JToken>>() : null,
                        StartDatetime = (DateTime)ev["start_time"],
                        Location =
                            //(string)ev["venue_address"] + ", " + (string)ev["city_name"] + ", " +
                            //(string)ev["region_abbr"] + ", " + (string)ev["country_name"],
                            (string)ev["venue_address"] + ", " + (string)ev["city_name"],
                        Latitude = (string)ev["latitude"],
                        Longitude = (string)ev["longitude"],
                    };
                    events.Add(e);
                }
                ViewBag.CurrentSort = "start_time";

                ViewBag.Model = events.ToPagedList(Page, page_size);

                return View();
            }
            System.Web.Mvc.HandleErrorInfo error = new System.Web.Mvc.HandleErrorInfo(new Exception("Found nothing"), "Search", "Index");
            return View("_Error", error);
        }


    }
}
