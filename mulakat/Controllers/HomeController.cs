using mulakat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mulakat.Controllers
{
    public class HomeController : Controller
    {
        mulakattEntities1 ctx = new mulakattEntities1();

        // GET: Home
        public ActionResult Index()
        {
            return Redirect("/Home/Listele");
        }
        public ActionResult Listele()
        {
            List<odio_detay> listele = ctx.odio_detay.ToList();
            ViewBag.liste = listele;
            return View();
        }

        [HttpPost]//Silme İşlemi
        public ActionResult Listele(int id)
        {
            ctx.odio_detay.Remove(ctx.odio_detay.Find(id));
            ctx.SaveChanges();
            return Redirect("/Home/Listele");
        }
        public ActionResult Detay(int id)
        {
            ViewBag.Kayit = ctx.odio_detay.Find(id);
            return View();
        }
        [HttpPost]
        public ActionResult Detay(odio_detay odio)
        {
            odio_detay odio2 = ctx.odio_detay.FirstOrDefault(x=>x.ID == odio.ID);
            //odio2 = odio;
            odio2.KANAAT = odio.KANAAT;
            odio2.TARIH = odio.TARIH;
            odio2.sagALTI = odio.sagALTI;
            odio2.sagBESYUZ = odio.sagBESYUZ;
            odio2.sagBIR = odio.sagBIR;
            odio2.sagDORT = odio.sagDORT;
            odio2.sagIKI = odio.sagIKI;
            odio2.sagIKIYUZELLI = odio.sagIKIYUZELLI;
            odio2.sagSEKIZ = odio.sagSEKIZ;
            odio2.sagUC = odio.sagUC;
            odio2.SolALTI = odio.SolALTI;
            odio2.solBESYUZ = odio.solBESYUZ;
            odio2.solBIR = odio.solBIR;
            odio2.solDORT = odio.solDORT;
            odio2.solIKI = odio.solIKI;
            odio2.solIKIYUZELLI = odio.solIKIYUZELLI;
            odio2.SolSEKİZ = odio.SolSEKİZ;
            odio2.solUC = odio.solUC;
            ctx.SaveChanges();
            return Redirect("/Home/Listele");
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(odio_detay k)
        {
            ctx.odio_detay.Add(k);
            ctx.SaveChanges();
            return Redirect("/Home/Listele");
        }


    }
}