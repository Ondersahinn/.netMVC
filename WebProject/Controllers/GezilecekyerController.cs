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
    public class GezilecekyerController : Controller
    {
        private GezilecekYerlerManager gezilecekYerlerManager = new GezilecekYerlerManager();
        // GET: Gezilecekyer
        public ActionResult Index()
        {
            return View(gezilecekYerlerManager.List());
        }

        // GET: Gezilecekyer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gezilecekyer gezilecekyer = gezilecekYerlerManager.Find(x=>x.Id==id.Value);
            if (gezilecekyer == null)
            {
                return HttpNotFound();
            }
            return View(gezilecekyer);
        }

        // GET: Gezilecekyer/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gezilecekyer gezilecekyer)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                gezilecekYerlerManager.Insert(gezilecekyer);
                return RedirectToAction("Index");
            }

            return View(gezilecekyer);
        }

        // GET: Gezilecekyer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gezilecekyer gezilecekyer = gezilecekYerlerManager.Find(x => x.Id == id.Value);
            if (gezilecekyer == null)
            {
                return HttpNotFound();
            }
            return View(gezilecekyer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Gezilecekyer gezilecekyer)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModiiedUsername");
            if (ModelState.IsValid)
            {
                Gezilecekyer gez = gezilecekYerlerManager.Find(x => x.Id == gezilecekyer.Id);
                gez.Icerik = gezilecekyer.Icerik;
                gez.Resim = gezilecekyer.Resim;
                gez.Baslik = gezilecekyer.Baslik;
                gezilecekYerlerManager.Update(gez);
                return RedirectToAction("Index");
            }
            return View(gezilecekyer);
        }

        // GET: Gezilecekyer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gezilecekyer gezilecekyer = gezilecekYerlerManager.Find(x => x.Id == id.Value);
            if (gezilecekyer == null)
            {
                return HttpNotFound();
            }
            return View(gezilecekyer);
        }

        // POST: Gezilecekyer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gezilecekyer gezilecekyer = gezilecekYerlerManager.Find(x => x.Id == id);
            gezilecekYerlerManager.Delete(gezilecekyer);
            return RedirectToAction("Index");
        }
    }
}
