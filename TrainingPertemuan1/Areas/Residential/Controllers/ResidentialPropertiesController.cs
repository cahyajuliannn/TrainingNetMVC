using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainingPertemuan1.Areas.Residential.Controllers
{
    [RouteArea("Residential")]
    [RoutePrefix("NewResidentialProperty")]
    public class ResidentialPropertiesController : Controller
    {
        [Route("Buy")]
        public ActionResult Buy()
        {
            return View();
        }
        [Route("Sell")]
        public ActionResult Sell()
        {
            return View();
        }
    }
}