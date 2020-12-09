using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrainingPertemuan1.Context;
using TrainingPertemuan1.Models;

namespace TrainingPertemuan1.Controllers
{
    [RoutePrefix("RouteKategoriBarangs")]
    public class KategoriBarangsController : Controller
    {
        private MyContext myContext = new MyContext();

        public ActionResult Index()
        {
            return View();
        }
        [Route("GetAll")]
        public JsonResult GetBarangs()
        {
            var result = myContext.KategoriBarangs.Include("Barang").ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [Route("GetById")]
        public JsonResult GetBarangs(int id)
        {
            var result = myContext.KategoriBarangs.Find(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [Route("PostBarang")]
        public JsonResult Post(KategoriBarang kb)
        {
            myContext.KategoriBarangs.Add(kb);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Json(200, JsonRequestBehavior.AllowGet);
            return Json(400, JsonRequestBehavior.AllowGet);
        }
        [Route("EditBarang")]
        public JsonResult Edit(KategoriBarang kb)
        {
            var get = myContext.KategoriBarangs.Find(kb.Id);
            if (get != null)
            {
                if (TryUpdateModel(get, "", new string[] { "Name" ,"Barang_Id"}))
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
            var get = myContext.KategoriBarangs.Find(id);
            if (get != null)
            {
                myContext.KategoriBarangs.Remove(get);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return Json(200, JsonRequestBehavior.AllowGet);
                return Json(400, JsonRequestBehavior.AllowGet);
            }
            return Json(404, JsonRequestBehavior.AllowGet);
        }
    }
}
