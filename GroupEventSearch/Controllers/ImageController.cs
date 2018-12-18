using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using GroupEventSearch.Models;
using System.Diagnostics;

namespace GroupEventSearch.Controllers
{
    public class ImageController : Controller
    {
        private readonly ImageController he;

        public string WebRootPath { get; private set; }

        public ImageController(ImageController e)
        {
            he = e;
        }

        public IActionResult ShowFields(string fullName, IFormFile pic)
        {
            ViewData["fname"] = fullName;
            if (pic != null)
            {
                var fileName = Path.Combine(he.WebRootPath, Path.GetFileName(pic.FileName));
                pic.CopyTo(new FileStream(fileName, FileMode.Create));
                ViewData["fileLocation"] = "/" + Path.GetFileName(pic.FileName);
            }
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}