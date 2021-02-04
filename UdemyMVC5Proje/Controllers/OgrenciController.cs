using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVC5Proje.Models.EntitiFramework;
using UdemyMVC5Proje.Models;

namespace UdemyMVC5Proje.Controllers
{
    public class OgrenciController : Controller
    {   //                       Öğrencileri Listeleme Konutu
        // GET: Ogrenci
        VTMvcOkulEntities dr
            = new VTMvcOkulEntities();
        public ActionResult Index()
        {
            var ogrnc = dr.TBLOgrenci.ToList();
            return View(ogrnc);
        }

        //                       Klupler Tablosundaki Klüb adını Öğrenci Tablosuna çekme Komutu
        [HttpGet]
        public ActionResult OgrEkle()
        {
            List<SelectListItem> degerler = (from i in dr.TBLKulup.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
           

            //List<SelectListItem> degerler2 = (from i in dr.TBLOgrenci.ToList()
            //                                  select new SelectListItem
            //                                  {
            //                                      Text = i.OGRCINSIYET,
            //                                      Value = i.OGRENCIID.ToString()
            //                                  }).ToList();
            //ViewBag.dgr2 = degerler2;
            return View();

        }

        //                           Öğrenciler Tablosunda yeni Kayıt Ekleme
        [HttpPost]
        public ActionResult OgrEkle(TBLOgrenci ogrek)
        {
            var klp = dr.TBLKulup.Where(x => x.KULUPID == ogrek.TBLKulup.KULUPID).FirstOrDefault();
            ogrek.TBLKulup = klp;
            dr.TBLOgrenci.Add(ogrek);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }

        //                        Öğrencileri Silme Komutu

        public ActionResult Sil(int id)
        {
            var ogrsil = dr.TBLOgrenci.Find(id);
            dr.TBLOgrenci.Remove(ogrsil);
            dr.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var ogrgetr = dr.TBLOgrenci.Find(id);

            List<SelectListItem> degerler = (from i in dr.TBLKulup.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("OgrenciGetir", ogrgetr);
        }
        public ActionResult Guncelle(TBLOgrenci c)
        {
            var dersgncel = dr.TBLOgrenci.Find(c.OGRENCIID);
            //dersgncel.OGRENCIID = c.OGRENCIID;
            dersgncel.OGRAD = c.OGRAD;
            dersgncel.OGRSOYAD = c.OGRSOYAD;
            dersgncel.OGRTEL = c.OGRTEL;
            dersgncel.OGRFOTO = c.OGRFOTO;
            dersgncel.OGRCINSIYET = c.OGRCINSIYET;
            dersgncel.OGRKULUP = c.OGRKULUP;
            dr.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }
    }
}