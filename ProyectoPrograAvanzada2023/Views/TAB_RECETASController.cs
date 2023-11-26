using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoPrograAvanzada2023.Models2;

namespace ProyectoPrograAvanzada2023.Views
{
    public class TAB_RECETASController : Controller
    {
        private DB_PROYECTO_PAEntities db = new DB_PROYECTO_PAEntities();

        // GET: TAB_RECETAS
        public ActionResult Index()
        {
            var tAB_RECETAS = db.TAB_RECETAS.Include(t => t.TAB_CATEGORIAS).Include(t => t.TAB_ESTADO).Include(t => t.TAB_TAGS).Include(t => t.TAB_USER);
            return View(tAB_RECETAS.ToList());
        }

        // GET: TAB_RECETAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_RECETAS tAB_RECETAS = db.TAB_RECETAS.Find(id);
            if (tAB_RECETAS == null)
            {
                return HttpNotFound();
            }
            return View(tAB_RECETAS);
        }

        // GET: TAB_RECETAS/Create
        public ActionResult Create()
        {
            ViewBag.ID_CATEGORIA = new SelectList(db.TAB_CATEGORIAS, "ID_CATEGORIA", "CATEGORIA");
            ViewBag.ID_ESTADO = new SelectList(db.TAB_ESTADO, "ID_ESTADO", "ESTADO");
            ViewBag.ID_TAGS = new SelectList(db.TAB_TAGS, "ID_TAGS", "TAGS");
            ViewBag.ID_USER = new SelectList(db.TAB_USER, "ID_USER", "NOMBRE_USER");
            return View();
        }

        // POST: TAB_RECETAS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_RECETA,NOM_RECETA,ID_CATEGORIA,DURACION,PORCIONES,ID_TAGS,ID_ESTADO,ID_USER,FECHA_CREACION,FECHA_MODIFICACION")] TAB_RECETAS tAB_RECETAS)
        {
            if (ModelState.IsValid)
            {
                db.TAB_RECETAS.Add(tAB_RECETAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CATEGORIA = new SelectList(db.TAB_CATEGORIAS, "ID_CATEGORIA", "CATEGORIA", tAB_RECETAS.ID_CATEGORIA);
            ViewBag.ID_ESTADO = new SelectList(db.TAB_ESTADO, "ID_ESTADO", "ESTADO", tAB_RECETAS.ID_ESTADO);
            ViewBag.ID_TAGS = new SelectList(db.TAB_TAGS, "ID_TAGS", "TAGS", tAB_RECETAS.ID_TAGS);
            ViewBag.ID_USER = new SelectList(db.TAB_USER, "ID_USER", "NOMBRE_USER", tAB_RECETAS.ID_USER);
            return View(tAB_RECETAS);
        }

        // GET: TAB_RECETAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_RECETAS tAB_RECETAS = db.TAB_RECETAS.Find(id);
            if (tAB_RECETAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CATEGORIA = new SelectList(db.TAB_CATEGORIAS, "ID_CATEGORIA", "CATEGORIA", tAB_RECETAS.ID_CATEGORIA);
            ViewBag.ID_ESTADO = new SelectList(db.TAB_ESTADO, "ID_ESTADO", "ESTADO", tAB_RECETAS.ID_ESTADO);
            ViewBag.ID_TAGS = new SelectList(db.TAB_TAGS, "ID_TAGS", "TAGS", tAB_RECETAS.ID_TAGS);
            ViewBag.ID_USER = new SelectList(db.TAB_USER, "ID_USER", "NOMBRE_USER", tAB_RECETAS.ID_USER);
            return View(tAB_RECETAS);
        }

        // POST: TAB_RECETAS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_RECETA,NOM_RECETA,ID_CATEGORIA,DURACION,PORCIONES,ID_TAGS,ID_ESTADO,ID_USER,FECHA_CREACION,FECHA_MODIFICACION")] TAB_RECETAS tAB_RECETAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAB_RECETAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CATEGORIA = new SelectList(db.TAB_CATEGORIAS, "ID_CATEGORIA", "CATEGORIA", tAB_RECETAS.ID_CATEGORIA);
            ViewBag.ID_ESTADO = new SelectList(db.TAB_ESTADO, "ID_ESTADO", "ESTADO", tAB_RECETAS.ID_ESTADO);
            ViewBag.ID_TAGS = new SelectList(db.TAB_TAGS, "ID_TAGS", "TAGS", tAB_RECETAS.ID_TAGS);
            ViewBag.ID_USER = new SelectList(db.TAB_USER, "ID_USER", "NOMBRE_USER", tAB_RECETAS.ID_USER);
            return View(tAB_RECETAS);
        }

        // GET: TAB_RECETAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_RECETAS tAB_RECETAS = db.TAB_RECETAS.Find(id);
            if (tAB_RECETAS == null)
            {
                return HttpNotFound();
            }
            return View(tAB_RECETAS);
        }

        // POST: TAB_RECETAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TAB_RECETAS tAB_RECETAS = db.TAB_RECETAS.Find(id);
            db.TAB_RECETAS.Remove(tAB_RECETAS);
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
