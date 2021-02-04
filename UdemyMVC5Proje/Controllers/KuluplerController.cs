using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVC5Proje.Models.EntitiFramework;

namespace UdemyMVC5Proje.Controllers
{
    
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        VTMvcOkulEntities dr
            = new VTMvcOkulEntities();
        public ActionResult Index()
        {
            var kulupler = dr.TBLKulup.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult KlupEkle()
        {
            return View();
        }
        //                yeni Külüp Ekleme Komutu
        [HttpPost]
        public ActionResult KlupEkle(TBLKulup klpekle)
        {
            dr.TBLKulup.Add(klpekle);
            dr.SaveChanges();
            return View();
        }
        // .                       Yeni Külüp Silme Komutu 
        public ActionResult Sil(int id)
        {
            var klupp = dr.TBLKulup.Find(id);
            dr.TBLKulup.Remove(klupp);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }
        //                           Güncellemeden Önce Klüp Bilgilerini Getime Komutu

        public ActionResult KlupGetir(int id)
        {
            var klupp2 = dr.TBLKulup.Find(id);
            return View("KlupGetir", klupp2);
        }
        public ActionResult Guncelle(TBLKulup id)
        {
            var klpguncel = dr.TBLKulup.Find(id.KULUPID);
            klpguncel.KULUPAD = id.KULUPAD;
            klpguncel.KULUPKONTENJAN = id.KULUPKONTENJAN;
            dr.SaveChanges();
            return RedirectToAction("Index", "Kulupler");
        }
    }
}