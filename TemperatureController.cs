using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiharITI.Controllers
{
    public class TemperatureController : Controller
    {
        // GET: Temperature
        public ActionResult Index()
        {
            return View();
        }
    }
}