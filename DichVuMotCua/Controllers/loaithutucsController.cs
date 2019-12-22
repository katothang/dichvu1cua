using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DichVuMotCua.Models;

namespace DichVuMotCua.Controllers
{
    public class loaithutucsController : Controller
    {
        private DBmodels db = new DBmodels();

        // GET: loaithutucs
        public ActionResult Index()
        {
            return View(db.loaithutucs.ToList());
        }

        // GET: loaithutucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loaithutuc loaithutuc = db.loaithutucs.Find(id);
            if (loaithutuc == null)
            {
                return HttpNotFound();
            }
            return View(loaithutuc);
        }

        // GET: loaithutucs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: loaithutucs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,loai")] loaithutuc loaithutuc)
        {
            if (ModelState.IsValid)
            {
                db.loaithutucs.Add(loaithutuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaithutuc);
        }

        // GET: loaithutucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loaithutuc loaithutuc = db.loaithutucs.Find(id);
            if (loaithutuc == null)
            {
                return HttpNotFound();
            }
            return View(loaithutuc);
        }

        // POST: loaithutucs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,loai")] loaithutuc loaithutuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaithutuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaithutuc);
        }

        // GET: loaithutucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loaithutuc loaithutuc = db.loaithutucs.Find(id);
            if (loaithutuc == null)
            {
                return HttpNotFound();
            }
            return View(loaithutuc);
        }

        // POST: loaithutucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            loaithutuc loaithutuc = db.loaithutucs.Find(id);
            db.loaithutucs.Remove(loaithutuc);
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
