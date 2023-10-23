using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Task_company.Models;

namespace Task_company.Controllers
{
    public class fruits_tblController : Controller
    {
        public Ankit_TaskEntities db = new Ankit_TaskEntities();

        // GET: fruits_tbl
        public ActionResult Index()
        {
            var fruits_tbl = db.fruits_tbl.Include(f => f.vegerables_tbl);
            return View(fruits_tbl.ToList());
        }

        

        [HttpGet]
        public ActionResult Details()
        {
            var items = db.fruits_tbl.ToList();
            if (items != null)
            {
                ViewBag.data = items;
            }

            return View("Index");
        }


    

        // GET: fruits_tbl/Create
        public ActionResult Create()
        {
            ViewBag.veg_Id = new SelectList(db.vegerables_tbl, "veg_Id", "veg_Name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Fruit_id,Fruit_name,veg_Id")] fruits_tbl fruits_tbl)
        {
            if (ModelState.IsValid)
            {
                db.fruits_tbl.Add(fruits_tbl);
                db.SaveChanges();
                TempData["message"] = "Your Data Save Successfuly..";


                return RedirectToAction("Index");

            }

            ViewBag.veg_Id = new SelectList(db.vegerables_tbl, "veg_Id", "veg_Name", fruits_tbl.veg_Id);
            return View(fruits_tbl);
        }

        // GET: fruits_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fruits_tbl fruits_tbl = db.fruits_tbl.Find(id);
            if (fruits_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.veg_Id = new SelectList(db.vegerables_tbl, "veg_Id", "veg_Name", fruits_tbl.veg_Id);
            return View(fruits_tbl);
        }

        // POST: fruits_tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Fruit_id,Fruit_name,veg_Id")] fruits_tbl fruits_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fruits_tbl).State = EntityState.Modified;
                db.SaveChanges();
                TempData["message"] = "Your Data Update Successfuly";

                return RedirectToAction("Index");
            }
            ViewBag.veg_Id = new SelectList(db.vegerables_tbl, "veg_Id", "veg_Name", fruits_tbl.veg_Id);
            return View(fruits_tbl);
        }

        // GET: fruits_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fruits_tbl fruits_tbl = db.fruits_tbl.Find(id);
            if (fruits_tbl == null)
            {
                return HttpNotFound();
            }
            return View(fruits_tbl);
        }

        // POST: fruits_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fruits_tbl fruits_tbl = db.fruits_tbl.Find(id);
            db.fruits_tbl.Remove(fruits_tbl);
            db.Entry(fruits_tbl).State = EntityState.Deleted;
            TempData["Delete"] = "Data Delete Sucessfully!";


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
