using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        //public ActionResult YeniSatis()
        //{
        //    return View("Index");
        //}
        [HttpPost]
        public ActionResult YeniSatis(SATISLAR p)
        {
            if(!ModelState.IsValid)
            {
                return View("Index");
            }
            db.SATISLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}