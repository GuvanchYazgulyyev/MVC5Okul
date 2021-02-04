using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UdemyMVC5Proje.Controllers
{
    public class HesapMController : Controller
    {
        // GET: HesapM
        public ActionResult Index(int s1 = 0, int s2 = 0)
        {
            int sonuc = s1 + s2;
         
            ViewBag.snc = sonuc;
          
            return View();
        }
    }
}