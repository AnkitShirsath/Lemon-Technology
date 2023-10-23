using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task_company.Models;

namespace Task_company.Controllers
{
    public class vegerables_tblController : Controller
    {
        private Ankit_TaskEntities db = new Ankit_TaskEntities();

        // GET: vegerables_tbl
        public ActionResult Index()
        {
            var vegerables_tbl = db.vegerables_tbl.Include(v => v.fruits_tbl1);
            return View(vegerables_tbl.ToList());
        }

        // GET: vegerables_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vegerables_tbl vegerables_tbl = db.vegerables_tbl.Find(id);
            if (vegerables_tbl == null)
            {
                return HttpNotFound();
            }
            return View(vegerables_tbl);
        }

        // GET: vegerables_tbl/Create
        public ActionResult Create()
        {
            ViewBag.Fruit_id = new SelectList(db.fruits_tbl, "Fruit_id", "Fruit_name");
            return View();
        }

        // POST: vegerables_tbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "veg_Id,veg_Name,Fruit_id")] vegerables_tbl vegerables_tbl)
        {
            if (ModelState.IsValid)
            {
                db.vegerables_tbl.Add(vegerables_tbl);
                db.SaveChanges();
                TempData["message"] = "Your Data Save Successfuly..";

                return RedirectToAction("Index");
            }

            ViewBag.Fruit_id = new SelectList(db.fruits_tbl, "Fruit_id", "Fruit_name", vegerables_tbl.Fruit_id);
            return View(vegerables_tbl);
        }

        // GET: vegerables_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vegerables_tbl vegerables_tbl = db.vegerables_tbl.Find(id);
            if (vegerables_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fruit_id = new SelectList(db.fruits_tbl, "Fruit_id", "Fruit_name", vegerables_tbl.Fruit_id);
            return View(vegerables_tbl);
        }

        // POST: vegerables_tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "veg_Id,veg_Name,Fruit_id")] vegerables_tbl vegerables_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vegerables_tbl).State = EntityState.Modified;
                db.SaveChanges();
                TempData["message"] = "Your Data Update Successfuly";

                return RedirectToAction("Index");
            }
            ViewBag.Fruit_id = new SelectList(db.fruits_tbl, "Fruit_id", "Fruit_name", vegerables_tbl.Fruit_id);
            return View(vegerables_tbl);
        }

        // GET: vegerables_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vegerables_tbl vegerables_tbl = db.vegerables_tbl.Find(id);
            if (vegerables_tbl == null)
            {
                return HttpNotFound();
            }
            return View(vegerables_tbl);
        }


        // POST: vegerables_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vegerables_tbl vegerables_tbl = db.vegerables_tbl.Find(id);
            db.vegerables_tbl.Remove(vegerables_tbl);
            db.SaveChanges();
            TempData["Delete"] = "Data Delete Sucessfully!";

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
