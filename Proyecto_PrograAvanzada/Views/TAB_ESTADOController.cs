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
    public class TAB_ESTADOController : Controller
    {
        private PROYECTO_PAEntities db = new PROYECTO_PAEntities();

        // GET: TAB_ESTADO
        public ActionResult Index()
        {
            return View(db.TAB_ESTADO.ToList());
        }

        // GET: TAB_ESTADO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_ESTADO tAB_ESTADO = db.TAB_ESTADO.Find(id);
            if (tAB_ESTADO == null)
            {
                return HttpNotFound();
            }
            return View(tAB_ESTADO);
        }

        // GET: TAB_ESTADO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TAB_ESTADO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ESTADO,ESTADO")] TAB_ESTADO tAB_ESTADO)
        {
            if (ModelState.IsValid)
            {
                db.TAB_ESTADO.Add(tAB_ESTADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tAB_ESTADO);
        }

        // GET: TAB_ESTADO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_ESTADO tAB_ESTADO = db.TAB_ESTADO.Find(id);
            if (tAB_ESTADO == null)
            {
                return HttpNotFound();
            }
            return View(tAB_ESTADO);
        }

        // POST: TAB_ESTADO/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ESTADO,ESTADO")] TAB_ESTADO tAB_ESTADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAB_ESTADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tAB_ESTADO);
        }

        // GET: TAB_ESTADO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_ESTADO tAB_ESTADO = db.TAB_ESTADO.Find(id);
            if (tAB_ESTADO == null)
            {
                return HttpNotFound();
            }
            return View(tAB_ESTADO);
        }

        // POST: TAB_ESTADO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TAB_ESTADO tAB_ESTADO = db.TAB_ESTADO.Find(id);
            db.TAB_ESTADO.Remove(tAB_ESTADO);
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
