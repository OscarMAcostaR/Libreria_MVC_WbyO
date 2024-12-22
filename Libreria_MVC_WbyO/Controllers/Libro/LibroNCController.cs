using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Libreria_MVC_WbyO.Models;

namespace Libreria_MVC_WbyO.Controllers.LibroNC
{
    public class LibroNCController : Controller
    {
        private LibreriaEntities db = new LibreriaEntities();

        // GET: LibroNC
        public ActionResult Index()
        {
            var libro = db.Libro.Include(l => l.Autor).Include(l => l.Categoria).Include(l => l.Editorial);
            return View(libro.ToList());
        }

        // GET: LibroNC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: LibroNC/Create
        public ActionResult Create()
        {
            ViewBag.Autor_Id = new SelectList(db.Autor, "Id_Autor", "Nombre");
            ViewBag.Categoria_Id = new SelectList(db.Categoria, "Id_Categoria", "Nombre");
            ViewBag.Editorial_Id = new SelectList(db.Editorial, "Id_Editorial", "Nombre");
            return View();
        }

        // POST: LibroNC/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Libro,Nombre,Costo_total,Costo_Renta,Categoria_Id,Autor_Id,Editorial_Id,Disponible")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Libro.Add(libro);
                db.SaveChanges();
                //Sweet alert
                SweetAlert("Libro", "El Libro se Agrego con éxito", NotificationType.success);
                return RedirectToAction("Index");
               // return RedirectToAction("Index");
            }

            ViewBag.Autor_Id = new SelectList(db.Autor, "Id_Autor", "Nombre", libro.Autor_Id);
            ViewBag.Categoria_Id = new SelectList(db.Categoria, "Id_Categoria", "Nombre", libro.Categoria_Id);
            ViewBag.Editorial_Id = new SelectList(db.Editorial, "Id_Editorial", "Nombre", libro.Editorial_Id);
            return View(libro);
        }

        // GET: LibroNC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.Autor_Id = new SelectList(db.Autor, "Id_Autor", "Nombre", libro.Autor_Id);
            ViewBag.Categoria_Id = new SelectList(db.Categoria, "Id_Categoria", "Nombre", libro.Categoria_Id);
            ViewBag.Editorial_Id = new SelectList(db.Editorial, "Id_Editorial", "Nombre", libro.Editorial_Id);
            return View(libro);
        }

        // POST: LibroNC/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Libro,Nombre,Costo_total,Costo_Renta,Categoria_Id,Autor_Id,Editorial_Id,Disponible")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                //Sweet alert
                SweetAlert("Libro", "El Libro se actualizo con éxito", NotificationType.success);
                return RedirectToAction("Index");
                //return RedirectToAction("Index");

            }
            ViewBag.Autor_Id = new SelectList(db.Autor, "Id_Autor", "Nombre", libro.Autor_Id);
            ViewBag.Categoria_Id = new SelectList(db.Categoria, "Id_Categoria", "Nombre", libro.Categoria_Id);
            ViewBag.Editorial_Id = new SelectList(db.Editorial, "Id_Editorial", "Nombre", libro.Editorial_Id);
            return View(libro);
        }



        // GET: LibroNC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                SweetAlert("No encontrado", $"No hemos encontrado el Libro con identificador {id}", NotificationType.info);
                return RedirectToAction("Index");


            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: LibroNC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Libro libro = db.Libro.Find(id);
            db.Libro.Remove(libro);
            db.SaveChanges();
            SweetAlert("Eliminado", "Libro eliminado con éxito", NotificationType.success);
            return RedirectToAction("Index");
           // return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        /////Implementacion dE sweet alert con regioon de sweet alert
        ///
        #region Sweet Alert
        //Declaración de un HTMLHelper personalizado: Digase de aquél método auxilar que me permite construir código HTML/JS en tiempo real basado en las acciones del Razor/Controller
        private void SweetAlert(string title, string msg, NotificationType type)
        {
            var script = "<script languaje='javascript'> " +
             "Swal.fire({" +
             "title: '" + title + "'," +
             "text: '" + msg + "'," +
             "icon: '" + type + "'" +
             "});" +
             "</script>";
            //TempData funciona como un ViewBag, pasando información del controlador a cualquier parte de mi proyecto, siendo este,  más observable y con un tiempo de vida mayor
            TempData["sweeralert"] = script;
        }


        private void SweetAlert_Eliminar(int id)
        {
            var script = "<script languaje='javascript'>" +
                "Swal.fire({" +
                "title: '¿Estás Seguro?'," +
                "text: 'Estás apunto de Eliminar el Camión: " + id.ToString() + "'," +
                "icon: 'info'," +
                "showDenyButton: true," +
                "showCancelButton: true," +
                "confirmButtonText: 'Eliminar'," +
                "denyButtonText: 'Cancelar'" +
                "}).then((result) => {" +
                "if (result.isConfirmed) {  " +
                "window.location.href = '/Camiones/Eliminar_Camion/" + id + "';" +
                "} else if (result.isDenied) {  " +
                "Swal.fire('Se ha cancelado la operación','','info');" +
                "}" +
                "});" +
                "</script>";

            TempData["sweeralert"] = script;
        }


        public enum NotificationType
        {
            error,
            success,
            warning,
            info,
            question
        }

        #endregion
    }
}
