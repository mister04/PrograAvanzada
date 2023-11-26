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
    public class TAB_CURSOSController : Controller
    {
        private DB_PROYECTO_PAEntities db = new DB_PROYECTO_PAEntities();

        // GET: TAB_CURSOS
        public ActionResult Index()
        {
            var tAB_CURSOS = db.TAB_CURSOS.Include(t => t.TAB_RECETAS).Include(t => t.TAB_ESTADO).Include(t => t.TAB_PROFESOR).Include(t => t.TAB_USER);
            return View(tAB_CURSOS.ToList());
        }

        // GET: TAB_CURSOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_CURSOS tAB_CURSOS = db.TAB_CURSOS.Find(id);
            if (tAB_CURSOS == null)
            {
                return HttpNotFound();
            }
            return View(tAB_CURSOS);
        }

        // GET: TAB_CURSOS/Create
        public ActionResult Create()
        {
            ViewBag.COD_RECETA = new SelectList(db.TAB_RECETAS, "COD_RECETA", "NOM_RECETA");
            ViewBag.ID_ESTADO = new SelectList(db.TAB_ESTADO, "ID_ESTADO", "ESTADO");
            ViewBag.ID_PROFESOR = new SelectList(db.TAB_PROFESOR, "ID_PROFESOR", "NOMBRE");
            ViewBag.ID_USER = new SelectList(db.TAB_USER, "ID_USER", "NOMBRE_USER");
            return View();
        }

        // POST: TAB_CURSOS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODIGO,NOMBRE,ID_PROFESOR,HORARIO,FECHA_INICIO,FECHA_FIN,COD_RECETA,ID_USER,ID_ESTADO")] TAB_CURSOS tAB_CURSOS)
        {
            if (ModelState.IsValid)
            {
                db.TAB_CURSOS.Add(tAB_CURSOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_RECETA = new SelectList(db.TAB_RECETAS, "COD_RECETA", "NOM_RECETA", tAB_CURSOS.COD_RECETA);
            ViewBag.ID_ESTADO = new SelectList(db.TAB_ESTADO, "ID_ESTADO", "ESTADO", tAB_CURSOS.ID_ESTADO);
            ViewBag.ID_PROFESOR = new SelectList(db.TAB_PROFESOR, "ID_PROFESOR", "NOMBRE", tAB_CURSOS.ID_PROFESOR);
            ViewBag.ID_USER = new SelectList(db.TAB_USER, "ID_USER", "NOMBRE_USER", tAB_CURSOS.ID_USER);
            return View(tAB_CURSOS);
        }

        // GET: TAB_CURSOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_CURSOS tAB_CURSOS = db.TAB_CURSOS.Find(id);
            if (tAB_CURSOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_RECETA = new SelectList(db.TAB_RECETAS, "COD_RECETA", "NOM_RECETA", tAB_CURSOS.COD_RECETA);
            ViewBag.ID_ESTADO = new SelectList(db.TAB_ESTADO, "ID_ESTADO", "ESTADO", tAB_CURSOS.ID_ESTADO);
            ViewBag.ID_PROFESOR = new SelectList(db.TAB_PROFESOR, "ID_PROFESOR", "NOMBRE", tAB_CURSOS.ID_PROFESOR);
            ViewBag.ID_USER = new SelectList(db.TAB_USER, "ID_USER", "NOMBRE_USER", tAB_CURSOS.ID_USER);
            return View(tAB_CURSOS);
        }

        // POST: TAB_CURSOS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODIGO,NOMBRE,ID_PROFESOR,HORARIO,FECHA_INICIO,FECHA_FIN,COD_RECETA,ID_USER,ID_ESTADO")] TAB_CURSOS tAB_CURSOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAB_CURSOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_RECETA = new SelectList(db.TAB_RECETAS, "COD_RECETA", "NOM_RECETA", tAB_CURSOS.COD_RECETA);
            ViewBag.ID_ESTADO = new SelectList(db.TAB_ESTADO, "ID_ESTADO", "ESTADO", tAB_CURSOS.ID_ESTADO);
            ViewBag.ID_PROFESOR = new SelectList(db.TAB_PROFESOR, "ID_PROFESOR", "NOMBRE", tAB_CURSOS.ID_PROFESOR);
            ViewBag.ID_USER = new SelectList(db.TAB_USER, "ID_USER", "NOMBRE_USER", tAB_CURSOS.ID_USER);
            return View(tAB_CURSOS);
        }

        // GET: TAB_CURSOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_CURSOS tAB_CURSOS = db.TAB_CURSOS.Find(id);
            if (tAB_CURSOS == null)
            {
                return HttpNotFound();
            }
            return View(tAB_CURSOS);
        }

        // POST: TAB_CURSOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TAB_CURSOS tAB_CURSOS = db.TAB_CURSOS.Find(id);
            db.TAB_CURSOS.Remove(tAB_CURSOS);
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
