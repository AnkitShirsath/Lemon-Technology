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
    public class comman_fruit_vegController : Controller
    {
        private Ankit_TaskEntities db = new Ankit_TaskEntities();

        // GET: comman_fruit_veg
        public ActionResult Index()
        {
            var comman_fruit_veg = db.comman_fruit_veg.Include(c => c.fruits_tbl).Include(c => c.vegerables_tbl);
            return View(comman_fruit_veg.ToList());
        }

        // GET: comman_fruit_veg/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comman_fruit_veg comman_fruit_veg = db.comman_fruit_veg.Find(id);
            if (comman_fruit_veg == null)
            {
                return HttpNotFound();
            }
            return View(comman_fruit_veg);
        }

        // GET: comman_fruit_veg/Create
        public ActionResult Create()
        {
            ViewBag.Fruit_id = new SelectList(db.fruits_tbl, "Fruit_id", "Fruit_name");
            ViewBag.veg_Id = new SelectList(db.vegerables_tbl, "veg_Id", "veg_Name");
            return View();
        }

        // POST: comman_fruit_veg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fv,Fruit_id,veg_Id")] comman_fruit_veg comman_fruit_veg)
        {
            if (ModelState.IsValid)
            {
                db.comman_fruit_veg.Add(comman_fruit_veg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Fruit_id = new SelectList(db.fruits_tbl, "Fruit_id", "Fruit_name", comman_fruit_veg.Fruit_id);
            ViewBag.veg_Id = new SelectList(db.vegerables_tbl, "veg_Id", "veg_Name", comman_fruit_veg.veg_Id);
            return View(comman_fruit_veg);
        }

        // GET: comman_fruit_veg/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comman_fruit_veg comman_fruit_veg = db.comman_fruit_veg.Find(id);
            if (comman_fruit_veg == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fruit_id = new SelectList(db.fruits_tbl, "Fruit_id", "Fruit_name", comman_fruit_veg.Fruit_id);
            ViewBag.veg_Id = new SelectList(db.vegerables_tbl, "veg_Id", "veg_Name", comman_fruit_veg.veg_Id);
            return View(comman_fruit_veg);
        }

        // POST: comman_fruit_veg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fv,Fruit_id,veg_Id")] comman_fruit_veg comman_fruit_veg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comman_fruit_veg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fruit_id = new SelectList(db.fruits_tbl, "Fruit_id", "Fruit_name", comman_fruit_veg.Fruit_id);
            ViewBag.veg_Id = new SelectList(db.vegerables_tbl, "veg_Id", "veg_Name", comman_fruit_veg.veg_Id);
            return View(comman_fruit_veg);
        }

        // GET: comman_fruit_veg/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comman_fruit_veg comman_fruit_veg = db.comman_fruit_veg.Find(id);
            if (comman_fruit_veg == null)
            {
                return HttpNotFound();
            }
            return View(comman_fruit_veg);
        }

        // POST: comman_fruit_veg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            comman_fruit_veg comman_fruit_veg = db.comman_fruit_veg.Find(id);
            db.comman_fruit_veg.Remove(comman_fruit_veg);
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
