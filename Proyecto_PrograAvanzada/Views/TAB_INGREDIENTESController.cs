using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_PrograAvanzada.Models2;

namespace Proyecto_PrograAvanzada.Views
{
    public class TAB_INGREDIENTESController : Controller
    {
        private PROYECTO_PAEntities db = new PROYECTO_PAEntities();

        // GET: TAB_INGREDIENTES
        public ActionResult Index()
        {
            var tAB_INGREDIENTES = db.TAB_INGREDIENTES.Include(t => t.TAB_RECETAS);
            return View(tAB_INGREDIENTES.ToList());
        }

        // GET: TAB_INGREDIENTES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_INGREDIENTES tAB_INGREDIENTES = db.TAB_INGREDIENTES.Find(id);
            if (tAB_INGREDIENTES == null)
            {
                return HttpNotFound();
            }
            return View(tAB_INGREDIENTES);
        }

        // GET: TAB_INGREDIENTES/Create
        public ActionResult Create()
        {
            ViewBag.COD_RECETA = new SelectList(db.TAB_RECETAS, "COD_RECETA", "NOM_RECETA");
            return View();
        }

        // POST: TAB_INGREDIENTES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_INGREDIENTES,COD_RECETA,INGREDIENTES")] TAB_INGREDIENTES tAB_INGREDIENTES)
        {
            if (ModelState.IsValid)
            {
                db.TAB_INGREDIENTES.Add(tAB_INGREDIENTES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_RECETA = new SelectList(db.TAB_RECETAS, "COD_RECETA", "NOM_RECETA", tAB_INGREDIENTES.COD_RECETA);
            return View(tAB_INGREDIENTES);
        }

        // GET: TAB_INGREDIENTES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_INGREDIENTES tAB_INGREDIENTES = db.TAB_INGREDIENTES.Find(id);
            if (tAB_INGREDIENTES == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_RECETA = new SelectList(db.TAB_RECETAS, "COD_RECETA", "NOM_RECETA", tAB_INGREDIENTES.COD_RECETA);
            return View(tAB_INGREDIENTES);
        }

        // POST: TAB_INGREDIENTES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_INGREDIENTES,COD_RECETA,INGREDIENTES")] TAB_INGREDIENTES tAB_INGREDIENTES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAB_INGREDIENTES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_RECETA = new SelectList(db.TAB_RECETAS, "COD_RECETA", "NOM_RECETA", tAB_INGREDIENTES.COD_RECETA);
            return View(tAB_INGREDIENTES);
        }

        // GET: TAB_INGREDIENTES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_INGREDIENTES tAB_INGREDIENTES = db.TAB_INGREDIENTES.Find(id);
            if (tAB_INGREDIENTES == null)
            {
                return HttpNotFound();
            }
            return View(tAB_INGREDIENTES);
        }

        // POST: TAB_INGREDIENTES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TAB_INGREDIENTES tAB_INGREDIENTES = db.TAB_INGREDIENTES.Find(id);
            db.TAB_INGREDIENTES.Remove(tAB_INGREDIENTES);
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
