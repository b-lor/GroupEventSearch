using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupEventSearch.Data;
using GroupEventSearch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroupEventSearch.Controllers
{
    public class ZomatoSearchController : Controller
    {
        // GET: ZomatoSearch

        //private readonly ApplicationDbContext _db;

        //public ZomatoSearchController(ApplicationDbContext db)
        //{
        //    _db = db;
        //}

        //public IActionResult Index()
        //{
        //    List<Cuisine> cuisines = new List<Cuisine>();
        //    cuisines = _db.Cuisine.ToList();
        //    ViewBag.listofitems = cuisines;

        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Index(Cuisine cuisine)
        //{
        //    if (cuisine.CuisineId == 0)
        //    {
        //        ModelState.AddModelError("", "Select a cuisine");
        //    }

        //    int SelectValue = cuisine.CuisineId;

        //    List<Cuisine> cuisines = new List<Models.Cuisine>();
        //    ViewBag.listofitems = cuisines;

        //    return View();

        //}

        public ActionResult Index()
        {
            return View();
        }

        // GET: ZomatoSearch/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ZomatoSearch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZomatoSearch/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ZomatoSearch/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ZomatoSearch/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ZomatoSearch/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ZomatoSearch/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}