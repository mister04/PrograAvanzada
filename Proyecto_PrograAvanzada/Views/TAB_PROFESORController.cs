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
    public class TAB_PROFESORController : Controller
    {
        private PROYECTO_PAEntities db = new PROYECTO_PAEntities();

        // GET: TAB_PROFESOR
        public ActionResult Index()
        {
            var tAB_PROFESOR = db.TAB_PROFESOR.Include(t => t.TAB_ROL);
            return View(tAB_PROFESOR.ToList());
        }

        // GET: TAB_PROFESOR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_PROFESOR tAB_PROFESOR = db.TAB_PROFESOR.Find(id);
            if (tAB_PROFESOR == null)
            {
                return HttpNotFound();
            }
            return View(tAB_PROFESOR);
        }

        // GET: TAB_PROFESOR/Create
        public ActionResult Create()
        {
            ViewBag.ID_ROL = new SelectList(db.TAB_ROL, "ID_ROL", "ROL");
            return View();
        }

        // POST: TAB_PROFESOR/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PROFESOR,NOMBRE,APELLIDO_MAT,APELLIDO_PAT,CEDULA,ID_ROL")] TAB_PROFESOR tAB_PROFESOR)
        {
            if (ModelState.IsValid)
            {
                db.TAB_PROFESOR.Add(tAB_PROFESOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ROL = new SelectList(db.TAB_ROL, "ID_ROL", "ROL", tAB_PROFESOR.ID_ROL);
            return View(tAB_PROFESOR);
        }

        // GET: TAB_PROFESOR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_PROFESOR tAB_PROFESOR = db.TAB_PROFESOR.Find(id);
            if (tAB_PROFESOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ROL = new SelectList(db.TAB_ROL, "ID_ROL", "ROL", tAB_PROFESOR.ID_ROL);
            return View(tAB_PROFESOR);
        }

        // POST: TAB_PROFESOR/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PROFESOR,NOMBRE,APELLIDO_MAT,APELLIDO_PAT,CEDULA,ID_ROL")] TAB_PROFESOR tAB_PROFESOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAB_PROFESOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ROL = new SelectList(db.TAB_ROL, "ID_ROL", "ROL", tAB_PROFESOR.ID_ROL);
            return View(tAB_PROFESOR);
        }

        // GET: TAB_PROFESOR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_PROFESOR tAB_PROFESOR = db.TAB_PROFESOR.Find(id);
            if (tAB_PROFESOR == null)
            {
                return HttpNotFound();
            }
            return View(tAB_PROFESOR);
        }

        // POST: TAB_PROFESOR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TAB_PROFESOR tAB_PROFESOR = db.TAB_PROFESOR.Find(id);
            db.TAB_PROFESOR.Remove(tAB_PROFESOR);
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
