﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.MUSTERILER select d;
            if(!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.Musteri_AD.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.MUSTERILER.ToList();
            //return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(MUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.MUSTERILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var musteri = db.MUSTERILER.Find(id);
            db.MUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir (int id)
        {
            var mus = db.MUSTERILER.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(MUSTERILER p1)
        {
            var musteri = db.MUSTERILER.Find(p1.Musteri_ID);
            musteri.Musteri_AD = p1.Musteri_AD;
            musteri.Musteri_SOYAD = p1.Musteri_SOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}