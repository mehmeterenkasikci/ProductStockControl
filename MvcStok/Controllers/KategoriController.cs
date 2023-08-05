using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.KATEGORILER.ToList();

            return View(degerler);
        }
        public ActionResult Ekleme() 
        {
            return View();
        }
        public ActionResult Silme()
        {
            return View();
        }

    }
}