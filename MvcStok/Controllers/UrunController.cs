using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.URUNLER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler=(from i in db.KATEGORILER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Kategori_AD,
                                               Value = i.Kategori_ID.ToString()
                                           }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(URUNLER p1)
        {
            var ktg = db.KATEGORILER.Where(m => m.Kategori_ID == p1.KATEGORILER.Kategori_ID).FirstOrDefault();
            p1.KATEGORILER = ktg;
            db.URUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.URUNLER.Find(id);
            db.URUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.URUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.KATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Kategori_AD,
                                                 Value = i.Kategori_ID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;     
            return View("UrunGetir", urun);

        }
        public ActionResult Guncelle(URUNLER p)
        {
            var urun = db.URUNLER.Find(p.Urun_ID);
            urun.Urun_AD = p.Urun_AD;
            urun.MARKA = p.MARKA;
            urun.STOK = p.STOK;
            urun.FIYAT = p.FIYAT;
            //urun.Urun_KATEGORI = p.Urun_KATEGORI;
            var ktg = db.KATEGORILER.Where(m => m.Kategori_ID == p.KATEGORILER.Kategori_ID).FirstOrDefault();
            urun.Urun_KATEGORI = ktg.Kategori_ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}