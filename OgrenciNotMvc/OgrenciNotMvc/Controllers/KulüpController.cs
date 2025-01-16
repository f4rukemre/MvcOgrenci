using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models;

namespace OgrenciNotMvc.Controllers
{
    public class KulüpController : Controller
    {
        DbMvcOkulEntities db=new DbMvcOkulEntities();
        public ActionResult KulüpListesi()
        {
            var kulüp=db.TBLKULÜPLER.ToList();
            return View(kulüp);
        }
        [HttpGet]
        public ActionResult KulüpEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KulüpEkle(TBLKULÜPLER kulüp)
        {
            db.TBLKULÜPLER.Add(kulüp);
            db.SaveChanges();
            return RedirectToAction("KulüpListesi");
        }
        public ActionResult KulüpSil(int id)
        {
            var value =db.TBLKULÜPLER.Find(id);
            db.TBLKULÜPLER.Remove(value);
            db.SaveChanges();
            return RedirectToAction("KulüpListesi");
        }
        [HttpGet]
        public ActionResult KulüpGuncelle(int id)
        {
            var kulüp = db.TBLKULÜPLER.Find(id);
            return View(kulüp);
        }
        [HttpPost]
        public ActionResult KulüpGuncelle(TBLKULÜPLER kulüp)
        {
            var guncelleKulüp=db.TBLKULÜPLER.Find(kulüp.KULUPID);
            guncelleKulüp.KULUPAD = kulüp.KULUPAD;
            guncelleKulüp.KULUPKONT=kulüp.KULUPKONT;
            db.SaveChanges();
            return RedirectToAction("KulüpListesi");

        }
    }
}