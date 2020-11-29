using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingPertemuan1.Context;
using TrainingPertemuan1.Models;

namespace TrainingPertemuan1.Controllers
{
    public class DepartmentsController : Controller
    {
        MyContext MyContext = new MyContext();

        // GET: Departments
        public ActionResult Index()
        {
            var result = MyContext.Departments.Include("Division").ToList();
            return View(result);
        }
        public ActionResult Create()
        {
            var result = MyContext.Divisions.OrderBy(x => x.Name)
                .Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }).ToArray();
            ViewBag.Division_Id = result;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (string Name, DateTimeOffset CreatedOn, int Division_Id)
        {
            var department = new Department(0, Name, CreatedOn, Division_Id);
            MyContext.Departments.Add(department);
            var result = MyContext.SaveChanges();
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit (int Id)
        {
            var result = MyContext.Departments.Include("Division").Where(x=>x.Id.Equals(Id)).SingleOrDefault();
            var getDiv = MyContext.Divisions.OrderBy(x => x.Name)
                .Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                    Selected = false
                }).ToArray();
            foreach (var item in getDiv)
            {
                if (item.Value.Equals(result.Id.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }
            ViewBag.Divisions = getDiv;
            if (result!= null)
            {
                return View(result);
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, string Name, DateTimeOffset CreatedOn, int Division_Id)
        {
            var department = new Department(Id, Name, CreatedOn, Division_Id);
            MyContext.Entry(department).State = EntityState.Modified;
            var result = MyContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index");
            return View();
        }
        public ActionResult Delete(int Id)
        {
            var delDepartment = MyContext.Departments.Find(Id);
            if (delDepartment != null)
            {
                MyContext.Departments.Remove(delDepartment);
                var result = MyContext.SaveChanges();
                if(result > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}