using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SNRegistros.Dominio.DB;

namespace SNRegistro.Controllers
{
    public class CiudadanoesController : Controller
    {
        private SNRegistroEntities db = new SNRegistroEntities();

        // GET: Ciudadanoes
        public ActionResult Index()
        {
            return View(db.Ciudadanos.ToList());
        }

        // GET: Ciudadanoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudadano ciudadano = db.Ciudadanos.Find(id);
            if (ciudadano == null)
            {
                return HttpNotFound();
            }
            return View(ciudadano);
        }

        // GET: Ciudadanoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ciudadanoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CiudadanoID,Nombre,Apellido")] Ciudadano ciudadano)
        {
            if (ModelState.IsValid)
            {
                db.Ciudadanos.Add(ciudadano);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ciudadano);
        }

        // GET: Ciudadanoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudadano ciudadano = db.Ciudadanos.Find(id);
            if (ciudadano == null)
            {
                return HttpNotFound();
            }
            return View(ciudadano);
        }

        // POST: Ciudadanoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CiudadanoID,Nombre,Apellido")] Ciudadano ciudadano)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudadano).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ciudadano);
        }

        // GET: Ciudadanoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudadano ciudadano = db.Ciudadanos.Find(id);
            if (ciudadano == null)
            {
                return HttpNotFound();
            }
            return View(ciudadano);
        }

        // POST: Ciudadanoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ciudadano ciudadano = db.Ciudadanos.Find(id);
            db.Ciudadanos.Remove(ciudadano);
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
