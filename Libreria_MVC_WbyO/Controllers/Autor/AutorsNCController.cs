using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Libreria_MVC_WbyO.Models;

namespace Libreria_MVC_WbyO.Controllers.AutorNC
{
    public class AutorsNCController : Controller
    {
        private LibreriaEntities db = new LibreriaEntities();

        // GET: AutorsNC
        public ActionResult Index()
        {
            return View(db.Autor.ToList());
        }

        // GET: AutorsNC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autor autor = db.Autor.Find(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }

        // GET: AutorsNC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutorsNC/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Autor,Nombre,Apellido_P,Apellido_M")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                db.Autor.Add(autor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autor);
        }

        // GET: AutorsNC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autor autor = db.Autor.Find(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }

        // POST: AutorsNC/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Autor,Nombre,Apellido_P,Apellido_M")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autor);
        }

        // GET: AutorsNC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autor autor = db.Autor.Find(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }

        // POST: AutorsNC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Autor autor = db.Autor.Find(id);
            db.Autor.Remove(autor);
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
