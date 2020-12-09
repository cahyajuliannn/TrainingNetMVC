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
    [RoutePrefix("NewResidentialKategoriBarang")]
    public class ResidentialKategoriBarangsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Residential/ResidentialKategoriBarangs
        [Route("GetAll")]
        public ActionResult Index()
        {
            var kategoriBarangs = db.KategoriBarangs.Include(k => k.Barang);
            return View(kategoriBarangs.ToList());
        }

        // GET: Residential/ResidentialKategoriBarangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategoriBarang kategoriBarang = db.KategoriBarangs.Find(id);
            if (kategoriBarang == null)
            {
                return HttpNotFound();
            }
            return View(kategoriBarang);
        }

        // GET: Residential/ResidentialKategoriBarangs/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.Barang_Id = new SelectList(db.Barangs, "Id", "Name");
            return View();
        }

        // POST: Residential/ResidentialKategoriBarangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Barang_Id")] KategoriBarang kategoriBarang)
        {
            if (ModelState.IsValid)
            {
                db.KategoriBarangs.Add(kategoriBarang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Barang_Id = new SelectList(db.Barangs, "Id", "Name", kategoriBarang.Barang_Id);
            return View(kategoriBarang);
        }

        // GET: Residential/ResidentialKategoriBarangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategoriBarang kategoriBarang = db.KategoriBarangs.Find(id);
            if (kategoriBarang == null)
            {
                return HttpNotFound();
            }
            ViewBag.Barang_Id = new SelectList(db.Barangs, "Id", "Name", kategoriBarang.Barang_Id);
            return View(kategoriBarang);
        }

        // POST: Residential/ResidentialKategoriBarangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Barang_Id")] KategoriBarang kategoriBarang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategoriBarang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Barang_Id = new SelectList(db.Barangs, "Id", "Name", kategoriBarang.Barang_Id);
            return View(kategoriBarang);
        }

        // GET: Residential/ResidentialKategoriBarangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategoriBarang kategoriBarang = db.KategoriBarangs.Find(id);
            if (kategoriBarang == null)
            {
                return HttpNotFound();
            }
            return View(kategoriBarang);
        }

        // POST: Residential/ResidentialKategoriBarangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KategoriBarang kategoriBarang = db.KategoriBarangs.Find(id);
            db.KategoriBarangs.Remove(kategoriBarang);
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
