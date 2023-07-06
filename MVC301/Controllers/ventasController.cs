using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC301.Models;

namespace MVC301.Controllers
{
    public class ventasController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: ventas
        public ActionResult Index()
        {
            var ventas = db.ventas.Include(v => v.productos).Include(v => v.proveedores);
            return View(ventas.ToList());
        }

        // GET: ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ventas ventas = db.ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            return View(ventas);
        }

        // GET: ventas/Create
        public ActionResult Create()
        {
            ViewBag.ClaveP = new SelectList(db.productos, "claveP", "descripcion");
            ViewBag.IdP = new SelectList(db.proveedores, "IdP", "NombreP");
            return View();
        }

        // POST: ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVenta,FechaVenta,ClaveP,IdP")] ventas ventas)
        {
            if (ModelState.IsValid)
            {
                db.ventas.Add(ventas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClaveP = new SelectList(db.productos, "claveP", "descripcion", ventas.ClaveP);
            ViewBag.IdP = new SelectList(db.proveedores, "IdP", "NombreP", ventas.IdP);
            return View(ventas);
        }

        // GET: ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ventas ventas = db.ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClaveP = new SelectList(db.productos, "claveP", "descripcion", ventas.ClaveP);
            ViewBag.IdP = new SelectList(db.proveedores, "IdP", "NombreP", ventas.IdP);
            return View(ventas);
        }

        // POST: ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVenta,FechaVenta,ClaveP,IdP")] ventas ventas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClaveP = new SelectList(db.productos, "claveP", "descripcion", ventas.ClaveP);
            ViewBag.IdP = new SelectList(db.proveedores, "IdP", "NombreP", ventas.IdP);
            return View(ventas);
        }

        // GET: ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ventas ventas = db.ventas.Find(id);
            if (ventas == null)
            {
                return HttpNotFound();
            }
            return View(ventas);
        }

        // POST: ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ventas ventas = db.ventas.Find(id);
            db.ventas.Remove(ventas);
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
