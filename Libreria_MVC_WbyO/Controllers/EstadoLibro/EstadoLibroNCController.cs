using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Libreria_MVC_WbyO.Models;

namespace Libreria_MVC_WbyO.Controllers.EstadoLibro
{
    public class EstadoLibroNCController : Controller
    {
        private LibreriaEntities db = new LibreriaEntities();

        // GET: EstadoLibroNC
        public ActionResult Index()
        {
            return View(db.EstadoFisico.ToList());
        }

        // GET: EstadoLibroNC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoFisico estadoFisico = db.EstadoFisico.Find(id);
            if (estadoFisico == null)
            {
                return HttpNotFound();
            }
            return View(estadoFisico);
        }

        // GET: EstadoLibroNC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoLibroNC/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Estado,EstadoFisico1")] EstadoFisico estadoFisico)
        {
            if (ModelState.IsValid)
            {
                db.EstadoFisico.Add(estadoFisico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoFisico);
        }

        // GET: EstadoLibroNC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoFisico estadoFisico = db.EstadoFisico.Find(id);
            if (estadoFisico == null)
            {
                return HttpNotFound();
            }
            return View(estadoFisico);
        }

        // POST: EstadoLibroNC/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Estado,EstadoFisico1")] EstadoFisico estadoFisico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoFisico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoFisico);
        }

        // GET: EstadoLibroNC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoFisico estadoFisico = db.EstadoFisico.Find(id);
            if (estadoFisico == null)
            {
                return HttpNotFound();
            }
            return View(estadoFisico);
        }

        // POST: EstadoLibroNC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoFisico estadoFisico = db.EstadoFisico.Find(id);
            db.EstadoFisico.Remove(estadoFisico);
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
