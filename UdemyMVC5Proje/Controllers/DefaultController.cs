using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVC5Proje.Models.EntitiFramework;

namespace UdemyMVC5Proje.Controllers
{
    public class DefaultController : Controller
    {  //                      Yeni Dersi Listeleme komutları
        // GET: Default
        VTMvcOkulEntities dr = new VTMvcOkulEntities();
        public ActionResult Index()
        {
            var dersler = dr.TBLDersler.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }
        //                 Yeni Ders Ekleme Konutları 
        [HttpPost]
        public ActionResult YeniDers(TBLDersler drsek)
        {
            dr.TBLDersler.Add(drsek);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }
        //                         Dersleri Silme Komutları
        public ActionResult Sil(int id)
        {
            var derssil = dr.TBLDersler.Find(id);
            dr.TBLDersler.Remove(derssil);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }
        //                           Güncellemeden Önce ders Bilgilerini Getime Komutu
        public ActionResult DersGetir(int id)
        {
            var dersgetir = dr.TBLDersler.Find(id);
            return View("DersGetir", dersgetir);
        }
        public ActionResult Guncelle(TBLDersler a)
        {
            var dersguncel = dr.TBLDersler.Find(a.DERSID);
            dersguncel.DERSAD = a.DERSAD;
            dr.SaveChanges();
            return RedirectToAction("Index", "Default");

        }
    }

}