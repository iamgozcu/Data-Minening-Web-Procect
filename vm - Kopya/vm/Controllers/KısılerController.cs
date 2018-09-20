using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using vm;
using vm.Models;

namespace vm.Controllers
{
    public class KısılerController : Controller
    {
        private KullanicilerEntities3 db = new KullanicilerEntities1();

        // GET: Kısıler
        public ActionResult Index()
        {
            var kısıler = db.Kisiler.Include(k => k.OkulBlg);
            return View(kısıler.ToList());
        }

        //// GET: Kısıler/Details/5
        //public ActionResult Details(int? id)
        //{
        ////    if (id == null)
        ////    {
        ////        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        ////    }
        ////    Kisiler kısıler = db.Kisiler.Find(id);
        ////    if (kısıler == null)
        ////    {
        ////        return HttpNotFound();
        ////    }
        ////    return View(kısıler);
        ////}

        [HttpPost]
        public JsonResult SoruCevap(int soru, int cevap, string auth)
        {
            
       
            Table tb = new Table()
            {
                AnketId = auth,
                CevapId = cevap,
                SoruId = soru,
                OlusturmaTarihi = DateTime.Now
            };

            bool kontrol = db.Table.Any(x => x.AnketId == auth && x.SoruId == soru);
            if (!kontrol)
            {
                db.Table.Add(tb);
                db.SaveChanges();
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("0", JsonRequestBehavior.AllowGet);
            }

        }

        // GET: Kısıler/Create
        public ActionResult Create()
        {
            return View();
        }

        //partial view
        public ActionResult CreatePartial()
        {
            List<OkulBlg> list = db.OkulBlg.ToList();
            ViewBag.OkulID = list;
            return View();
        }

        // POST: Kısıler/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kisiler kisiler)
        {
            var data = db.Kisiler.FirstOrDefault(x => x.OkulNo == kisiler.OkulNo);
            if (data != null)
            {
                Session["OkulNo"] = data;
                Session["UserId"] = data.Id;
                return RedirectToAction("Index", "Kısıler");
            }
            //else
            //{
            //   //ModelState.AddModelError("","Girmiş olduğunuz okul numarası ile veri tabanındaki numara eşleşmiyor");
            //    // return RedirectToAction("hata","Kısıler");
            //}
            ViewBag.Hata = "GİRMİŞ OLDUĞU OKUL NUMARASI VERİ TABANINDAKİ NUMARA İLE EŞLEŞMİYOR!!!";

            return View();

        }
        public ActionResult hata()
        {
            return View();
        }

        // GET: Kısıler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kisiler kısıler = db.Kisiler.Find(id);
            if (kısıler == null)
            {
                return HttpNotFound();
            }
            ViewBag.OkulID = new SelectList(db.OkulBlg, "Id", "OkulAdı", kısıler.OkulID);
            return View(kısıler);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Adı,Soyadı,Yas,OkulID")] Kisiler kısıler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kısıler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OkulID = new SelectList(db.OkulBlg, "Id", "OkulAdı", kısıler.OkulID);
            return View(kısıler);
        }

        // GET: Kısıler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kisiler kısıler = db.Kisiler.Find(id);
            if (kısıler == null)
            {
                return HttpNotFound();
            }
            return View(kısıler);
        }

        // POST: Kısıler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kisiler kısıler = db.Kisiler.Find(id);
            db.Kisiler.Remove(kısıler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
