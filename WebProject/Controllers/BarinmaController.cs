using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SehrimiTani.BusinessLayer;
using SehrimiTani.Entities;

namespace WebProject.Controllers
{
    public class BarinmaController : Controller
    {

        private BarinmaManager barinmaManager = new BarinmaManager();
        // GET: Barinma
        public ActionResult Index()
        {
            return View(barinmaManager.List());
        }

        // GET: Barinma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barinma barinma = barinmaManager.Find(x => x.Id == id.Value);
            if (barinma == null)
            {
                return HttpNotFound();
            }
            return View(barinma);
        }

        // GET: Barinma/Create
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Barinma barinma)
        {

            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                barinmaManager.Insert(barinma);
                return RedirectToAction("Index");
            }

            return View(barinma);
        }
       
        public ActionResult GetBarinmaDetay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barinma barinma = barinmaManager.ListQueryable().Include("Icerik").FirstOrDefault(x => x.Id == id);
            if (barinma == null)
            {
                return HttpNotFound();
            }
            return PartialView("_PartialBarinma", barinma.Yorum);
        }
        // GET: Barinma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barinma barinma = barinmaManager.Find(x => x.Id == id.Value);
            if (barinma == null)
            {
                return HttpNotFound();
            }
            return View(barinma);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Barinma barinma)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModiiedUsername");
            if (ModelState.IsValid)
            {
                Barinma barinmaBul = barinmaManager.Find(x => x.Id == barinma.Id);
                barinmaBul.Icerik = barinma.Icerik;
                barinmaBul.Adres = barinma.Adres;
                barinmaBul.ProileImagerFilename = barinma.ProileImagerFilename;
                barinmaManager.Update(barinmaBul);
                return RedirectToAction("Index");
            }
            return View(barinma);
        }

        // GET: Barinma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barinma barinma = barinmaManager.Find(x => x.Id == id.Value);
            if (barinma == null)
            {
                return HttpNotFound();
            }
            return View(barinma);
        }

        // POST: Barinma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barinma barinma = barinmaManager.Find(x => x.Id == id);
            barinmaManager.Delete(barinma);
            return RedirectToAction("Index");
        }

      
    }
}
