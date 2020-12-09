using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingPertemuan1.Context;
using TrainingPertemuan1.Models;

namespace TrainingPertemuan1.Controllers
{
    [RoutePrefix("RouteBarangs")]
    public class BarangsController : Controller
    {
        MyContext myContext = new MyContext();
        public ActionResult Index()
        {
            return View();
        }
        [Route("GetAll")]
        public JsonResult GetBarangs()
        {
            var result = myContext.Barangs.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [Route("GetById")]
        public JsonResult GetBarangs(int id)
        {
            var result = myContext.Barangs.Find(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [Route("PostBarang")]
        public JsonResult Post(Barang barang)
        {
            myContext.Barangs.Add(barang);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Json(200, JsonRequestBehavior.AllowGet);
            return Json(400, JsonRequestBehavior.AllowGet);
        }
        [Route("EditBarang")]
        public JsonResult Edit(Barang barang)
        {
            var get = myContext.Barangs.Find(barang.Id);
            if (get != null)
            {
                if (TryUpdateModel(get, "", new string[] { "Name" }))
                {
                    myContext.SaveChanges();
                    return Json(200, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(400, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(400, JsonRequestBehavior.AllowGet);
        }
        [Route("DeleteBarang")]
        public JsonResult Delete(int id)
        {
            var get = myContext.Barangs.Find(id);
            if (get != null)
            {
                myContext.Barangs.Remove(get);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return Json(200, JsonRequestBehavior.AllowGet);
                return Json(400, JsonRequestBehavior.AllowGet);
            }
            return Json(404, JsonRequestBehavior.AllowGet);
        }
    }
}
