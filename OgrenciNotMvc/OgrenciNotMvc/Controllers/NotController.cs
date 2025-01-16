using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models;

namespace OgrenciNotMvc.Controllers
{
    public class NotController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult NotListesi()
        {
            var notlist = db.TBLNOTLAR.ToList();
            return View(notlist);
        }
        [HttpGet]
        public ActionResult NotEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NotEkle(TBLNOTLAR notlar)
        {
            db.TBLNOTLAR.Add(notlar);
            db.SaveChanges();
            return RedirectToAction("NotListesi");
        }
        public ActionResult NotSil(int id)
        {
            var value = db.TBLNOTLAR.Find(id);
            db.TBLNOTLAR.Remove(value);
            db.SaveChanges();
            return RedirectToAction("NotListesi");
        }
        [HttpGet]
        public ActionResult NotGüncelle(int id)
        {
            var not = db.TBLNOTLAR.Find(id);
            return View(not);
        }
        [HttpPost]
        public ActionResult NotGüncelle(TBLNOTLAR notlar)
        {
            var guncelleNotlar = db.TBLNOTLAR.Find(notlar.NOTID);
            guncelleNotlar.DERSID = notlar.DERSID;
            guncelleNotlar.OGRID = notlar.OGRID;
            guncelleNotlar.SINAV1 = notlar.SINAV1;
            guncelleNotlar.SINAV2 = notlar.SINAV2;
            guncelleNotlar.SINAV3 = notlar.SINAV3;
            guncelleNotlar.PROJE = notlar.PROJE;
            guncelleNotlar.ORTALAMA = notlar.ORTALAMA;
            guncelleNotlar.DURUM = notlar.DURUM;
            db.SaveChanges();
            return RedirectToAction("NotListesi");
        }
    }
}