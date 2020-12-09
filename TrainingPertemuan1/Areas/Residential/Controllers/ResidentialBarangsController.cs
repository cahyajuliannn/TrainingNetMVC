using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingPertemuan1.Context;
using TrainingPertemuan1.Models;

namespace TrainingPertemuan1.Areas.Residential.Controllers
{
    [RouteArea("Residential")]
    [RoutePrefix("NewResidentialBarang")]
    public class ResidentialBarangsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Residential/ResidentialBarangs
        [Route("GetAll")]
        public ActionResult Index()
        {
            return View(db.Barangs.ToList());
        }

        // GET: Residential/ResidentialBarangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barang barang = db.Barangs.Find(id);
            if (barang == null)
            {
                return HttpNotFound();
            }
            return View(barang);
        }

        // GET: Residential/ResidentialBarangs/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Residential/ResidentialBarangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Barang barang)
        {
            if (ModelState.IsValid)
            {
                db.Barangs.Add(barang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(barang);
        }

        // GET: Residential/ResidentialBarangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barang barang = db.Barangs.Find(id);
            if (barang == null)
            {
                return HttpNotFound();
            }
            return View(barang);
        }

        // POST: Residential/ResidentialBarangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Barang barang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barang);
        }

        // GET: Residential/ResidentialBarangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barang barang = db.Barangs.Find(id);
            if (barang == null)
            {
                return HttpNotFound();
            }
            return View(barang);
        }

        // POST: Residential/ResidentialBarangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barang barang = db.Barangs.Find(id);
            db.Barangs.Remove(barang);
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
