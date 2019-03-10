using SehrimiTani.BusinessLayer;
using SehrimiTani.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class CommenController : Controller
    {
        // GET: Commen
        private BarinmaManager barinmaManager = new BarinmaManager();
        public ActionResult ShowBarinmaComments(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barinma barinma = barinmaManager.ListQueryable().Include("Icerik").FirstOrDefault(x => x.Id == id);
            if (barinma == null)
            {
                return HttpNotFound();
            }
            
            return PartialView("_PartialYorumlar", barinma.Yorum);
        }
    }
}