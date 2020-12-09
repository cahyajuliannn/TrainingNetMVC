using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainingPertemuan1.Controllers
{
    [RoutePrefix("Property")]
    public class PropertiesController : Controller
    {
        [Route("BuyProperty/{id:int}")]
        // GET: Properties
        public ActionResult Buy(int id)
        {
            ViewBag.Data = id;
            return View();
        }
        [Route("SellProperty/{val}")]
        public ActionResult Sell(string val)
        {
            ViewBag.Data = val;
            return View();
        }
        [Route("RentProperty")]
        public ActionResult Rent()
        {
            return View();
        }
    }
}