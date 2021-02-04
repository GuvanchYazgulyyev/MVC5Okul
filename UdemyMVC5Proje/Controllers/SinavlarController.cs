using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVC5Proje.Models.EntitiFramework;
using UdemyMVC5Proje.Models;

namespace UdemyMVC5Proje.Controllers
{
    public class SinavlarController : Controller
    {
        // GET: Sinavlar
        VTMvcOkulEntities dr
            = new VTMvcOkulEntities();
        public ActionResult Index()
        {
            var nt = dr.TBLNotlar.ToList();
            return View(nt);
        }
        [HttpGet]
        public ActionResult NotEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NotEkle(TBLNotlar ntekle)
        {
            var p2 = dr.TBLNotlar.Add(ntekle);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotGetir(int id)
        {
            var notgetr = dr.TBLNotlar.Find(id);
            return View("NotGetir", notgetr);
        }
        [HttpPost]
        public ActionResult NotGetir(Class1 model, TBLNotlar c, int VIZE = 0,
            int FINAL = 0, int PROJE = 0)
        {
            if (model.islem == "HESAPLA")
            {
                // işlem   1       Hatalı çalışmıyor
                int ORTALAMA = (VIZE + FINAL + PROJE) / 3;
                ViewBag.ort = ORTALAMA;
            }
            if (model.islem == "NOTGUNCELLE")
            {
                // işlem 2
                var snv = dr.TBLNotlar.Find(c.NOTID);
                snv.VIZE = c.VIZE;
                snv.FINAL = c.FINAL;
                snv.PROJE = c.PROJE;
                snv.ORTALAMA = c.ORTALAMA;
                dr.SaveChanges();
                return RedirectToAction("Index", "Sinavlar");
            }
            return View();
        }

    }
}