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
    public class TAB_ROLController : Controller
    {
        private PROYECTO_PAEntities db = new PROYECTO_PAEntities();

        // GET: TAB_ROL
        public ActionResult Index()
        {
            return View(db.TAB_ROL.ToList());
        }

        // GET: TAB_ROL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_ROL tAB_ROL = db.TAB_ROL.Find(id);
            if (tAB_ROL == null)
            {
                return HttpNotFound();
            }
            return View(tAB_ROL);
        }

        // GET: TAB_ROL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TAB_ROL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ROL,ROL")] TAB_ROL tAB_ROL)
        {
            if (ModelState.IsValid)
            {
                db.TAB_ROL.Add(tAB_ROL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tAB_ROL);
        }

        // GET: TAB_ROL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_ROL tAB_ROL = db.TAB_ROL.Find(id);
            if (tAB_ROL == null)
            {
                return HttpNotFound();
            }
            return View(tAB_ROL);
        }

        // POST: TAB_ROL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ROL,ROL")] TAB_ROL tAB_ROL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAB_ROL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tAB_ROL);
        }

        // GET: TAB_ROL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAB_ROL tAB_ROL = db.TAB_ROL.Find(id);
            if (tAB_ROL == null)
            {
                return HttpNotFound();
            }
            return View(tAB_ROL);
        }

        // POST: TAB_ROL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TAB_ROL tAB_ROL = db.TAB_ROL.Find(id);
            db.TAB_ROL.Remove(tAB_ROL);
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
