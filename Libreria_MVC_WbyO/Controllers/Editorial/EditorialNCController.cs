using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Libreria_MVC_WbyO.Models;

namespace Libreria_MVC_WbyO.Controllers.EditorialNC
{
    public class EditorialNCController : Controller
    {
        private LibreriaEntities db = new LibreriaEntities();

        // GET: EditorialNC
        public ActionResult Index()
        {
            return View(db.Editorial.ToList());
        }

        // GET: EditorialNC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editorial editorial = db.Editorial.Find(id);
            if (editorial == null)
            {
                return HttpNotFound();
            }
            return View(editorial);
        }

        // GET: EditorialNC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EditorialNC/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Editorial,Nombre")] Editorial editorial)
        {
            if (ModelState.IsValid)
            {
                db.Editorial.Add(editorial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(editorial);
        }

        // GET: EditorialNC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editorial editorial = db.Editorial.Find(id);
            if (editorial == null)
            {
                return HttpNotFound();
            }
            return View(editorial);
        }

        // POST: EditorialNC/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Editorial,Nombre")] Editorial editorial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editorial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editorial);
        }

        // GET: EditorialNC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editorial editorial = db.Editorial.Find(id);
            if (editorial == null)
            {
                return HttpNotFound();
            }
            return View(editorial);
        }

        // POST: EditorialNC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Editorial editorial = db.Editorial.Find(id);
            db.Editorial.Remove(editorial);
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
