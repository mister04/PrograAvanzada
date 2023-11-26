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
    public class TAB_INSTRUCCIONESController : Controller
    {
        private DB_PROYECTO_PAEntities db = new DB_PROYECTO_PAEntities();

        // GET: TAB_INSTRUCCIONES
        public ActionResult Index()
        {
            var tAB_INSTRUCCIONES = db.TAB_INSTRUCCIONES.Include(t => t.TAB_RECETAS);
            return View(tAB_INSTRUCCIONES.ToList());
        }

        // GET: TAB_INSTRUCCIONES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_INSTRUCCIONES tAB_INSTRUCCIONES = db.TAB_INSTRUCCIONES.Find(id);
            if (tAB_INSTRUCCIONES == null)
            {
                return HttpNotFound();
            }
            return View(tAB_INSTRUCCIONES);
        }

        // GET: TAB_INSTRUCCIONES/Create
        public ActionResult Create()
        {
            ViewBag.COD_RECETA = new SelectList(db.TAB_RECETAS, "COD_RECETA", "NOM_RECETA");
            return View();
        }

        // POST: TAB_INSTRUCCIONES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_INSTRUCCIONES,COD_RECETA,INSTRUCCIONES")] TAB_INSTRUCCIONES tAB_INSTRUCCIONES)
        {
            if (ModelState.IsValid)
            {
                db.TAB_INSTRUCCIONES.Add(tAB_INSTRUCCIONES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_RECETA = new SelectList(db.TAB_RECETAS, "COD_RECETA", "NOM_RECETA", tAB_INSTRUCCIONES.COD_RECETA);
            return View(tAB_INSTRUCCIONES);
        }

        // GET: TAB_INSTRUCCIONES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_INSTRUCCIONES tAB_INSTRUCCIONES = db.TAB_INSTRUCCIONES.Find(id);
            if (tAB_INSTRUCCIONES == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_RECETA = new SelectList(db.TAB_RECETAS, "COD_RECETA", "NOM_RECETA", tAB_INSTRUCCIONES.COD_RECETA);
            return View(tAB_INSTRUCCIONES);
        }

        // POST: TAB_INSTRUCCIONES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_INSTRUCCIONES,COD_RECETA,INSTRUCCIONES")] TAB_INSTRUCCIONES tAB_INSTRUCCIONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAB_INSTRUCCIONES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_RECETA = new SelectList(db.TAB_RECETAS, "COD_RECETA", "NOM_RECETA", tAB_INSTRUCCIONES.COD_RECETA);
            return View(tAB_INSTRUCCIONES);
        }

        // GET: TAB_INSTRUCCIONES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_INSTRUCCIONES tAB_INSTRUCCIONES = db.TAB_INSTRUCCIONES.Find(id);
            if (tAB_INSTRUCCIONES == null)
            {
                return HttpNotFound();
            }
            return View(tAB_INSTRUCCIONES);
        }

        // POST: TAB_INSTRUCCIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TAB_INSTRUCCIONES tAB_INSTRUCCIONES = db.TAB_INSTRUCCIONES.Find(id);
            db.TAB_INSTRUCCIONES.Remove(tAB_INSTRUCCIONES);
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
