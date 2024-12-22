using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Libreria_MVC_WbyO.Models;

namespace Libreria_MVC_WbyO.Controllers.DetalleVenta
{
    public class DetalleVentaNCController : Controller
    {
        private LibreriaEntities db = new LibreriaEntities();

        // GET: DetalleVentaNC
        public ActionResult Index()
        {
            var detalle_Venta = db.Detalle_Venta.Include(d => d.Libro);
            return View(detalle_Venta.ToList());
        }

        // GET: DetalleVentaNC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Venta detalle_Venta = db.Detalle_Venta.Find(id);
            if (detalle_Venta == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Venta);
        }

        // GET: DetalleVentaNC/Create
        public ActionResult Create()
        {
            ViewBag.Libro_Id = new SelectList(db.Libro, "Id_Libro", "Nombre");
            return View();
        }

        // POST: DetalleVentaNC/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Tiket,Cantidad,Total,Fecha,Libro_Id")] Detalle_Venta detalle_Venta)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_Venta.Add(detalle_Venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Libro_Id = new SelectList(db.Libro, "Id_Libro", "Nombre", detalle_Venta.Libro_Id);
            return View(detalle_Venta);
        }

        // GET: DetalleVentaNC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Venta detalle_Venta = db.Detalle_Venta.Find(id);
            if (detalle_Venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Libro_Id = new SelectList(db.Libro, "Id_Libro", "Nombre", detalle_Venta.Libro_Id);
            return View(detalle_Venta);
        }

        // POST: DetalleVentaNC/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Tiket,Cantidad,Total,Fecha,Libro_Id")] Detalle_Venta detalle_Venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_Venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Libro_Id = new SelectList(db.Libro, "Id_Libro", "Nombre", detalle_Venta.Libro_Id);
            return View(detalle_Venta);
        }

        // GET: DetalleVentaNC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Venta detalle_Venta = db.Detalle_Venta.Find(id);
            if (detalle_Venta == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Venta);
        }

        // POST: DetalleVentaNC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_Venta detalle_Venta = db.Detalle_Venta.Find(id);
            db.Detalle_Venta.Remove(detalle_Venta);
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
