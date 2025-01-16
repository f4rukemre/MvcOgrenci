using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models;

namespace OgrenciNotMvc.Controllers
{
    public class ÖğrenciController : Controller
    {
        DbMvcOkulEntities db=new DbMvcOkulEntities();
        public ActionResult ÖğrenciListesi()
        {
            var ogrlist = db.TBLOGRENCILER.ToList();
            return View(ogrlist);
        }
        [HttpGet]
        public ActionResult ÖğrenciEkle()
        {
            var kulüpler=db.TBLKULÜPLER.ToList();
            var list = new SelectList(kulüpler, "KULUPID", "KULUPAD");
            ViewBag.Kulüpler=list;
            return View();
        }
        [HttpPost]
        public ActionResult ÖğrenciEkle(TBLOGRENCILER ogr)
        {
            db.TBLOGRENCILER.Add(ogr);
            db.SaveChanges();
            return RedirectToAction("ÖğrenciListesi");
        }
        public ActionResult ÖğrenciSil(int id)
        {
            var value=db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ÖğrenciListesi");
        }
        [HttpGet]
        public ActionResult ÖğrenciGüncelle(int id)
        {
            var ogr = db.TBLOGRENCILER.Find(id);
            return View(ogr);
        }
        [HttpPost]
        public ActionResult ÖğrenciGüncelle(TBLOGRENCILER ogr)
        {
            var guncelleOgr=db.TBLOGRENCILER.Find(ogr.OGRID);
            guncelleOgr.OGRAD=ogr.OGRAD;
            guncelleOgr.OGRSOYAD=ogr.OGRSOYAD;
            guncelleOgr.OGRFOTO=ogr.OGRFOTO;
            guncelleOgr.OGRCINSIYET=ogr.OGRCINSIYET;
            guncelleOgr.OGRKULUP=ogr.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("ÖğrenciListesi");
        }
    }
}