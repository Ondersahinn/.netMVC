using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SehrimiTani.BusinessLayer;
using SehrimiTani.BusinessLayer.Result;
using SehrimiTani.Entities;


namespace WebProject.Controllers
{
    public class KullanicilarController : Controller
    {
        private SehrimiTaniUserManager sehrimiTaniUserManager = new SehrimiTaniUserManager();
        // GET: Kullanicilar
        public ActionResult Index()
        {
            return View(sehrimiTaniUserManager.List());
        }

        // GET: Kullanicilar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanicilar kullanicilar =sehrimiTaniUserManager.Find(x=>x.Id==id.Value);
            if (kullanicilar == null)
            {
                return HttpNotFound();
            }
            return View(kullanicilar);
        }

        // GET: Kullanicilar/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kullanicilar kullanicilar)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                BusinessLayerResult<Kullanicilar> res = sehrimiTaniUserManager.Insert(kullanicilar);
                if (res.Errors.Count>0)
                {
                    res.Errors.ForEach(x=>ModelState.AddModelError("",x.Message));
                    return View(kullanicilar);
                }
                return RedirectToAction("Index");
            }

            return View(kullanicilar);
        }

        // GET: Kullanicilar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanicilar kullanicilar = sehrimiTaniUserManager.Find(x => x.Id == id.Value);
            if (kullanicilar == null)
            {
                return HttpNotFound();
            }
            return View(kullanicilar);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kullanicilar kullanicilar)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            BusinessLayerResult<Kullanicilar> res = sehrimiTaniUserManager.Update(kullanicilar);
            if (res.Errors.Count > 0)
            {
                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(kullanicilar);
            }
            return View(kullanicilar);
        }

        // GET: Kullanicilar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanicilar kullanicilar = sehrimiTaniUserManager.Find(x => x.Id == id.Value);
            if (kullanicilar == null)
            {
                return HttpNotFound();
            }
            return View(kullanicilar);
        }

        // POST: Kullanicilar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kullanicilar kullanicilar = sehrimiTaniUserManager.Find(x => x.Id == id);
            sehrimiTaniUserManager.Delete(kullanicilar);
            return RedirectToAction("Index");
        }

    }
}
