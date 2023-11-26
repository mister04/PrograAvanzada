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
    public class TAB_USERController : Controller
    {
        private DB_PROYECTO_PAEntities db = new DB_PROYECTO_PAEntities();

        // GET: TAB_USER
        public ActionResult Index()
        {
            var tAB_USER = db.TAB_USER.Include(t => t.TAB_ESTADO).Include(t => t.TAB_ROL);
            return View(tAB_USER.ToList());
        }

        // GET: TAB_USER/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_USER tAB_USER = db.TAB_USER.Find(id);
            if (tAB_USER == null)
            {
                return HttpNotFound();
            }
            return View(tAB_USER);
        }

        // GET: TAB_USER/Create
        public ActionResult Create()
        {
            ViewBag.ID_ESTADO = new SelectList(db.TAB_ESTADO, "ID_ESTADO", "ESTADO");
            ViewBag.ID_ROL = new SelectList(db.TAB_ROL, "ID_ROL", "ROL");
            return View();
        }

        // POST: TAB_USER/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_USER,NOMBRE_USER,PASSWORD,ID_ROL,FECHA_CONEXION,ID_ESTADO")] TAB_USER tAB_USER)
        {
            if (ModelState.IsValid)
            {
                db.TAB_USER.Add(tAB_USER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ESTADO = new SelectList(db.TAB_ESTADO, "ID_ESTADO", "ESTADO", tAB_USER.ID_ESTADO);
            ViewBag.ID_ROL = new SelectList(db.TAB_ROL, "ID_ROL", "ROL", tAB_USER.ID_ROL);
            return View(tAB_USER);
        }

        // GET: TAB_USER/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_USER tAB_USER = db.TAB_USER.Find(id);
            if (tAB_USER == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ESTADO = new SelectList(db.TAB_ESTADO, "ID_ESTADO", "ESTADO", tAB_USER.ID_ESTADO);
            ViewBag.ID_ROL = new SelectList(db.TAB_ROL, "ID_ROL", "ROL", tAB_USER.ID_ROL);
            return View(tAB_USER);
        }

        // POST: TAB_USER/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_USER,NOMBRE_USER,PASSWORD,ID_ROL,FECHA_CONEXION,ID_ESTADO")] TAB_USER tAB_USER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAB_USER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ESTADO = new SelectList(db.TAB_ESTADO, "ID_ESTADO", "ESTADO", tAB_USER.ID_ESTADO);
            ViewBag.ID_ROL = new SelectList(db.TAB_ROL, "ID_ROL", "ROL", tAB_USER.ID_ROL);
            return View(tAB_USER);
        }

        // GET: TAB_USER/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_USER tAB_USER = db.TAB_USER.Find(id);
            if (tAB_USER == null)
            {
                return HttpNotFound();
            }
            return View(tAB_USER);
        }

        // POST: TAB_USER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TAB_USER tAB_USER = db.TAB_USER.Find(id);
            db.TAB_USER.Remove(tAB_USER);
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
