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
    public class librosController : Controller
    {
        private Database2Entities db = new Database2Entities();

        // GET: libros
        public ActionResult Index()
        {
            var libros = db.libros.Include(l => l.autor).Include(l => l.editorial);
            return View(libros.ToList());
        }

        // GET: libros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            libros libros = db.libros.Find(id);
            if (libros == null)
            {
                return HttpNotFound();
            }
            return View(libros);
        }

        // GET: libros/Create
        public ActionResult Create()
        {
            ViewBag.claveA = new SelectList(db.autor, "claveA", "nombreA");
            ViewBag.claveE = new SelectList(db.editorial, "claveE", "nombree");
            return View();
        }

        // POST: libros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "claveL,titulo,claveA,claveE")] libros libros)
        {
            if (ModelState.IsValid)
            {
                db.libros.Add(libros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.claveA = new SelectList(db.autor, "claveA", "nombreA", libros.claveA);
            ViewBag.claveE = new SelectList(db.editorial, "claveE", "nombree", libros.claveE);
            return View(libros);
        }

        // GET: libros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            libros libros = db.libros.Find(id);
            if (libros == null)
            {
                return HttpNotFound();
            }
            ViewBag.claveA = new SelectList(db.autor, "claveA", "nombreA", libros.claveA);
            ViewBag.claveE = new SelectList(db.editorial, "claveE", "nombree", libros.claveE);
            return View(libros);
        }

        // POST: libros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "claveL,titulo,claveA,claveE")] libros libros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.claveA = new SelectList(db.autor, "claveA", "nombreA", libros.claveA);
            ViewBag.claveE = new SelectList(db.editorial, "claveE", "nombree", libros.claveE);
            return View(libros);
        }

        // GET: libros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            libros libros = db.libros.Find(id);
            if (libros == null)
            {
                return HttpNotFound();
            }
            return View(libros);
        }

        // POST: libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            libros libros = db.libros.Find(id);
            db.libros.Remove(libros);
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
