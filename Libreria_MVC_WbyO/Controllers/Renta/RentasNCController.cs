using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Libreria_MVC_WbyO.Models;

namespace Libreria_MVC_WbyO.Controllers.RentaNC
{
    public class RentasNCController : Controller
    {
        private LibreriaEntities db = new LibreriaEntities();

        // GET: RentasNC
        public ActionResult Index()
        {
            var renta = db.Renta.Include(r => r.Cliente).Include(r => r.EstadoFisico).Include(r => r.Libro);
            return View(renta.ToList());
        }

        // GET: RentasNC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renta renta = db.Renta.Find(id);
            if (renta == null)
            {
                return HttpNotFound();
            }
            return View(renta);
        }

        // GET: RentasNC/Create
        public ActionResult Create()
        {
            ViewBag.Cliente_Id = new SelectList(db.Cliente, "Id_Cliente", "Nombre");
            ViewBag.Estado_Id = new SelectList(db.EstadoFisico, "Id_Estado", "EstadoFisico1");
            ViewBag.Libro_Id = new SelectList(db.Libro, "Id_Libro", "Nombre");
            return View();
        }

        // POST: RentasNC/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Renta,Fecha_Salida,Fecha_Entrega,Libro_Id,Cliente_Id,Estado_Id")] Renta renta)
        {
            if (ModelState.IsValid)
            {
                db.Renta.Add(renta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente_Id = new SelectList(db.Cliente, "Id_Cliente", "Nombre", renta.Cliente_Id);
            ViewBag.Estado_Id = new SelectList(db.EstadoFisico, "Id_Estado", "EstadoFisico1", renta.Estado_Id);
            ViewBag.Libro_Id = new SelectList(db.Libro, "Id_Libro", "Nombre", renta.Libro_Id);
            return View(renta);
        }

        // GET: RentasNC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renta renta = db.Renta.Find(id);
            if (renta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente_Id = new SelectList(db.Cliente, "Id_Cliente", "Nombre", renta.Cliente_Id);
            ViewBag.Estado_Id = new SelectList(db.EstadoFisico, "Id_Estado", "EstadoFisico1", renta.Estado_Id);
            ViewBag.Libro_Id = new SelectList(db.Libro, "Id_Libro", "Nombre", renta.Libro_Id);
            return View(renta);
        }

        // POST: RentasNC/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Renta,Fecha_Salida,Fecha_Entrega,Libro_Id,Cliente_Id,Estado_Id")] Renta renta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(renta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente_Id = new SelectList(db.Cliente, "Id_Cliente", "Nombre", renta.Cliente_Id);
            ViewBag.Estado_Id = new SelectList(db.EstadoFisico, "Id_Estado", "EstadoFisico1", renta.Estado_Id);
            ViewBag.Libro_Id = new SelectList(db.Libro, "Id_Libro", "Nombre", renta.Libro_Id);
            return View(renta);
        }

        // GET: RentasNC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renta renta = db.Renta.Find(id);
            if (renta == null)
            {
                return HttpNotFound();
            }
            return View(renta);
        }

        // POST: RentasNC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Renta renta = db.Renta.Find(id);
            db.Renta.Remove(renta);
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
