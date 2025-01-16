using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models;

namespace OgrenciNotMvc.Controllers
{
    public class DersController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult DersListesi()
        {
            var ders = db.TBLDERSLER.ToList();
            return View(ders);
        }
        [HttpGet]
        public ActionResult DersEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DersEkle(TBLDERSLER ders)
        {
            db.TBLDERSLER.Add(ders);
            db.SaveChanges();
            return RedirectToAction("DersListesi");
        }
        public ActionResult DersSil(int id)
        {
            var value = db.TBLDERSLER.Find(id);
            db.TBLDERSLER.Remove(value);
            db.SaveChanges();
            return RedirectToAction("DersListesi");
        }
        [HttpGet]
        public ActionResult GuncelleDers(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            return View(ders);
        }
        [HttpPost]
        public ActionResult GuncelleDers(TBLDERSLER ders)
        {
            var guncelleDers = db.TBLDERSLER.Find(ders.DERSID);
            guncelleDers.DERSAD = ders.DERSAD;
            db.SaveChanges();
            return RedirectToAction("DersListesi");
        }
    }
}