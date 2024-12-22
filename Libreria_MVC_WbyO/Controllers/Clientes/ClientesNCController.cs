using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Libreria_MVC_WbyO.Models;

namespace Libreria_MVC_WbyO.Controllers.Clientes
{
    public class ClientesNCController : Controller
    {
        private LibreriaEntities db = new LibreriaEntities();

        // GET: ClientesNC
        public ActionResult Index()
        {
            return View(db.Cliente.ToList());
        }

        // GET: ClientesNC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: ClientesNC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesNC/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Cliente,Nombre,A_Paterno,A_Materno,Telefono,Correo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                //Sweet alert
                SweetAlert("Cliente", "Cliente Creado con éxito", NotificationType.success);
                return RedirectToAction("Index");
               // return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: ClientesNC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: ClientesNC/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Cliente,Nombre,A_Paterno,A_Materno,Telefono,Correo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                //Sweet alert
                SweetAlert("Cliente", "El Cliente se actualizo con éxito", NotificationType.success);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: ClientesNC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: ClientesNC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
            db.SaveChanges();

            //Sweet alert
            SweetAlert("Cliente", "Cliente eliminado con éxito", NotificationType.success);
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
